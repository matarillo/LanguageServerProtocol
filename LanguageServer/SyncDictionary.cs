using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer
{
    internal class SyncDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
        private readonly object _lockObj = new object();

        public void Set(TKey key, TValue value)
        {
            lock(_lockObj)
            {
                _dict[key] = value;
            }
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            lock(_lockObj)
            {
                if (_dict.TryGetValue(key, out value))
                {
                    _dict.Remove(key);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            lock (_lockObj)
            {
                return _dict.Remove(key);
            }
        }
    }
}
