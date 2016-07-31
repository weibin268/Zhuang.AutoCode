using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Parsers
{
    public interface IParser
    {
        string Name { get; }

        string Parse(string value);

    }
}
