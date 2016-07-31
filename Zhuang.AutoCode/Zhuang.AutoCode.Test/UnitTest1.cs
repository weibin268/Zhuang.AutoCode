using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Zhuang.AutoCode.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str = new AutoCodeBuilder().SetExpression("{d:yyyy}|-{d:HH:mm}").Build();
            Console.WriteLine(str);
        }
    }
}
