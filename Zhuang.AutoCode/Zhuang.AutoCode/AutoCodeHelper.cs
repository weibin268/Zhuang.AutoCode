using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode
{
    public class AutoCodeHelper
    {
        public static String Get(string id)
        {
            IAutoCodeService _service = new AutoCodeService();
            var model = _service.Get(id);
            AutoCodeBuilder builder = new AutoCodeBuilder(model);
            return builder.Build();
        }
    }
}
