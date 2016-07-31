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

            foreach (string subExp in _expression.Split('|'))
            {
                var match = _regCode.Match(subExp);
                if (match != null)
                {
                    string code = match.ToString();

                    var arCode = code.Split(':');
                    string codeName =arCode[0];
                    string codeValue = arCode.Length > 1 ? code.Replace(codeName+":","") : string.Empty;

                    string parsedText = string.Empty;

                    var parser = ParserRepository.Instance.GetParser(codeName);
                    if (parser != null)
                    {
                        parsedText=parser(codeValue);
                    }

                    sbResult.Append(subExp.Replace("{" + code + "}", parsedText));
                }
                else
                {
                    sbResult.Append(subExp);
                }
            }

            return sbResult.ToString();
        }
    }
}
