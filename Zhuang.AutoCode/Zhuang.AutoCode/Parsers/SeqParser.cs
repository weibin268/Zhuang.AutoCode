using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Parsers
{
    class SeqParser : IParser
    {
        public string Name
        {
            get
            {
                return "seq";
            }
        }

        public string Parse(string value)
        {
            throw new NotImplementedException();
        }
    }
}
