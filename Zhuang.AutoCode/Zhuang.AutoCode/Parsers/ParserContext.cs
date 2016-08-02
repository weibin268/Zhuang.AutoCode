
using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode.Parsers
{
    public class ParserContext
    {
        public SysAutoCode SysAutoCode { get; set; }

        public string Parameter { get; set; }

        public string ParsedText { get; set; }

        public IAutoCodeService Service { get; set; }
    }
}
