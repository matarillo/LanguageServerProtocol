using LanguageServer.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    public class IdGenerator
    {
        public static IdGenerator Instance = new IdGenerator();

        private long _id;

        public IdGenerator()
        {
            _id = 0L;
        }

        public IdGenerator(long initialValue)
        {
            _id = initialValue;
        }

        public NumberOrString Next()
        {
            var ns = new NumberOrString(_id);
            _id = (_id == long.MaxValue) ? 0L : _id + 1;
            return ns;
        }
    }
}
