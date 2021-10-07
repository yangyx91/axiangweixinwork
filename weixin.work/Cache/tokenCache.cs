using LazyCache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace weixin.work.Cache
{
    public static class tokenCache
    {
        /// <summary>
        /// 默认企业微信缓存时间 ，单位：秒，换算1.5小时
        /// </summary>
        static IAppCache workcache = new CachingService()
        {
            DefaultCachePolicy = new CacheDefaults()
            {
                DefaultCacheDurationSeconds = 5400
            }
        };

        /// <summary>
        /// 获取缓存键值，异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> func)
        {
            return await workcache.GetOrAddAsync<T>(key, func);
        }

        /// <summary>
        /// 获取缓存键值，同步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T GetOrAdd<T>(string key, Func<T> func)
        {
            return workcache.GetOrAdd<T>(key, func);
        }
    }
}
