using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Common;

namespace Zhuang.AutoCode.Parsers
{
    public class ParserRepository
    {
        private Dictionary<string, FunParse> _dicParsers;
        private static ParserRepository _instance;
        private static object _objLock = new object();

        public static ParserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_objLock)
                    {
                        if (_instance == null)
                        {
                            _instance = Create();
                        }
                    }
                }
                return _instance;
            }
        }

        private static ParserRepository Create()
        {
            var result = new ParserRepository();

            result.AddParser(new DateTimeParser());

            result.AddParser(new SequenceParser());

            return result;
        }

        public ParserRepository()
        {
            _dicParsers = new Dictionary<string, FunParse>();
        }

        public FunParse GetParser(string name)
        {
            if (_dicParsers.ContainsKey(name))
            {
                return _dicParsers[name];
            }
            else
            {
                return null;
            }
        }

        public void AddParser(IParser parser)
        {
            _dicParsers.Add(parser.Name, parser.Parse);
        }
    }
}
