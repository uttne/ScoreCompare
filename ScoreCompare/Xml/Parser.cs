using System;
using System.Collections.Generic;

namespace ScoreCompare.Xml
{
    public class Parser
    {
        public IEnumerable<Syntax> Parse(string xml)
        {
            var startIndex = 0;
            var substringLength = 0;

            bool isTag = false;
            bool isData = false;

            // Todo New line support
            // Todo Comment support

            for (int i = 0; i < xml.Length; ++i)
            {
                var c = xml[i];

                switch (c)
                {
                    case '<':
                        if (isData)
                        {
                            var syntaxText = xml.Substring(startIndex, substringLength);
                            yield return ParseToData(syntaxText);

                            isData = false;
                        }
                        isTag = true;
                        startIndex = i;
                        substringLength = 1;
                        continue;
                    case '>':
                        if (isTag)
                        {
                            isTag = false;
                            substringLength++;
                            var syntaxText = xml.Substring(startIndex, substringLength);
                            var tagType = JudgeTagType(syntaxText);
                            if ((tagType & TagType.Opening) == TagType.Opening)
                                yield return ParseOpeningTag(syntaxText);
                            if ((tagType & TagType.Closing) == TagType.Closing)
                                yield return ParseClosingTag(syntaxText);
                        }
                        
                        break;
                    
                    case '\r':
                    case '\n':
                        break;
                    default:
                        if (!isData && !isTag)
                        {
                            isData = true;
                            startIndex = i;
                            substringLength = 0;
                        }
                        substringLength++;
                        break;
                }
                
            }
        }

        [Flags]
        internal enum TagType
        {
            None = 0,
            Opening = 1,
            Closing = 2,
            Comment = 4
        }

        internal TagType JudgeTagType(string syntaxText)
        {
            if (syntaxText == null || syntaxText.Length < 3)
                throw new XmlAnalysisException();

            if (syntaxText[0] != '<' || syntaxText[syntaxText.Length - 1] != '>')
                throw new XmlAnalysisException();

            var first = syntaxText[1];
            var latest = syntaxText[syntaxText.Length - 2];

            var ret = TagType.None;

            if(first == '/' && latest == '/')
                throw new XmlAnalysisException();

            
            if (latest == '/')
                ret |= TagType.Opening | TagType.Closing;
            else if (first == '/')
                ret |= TagType.Closing;
            else
                ret |= TagType.Opening;

            return ret;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="syntaxText">Text from '&lt;' to '&gt;'</param>
        /// <returns></returns>
        internal OpeningTag ParseOpeningTag(string syntaxText)
        {
            
            var tagText = syntaxText.Substring(1, syntaxText.Length - 2);
            
            var c = tagText[0];
            if (tagText.Length == 1)
            {
                switch (c)
                {
                    case '/':
                        throw new XmlAnalysisException();
                }
            }

            var nameLength = 0;
            var isName = true;
            var attributeStartIndex = 0;
            var attributeLength = 0;
            List<TagAttribute> attributeList = new List<TagAttribute>();
            for (var i = 0; i < tagText.Length; i++)
            {
                c = tagText[i];
                switch (c)
                {
                    case '/':
                        throw new XmlAnalysisException();
                    case ' ':
                        isName = false;
                        if (attributeLength != 0)
                        {
                            attributeList.Add(ConvertTo(tagText.Substring(attributeStartIndex, attributeLength)));
                            attributeLength = 0;
                        }
                        continue;
                }

                if (isName)
                    nameLength++;
                else
                {
                    if (attributeLength == 0)
                        attributeStartIndex = i;
                    attributeLength++;
                }
            }

            if (attributeLength != 0)
                attributeList.Add(ConvertTo(tagText.Substring(attributeStartIndex, attributeLength)));

            var first = tagText[0];
            var latest = tagText[tagText.Length - 1];

            if (first == '/' && latest == '/')
                throw new XmlAnalysisException();

            if (first == '/')
                throw new XmlAnalysisException();

            string name = tagText.Length == nameLength ? tagText : tagText.Substring(0, nameLength);
            var attributes = new TagAttributeCollection(attributeList);
            return new OpeningTag(syntaxText,tagText,name,attributes);
        }

        internal TagAttribute ConvertTo(string text)
        {
            var nameStartIndex = 0;
            var nameLength = 0;
            var textStartIndex = 0;
            var textLength = 0;
            char quotation = '\0';
            bool isName = true;
            bool isText = false;
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                switch (c)
                {
                    case '"':
                        if (isName)
                        {
                            if (nameLength == 0)
                                throw new XmlAnalysisException();
                        }
                        else
                        {
                            if (isText)
                            {
                                if (quotation == '"')
                                {
                                    isText = false;
                                    continue;
                                }
                            }
                            else
                            {
                                quotation = '"';
                                isText = true;
                                textStartIndex = i + 1;
                                continue;
                            }
                        }
                        
                        break;
                    case '\'':
                        if (isName)
                        {
                            if (nameLength == 0)
                                throw new XmlAnalysisException();
                        }
                        else
                        {
                            if (isText)
                            {
                                if (quotation == '\'')
                                {
                                    isText = false;
                                    continue;
                                }

                            }
                            else
                            {
                                quotation = '\'';
                                isText = true;
                                textStartIndex = i + 1;
                                continue;
                            }
                        }

                        break;
                    case '=':
                        if (nameLength == 0)
                            throw new XmlAnalysisException();
                        isName = false;
                        continue;
                    case ' ':
                        if(isName)
                            throw new XmlAnalysisException();
                        break;
                }
                if((isName ^ isText) == false)
                    throw new XmlAnalysisException();

                if (isName)
                    nameLength++;
                if (isText)
                    textLength++;
            }

            return new TagAttribute(
                text.Substring(nameStartIndex, nameLength),
                text.Substring(textStartIndex, textLength)
                );
        }

        internal ClosingTag ParseClosingTag(string syntaxText)
        {
            var tagText = syntaxText.Substring(1, syntaxText.Length - 2);
            
            var c = tagText[0];
            if (tagText.Length == 1)
            {
                switch (c)
                {
                    case '/':
                        throw new XmlAnalysisException();
                }
            }
            
            for (var i = 0; i < tagText.Length; i++)
            {
                switch (c)
                {
                    case ' ':
                        throw new XmlAnalysisException();
                }
            }

            var first = tagText[0];
            var latest = tagText[tagText.Length - 1];

            if (first == '/' && latest == '/')
                throw new XmlAnalysisException();

            if (first != '/' && latest != '/')
                throw new XmlAnalysisException();

            var name = first == '/' ? tagText.Substring(1) : tagText.Substring(0, tagText.Length - 1);
            
            return new ClosingTag(syntaxText,tagText,name);
        }

        internal Data ParseToData(string syntaxText)
        {
            return new Data(syntaxText, syntaxText);
        }
    }

    public class XmlAnalysisException : Exception
    {

    }
}
