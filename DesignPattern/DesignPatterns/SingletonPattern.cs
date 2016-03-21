using System;

namespace Banana
{
    /**
     * 单例模式
     * **/

    #region 模式1

    public class Singleton1
    {
        private static Singleton1 instance = new Singleton1();
        private Singleton1() { }
        /// <summary>
        /// lazy initialization:no
        /// 线程安全
        /// </summary>
        /// <returns></returns>
        public static Singleton1 GetInstance()
        {
            return instance;
        }
    }

    #endregion

    #region 模式2

    public class Singleton2
    {
        private static Singleton2 instance;
        private static object _lock = new object();        

        private Singleton2() { }
        /// <summary>
        /// lazy initialzation:yes
        /// 线程安全
        /// </summary>
        /// <returns></returns>
        public static Singleton2 GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                    }
                }
            }
            return instance;
        }
    }
    
    #endregion

}