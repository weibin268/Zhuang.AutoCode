using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Zhuang.AutoCode.Parsers;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode
{
    public class AutoCodeBuilder
    {
        private Regex _regCode = new Regex(@"(?<=\{)[\w|\W]*(?=\})");

        private string _code;

        private string _expression;

        private IAutoCodeService _autoCodeService;

        public AutoCodeBuilder()
        {

        }

        public AutoCodeBuilder SetCode(string code)
        {
            _code = code;
            return this;
        }

        public AutoCodeBuilder SetExpression(string expression)
        {
            _expression = expression;
            return this;
        }

        public string Build()
        {
            StringBuilder sbResult = new StringBuilder();

            if (string.IsNullOrEmpty(_expression))
            {
                var model = _autoCodeService.GetByCode(_code);
                _expression = model.Expression;
            }

            foreach (string exp in _expression.Split('|'))
            {
                var match = _regCode.Match(exp);
                if (match != null)
                {
                    string code = match.ToString();

                    string parsed = string.Empty;

                    var par = ParserRepository.Instance.GetParser(code.Split(':')[0]);
                    if (par != null)
                    {
                        parsed=par(code);
                    }

                    sbResult.Append(exp.Replace("{" + code + "}", parsed));
                }
                else
                {
                    sbResult.Append(exp);
                }
            }

            return sbResult.ToString();
        }
    }
}
