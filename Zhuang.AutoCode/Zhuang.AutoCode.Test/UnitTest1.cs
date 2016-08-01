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
            for (int i = 0; i < 10; i++)
            {
                var str = AutoCodeHelper.Get("a");
                Console.WriteLine(str);
            }
        }

    }
}
