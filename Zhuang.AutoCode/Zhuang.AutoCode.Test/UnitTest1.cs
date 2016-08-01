using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Zhuang.AutoCode.Models;

namespace Zhuang.AutoCode.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str = new AutoCodeBuilder(new SysAutoCode()
            {
                Expression = "zwb-{d:yyyy-MM-dd HH:mm:ss}----{d:HH:mm}"
            }).Build();

            Console.WriteLine(str);
        }
    }
}
