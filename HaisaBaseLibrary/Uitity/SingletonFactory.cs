using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaisaBaseLibrary.Uitity
{
    /// <summary>
    /// 继承该单例类即可拥有单例属性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonFactory<T> where T : class, new()
    {

        private static readonly object locker = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {

                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }

        public SingletonFactory()
        {
            if (_instance != null)
            {
                throw new Exception("Can't presented.demonstration object, please use Instance property access");
            }
            _instance = this as T;
        }

    }
}
