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
        /// <summary>
        /// 参数解析，参式格式：{d:yyyyMMdd}
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Parse(ParserContext context)
        {

            string dateFormat = context.Parameter;
            return DateTime.Now.ToString(dateFormat);
        }

    }
}
