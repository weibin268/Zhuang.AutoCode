using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.Data;

namespace Zhuang.AutoCode.Test
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class EnvValStoreProviderTest
    {
        public EnvValStoreProviderTest()
        {

            Zhuang.Data.EnvironmentVariable.EnvValRepository.Instance.AddStoreProvider(new Common.EnvValStoreProvider());
        }

        [TestMethod]
        public void TestMethod1()
        {
            DbAccessor dba = DbAccessor.Get();
            var str = dba.ExecuteScalar<string>("select '{{AutoCode:c}}'");

            Console.WriteLine(str);
        }


    }
}
