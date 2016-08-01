using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Zhuang.AutoCode.Models;
using Zhuang.AutoCode.Parsers;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode
{
    public class AutoCodeBuilder
    {
        private Regex _regCode = new Regex(@"(?<=\{)[^\{\}]+(?=\})");

        private SysAutoCode _sysAutoCode;

        public AutoCodeBuilder(SysAutoCode sysAutoCode)
        {
            _sysAutoCode = sysAutoCode;
        }

        public AutoCodeBuilder SetSysAutoCode(SysAutoCode sysAutoCode)
        {
            _sysAutoCode = sysAutoCode;
            return this;
        }

        public string Build()
        {
            string result = string.Empty;

            result = _sysAutoCode.Expression;

            foreach (var match in _regCode.Matches(_sysAutoCode.Expression))
            {
                if (match != null)
                {
                    string code = match.ToString();

                    var arCode = code.Split(':');
                    string codeName =arCode[0];
                    string codeParam = arCode.Length > 1 ? code.Replace(codeName+":","") : string.Empty;

                    string parsedText = string.Empty;

                    var parser = ParserRepository.Instance.GetParser(codeName);
                    if (parser != null)
                    {
                        parsedText = parser(new ParserContext() { SysAutoCode = _sysAutoCode, Parameter = codeParam, ParsedText = result });
                    }

                    result = result.Replace("{" + code + "}", parsedText);
                }
            }

            return result;
        }
    }
}
