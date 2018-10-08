using System;
using System.Collections.Generic;

namespace ScoreCompare.Xml
{
    public class Parser
    {
        public IEnumerable<Syntax> Parse(string xml)
        {
            var tagStartIndex = 0;
            var tagLength = 0;

            var dataStartIndex = 0;
            var dataLength = -1;

            bool isTag = false;
            bool isOpening = false;
            int validDataStartIndex = -1;

            var tagStack = new Stack<Tag>();

            // Todo Comment support

            for (int i = 0; i < xml.Length; ++i)
            {
                var c = xml[i];

                
                switch (c)
                {
                    case '<':
                        isTag = true;
                        tagStartIndex = i;
                        tagLength = 1;
                        
                        continue;
                    case '>':
                        if (isTag)
                        {
                            isTag = false;
                            tagLength++;
                            var syntaxText = xml.Substring(tagStartIndex, tagLength);
                            var tagType = JudgeTagType(syntaxText);

                            var tagIsOpening = (tagType & TagType.Opening) == TagType.Opening;
                            if (tagIsOpening)
                            {
                                if (validDataStartIndex != -1)
                                {
                                    throw new XmlAnalysisException();
                                }

                                var tag = ParseOpeningTag(syntaxText);
                                tagStack.Push(tag);
                                yield return tag;
                                isOpening = true;
                            }

                            var tagIsClosing = (tagType & TagType.Closing) == TagType.Closing;
                            if (tagIsClosing)
                            {
                                if (tagIsOpening){}
                                else
                                {
                                    if (dataLength != -1)
                                    {
                                        var syntaxDataText = xml.Substring(dataStartIndex, dataLength);
                                        yield return ParseToData(syntaxDataText);
                                    }
                                }


                                var tag = ParseClosingTag(syntaxText);
                                if (!(tagStack.Pop() is OpeningTag openingTag && openingTag.Name == tag.Name))
                                    throw new XmlAnalysisException();
                                yield return tag;
                                isOpening = false;
                            }

                            validDataStartIndex = -1;
                            dataLength = -1;
                        }
                        else
                        {
                            throw new XmlAnalysisException();
                        }
                        
                        break;
                    
                    case '\r':
                    case '\n':
                        break;
                    default:
                        switch (c)
                        {
                            case '\r':
                            case '\n':
                            case ' ':
                            case '\t':
                                break;
                            default:
                                if (isTag) { }
                                else
                                {
                                    if (isOpening)
                                    {
                                        if (validDataStartIndex == -1)
                                            validDataStartIndex = i;
                                    }
                                    else
                                        throw new XmlAnalysisException();
                                }
                                
                                break;
                        }

                        if (isTag)
                        {
                            tagLength++;
                        }
                        else
                        {
                            if (dataLength == -1)
                            {
                                dataStartIndex = i;
                                dataLength = 1;
                            }
                            else
                            {
                                dataLength++;
                            }
                        }

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
