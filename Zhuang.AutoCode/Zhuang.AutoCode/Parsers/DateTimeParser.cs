using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Parsers
{
    public class DateTimeParser : IParser
    {
        public ParserMatchMode MatchMode
        {
            get
            {
                return ParserMatchMode.Like;
            }
        }

        public string Name
        {
            get
            {
                return "d:";
            }
        }

        public string Parse(string value)
        {
            string dateFormat = value.Replace(Name, "");
            return DateTime.Now.ToString(dateFormat);
        }
    }
}
