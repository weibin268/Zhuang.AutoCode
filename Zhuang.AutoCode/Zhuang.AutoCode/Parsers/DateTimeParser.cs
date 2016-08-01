using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Parsers
{
    class DateTimeParser : IParser
    {

        public string Name
        {
            get
            {
                return "d";
            }
        }

        public string Parse(ParserContext context)
        {

            string dateFormat = context.Parameter;
            return DateTime.Now.ToString(dateFormat);
        }

    }
}
