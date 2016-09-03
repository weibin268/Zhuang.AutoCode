using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.Data.Common;

namespace Zhuang.AutoCode.Common
{
    public class EnvValStoreProvider : Zhuang.Data.EnvironmentVariable.IEnvValStoreProvider
    {
        public Dictionary<string, object> GetEnvironmentVariables()
        {
            var dicResult = new Dictionary<string, object>();

            var autoCode = new MyEnvFunc((c) =>
            {
                var autoCodeBuilder = new AutoCodeBuilder(c);

                return autoCodeBuilder.Build();

            });

            dicResult.Add("AutoCode", autoCode);
            dicResult.Add("autocode", autoCode);

            return dicResult;
        }
    }
}
