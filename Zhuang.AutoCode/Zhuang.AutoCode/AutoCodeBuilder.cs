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
        private Regex _regExpressionTag = new Regex(@"(?<=\{)[^\{\}]+(?=\})");

        private SysAutoCode _sysAutoCode;
        IAutoCodeService _service;

        public AutoCodeBuilder(string autoCodeId):this(autoCodeId, new AutoCodeService())
        {

        }

        public AutoCodeBuilder(string autoCodeId, IAutoCodeService service)
        {
            _service = service;
            _sysAutoCode = _service.Get(autoCodeId);
        }

        public AutoCodeBuilder StuffExpression(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                _sysAutoCode.Expression = _sysAutoCode.Expression.Replace("{" + i + "}", args[i]);
            }

            return this;
        }

        public string Build()
        {
            string result = string.Empty;

            result = _sysAutoCode.Expression;

            foreach (var match in _regExpressionTag.Matches(_sysAutoCode.Expression))
            {
                if (match != null)
                {
                    string tag = match.ToString();

                    var arTag = tag.Split(':');
                    string tagName =arTag[0];
                    string tagParam = arTag.Length > 1 ? tag.Replace(tagName+":","") : string.Empty;

                    string parsedText = string.Empty;

                    var parser = ParserRepository.Instance.GetParser(tagName);
                    if (parser != null)
                    {
                        parsedText = parser(new ParserContext()
                        {
                            SysAutoCode = _sysAutoCode,
                            Parameter = tagParam,
                            ParsedText = result,
                            Service = _service
                        });
                    }

                    result = result.Replace("{" + tag + "}", parsedText);
                }
            }

            return result;
        }
    }
}
