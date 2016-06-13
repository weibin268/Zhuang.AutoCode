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
                            _instance = new ParserRepository();
                        }
                    }
                }
                return _instance;
            }
        }
        
        public ParserRepository()
        {
            _dicParsers = new Dictionary<string, FunParse>();
        }

        public FunParse GetParser(string key)
        {
            if (_dicParsers.ContainsKey(key))
            {
                return _dicParsers[key];
            }
            else
            {
                return null;
            }
        }

        public void AddParser(string key, FunParse value)
        {
            _dicParsers.Add(key, value);
        }
    }
}
