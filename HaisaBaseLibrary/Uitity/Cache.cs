using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HaisaBaseLibrary.Uitity
{
    /// <summary>
    /// 全局统一缓存类
    /// </summary>
    public class Cache<T>:SingletonFactory<Cache<T>>
    {
        private SortedDictionary<string, T> dic = new SortedDictionary<string, T>();

        public void Add(string key, T value)
        {
            if (ContainsKey(key))
                Remove(key);
            dic.Add(key, value);
        }
        public T GetValue(string key)
        {
           return dic[key];
        }
        public bool ContainsKey(string key)
        {
            return dic.ContainsKey(key);
        }
        public void Remove(string key)
        {
            dic.Remove(key);
        }

        public T this[string index]
        {
            get
            {
                if (dic.ContainsKey(index))
                    return dic[index];
                else
                    return default(T);
            }
            set { dic[index] = value; }
        }
    }
}

