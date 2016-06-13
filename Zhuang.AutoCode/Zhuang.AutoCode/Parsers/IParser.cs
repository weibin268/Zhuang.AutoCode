using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Parsers
{
    public enum ParserMatchMode
    {
        Equal,
        Like,
    }

    public interface IParser
    {
        string Name { get; }

        string Parse(string value);

        ParserMatchMode MatchMode { get; }
    }
}
