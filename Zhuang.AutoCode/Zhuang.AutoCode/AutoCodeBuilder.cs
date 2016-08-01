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
        private Regex _regCode = new Regex(@"(?<=\{)[^\{\}]+(?=\})");

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

        public AutoCodeBuilder SetAutoCodeService(IAutoCodeService autoCodeService)
        {
            _autoCodeService = autoCodeService;
            return this;
        }

        public string Build()
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(_expression))
            {
                var model = _autoCodeService.GetByCode(_code);
                _expression = model.Expression;
            }

            result = _expression;

            foreach (var match in _regCode.Matches(_expression))
            {
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

                    result = result.Replace("{" + code + "}", parsedText);
                }
            }

            return result;
        }
    }
}
