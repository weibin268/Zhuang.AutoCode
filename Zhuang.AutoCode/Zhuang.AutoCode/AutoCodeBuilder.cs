using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode
{
    public class AutoCodeBuilder
    {

        private string _code;

        private IAutoCodeService _autoCodeService;

        public AutoCodeBuilder() : this(null)
        {

        }

        public AutoCodeBuilder(string code):this(new AutoCodeService(),code)
        {

        }

        public AutoCodeBuilder(IAutoCodeService autoCodeService,string code)
        {
            _autoCodeService = autoCodeService;
            _code = code;
        }

        public void SetCode(string code)
        {
            _code = code;
        }

        public string Build()
        {
            StringBuilder sbResult = new StringBuilder();

            var model = _autoCodeService.GetByCode(_code);

            foreach (string exp in model.Expression.Split('|'))
            {

            }

            return sbResult.ToString();
        }
    }
}
