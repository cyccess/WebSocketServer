﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace MonitorService.Redis
{
    /// <summary>
    /// 操作Redis数据类型List
    /// </summary>
    public class DoRedisList : RedisBase
    {
        #region 赋值

        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void LPush(string key, string value)
        {
            Client.PushItemToList(key, value);
        }

        /// <summary>
        /// 从左侧向list中添加值，并设置过期时间
        /// </summary>
        public void LPush(string key, string value, DateTime dt)
        {
            Client.PushItemToList(key, value);
            Client.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 从左侧向list中添加值，设置过期时间
        /// </summary>
        public void LPush(string key, string value, TimeSpan sp)
        {
            Client.PushItemToList(key, value);
            Client.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void RPush(string key, string value)
        {
            Client.PrependItemToList(key, value);
        }

        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>    
        public void RPush(string key, string value, DateTime dt)
        {
            Client.PrependItemToList(key, value);
            Client.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>        
        public void RPush(string key, string value, TimeSpan sp)
        {
            Client.PrependItemToList(key, value);
            Client.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 添加key/value
        /// </summary>     
        public void Add(string key, string value)
        {
            Client.AddItemToList(key, value);
        }

        /// <summary>
        /// 添加key/value ,并设置过期时间
        /// </summary>  
        public void Add(string key, string value, DateTime dt)
        {
            Client.AddItemToList(key, value);
            Client.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 添加key/value。并添加过期时间
        /// </summary>  
        public void Add(string key, string value, TimeSpan sp)
        {
            Client.AddItemToList(key, value);
            Client.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// 为key添加多个值
        /// </summary>  
        public void Add(string key, List<string> values)
        {
            Client.AddRangeToList(key, values);
        }

        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, DateTime dt)
        {
            Client.AddRangeToList(key, values);
            Client.ExpireEntryAt(key, dt);
        }

        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, TimeSpan sp)
        {
            Client.AddRangeToList(key, values);
            Client.ExpireEntryIn(key, sp);
        }

        #endregion


        #region 获取值

        /// <summary>
        /// 获取list中key包含的数据数量
        /// </summary>  
        public long Count(string key)
        {
            return Client.GetListCount(key);
        }

        /// <summary>
        /// 获取key包含的所有数据集合
        /// </summary>  
        public List<string> Get(string key)
        {
            return Client.GetAllItemsFromList(key);
        }

        /// <summary>
        /// 获取key中下标为star到end的值集合
        /// </summary>  
        public List<string> Get(string key, int star, int end)
        {
            return Client.GetRangeFromList(key, star, end);
        }

        #endregion

        #region 阻塞命令

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return Client.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            return Client.BlockingPopItemFromLists(keys, sp);
        }

        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return Client.BlockingDequeueItemFromList(key, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        {
            return Client.BlockingDequeueItemFromLists(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingRemoveStartFromList(string keys, TimeSpan? sp)
        {
            return Client.BlockingRemoveStartFromList(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public ItemRef BlockingRemoveStartFromLists(string[] keys, TimeSpan? sp)
        {
            return Client.BlockingRemoveStartFromLists(keys, sp);
        }

        /// <summary>
        /// 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        {
            return Client.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public string PopItemFromList(string key)
        {
            return Client.PopItemFromList(key);
        }

        /// <summary>
        /// 移除list中，key/value,与参数相同的值，并返回移除的数量
        /// </summary>  
        public long RemoveItemFromList(string key, string value)
        {
            return Client.RemoveItemFromList(key, value);
        }

        /// <summary>
        /// 从list的尾部移除一个数据，返回移除的数据
        /// </summary>  
        public string RemoveEndFromList(string key)
        {
            return Client.RemoveEndFromList(key);
        }

        /// <summary>
        /// 从list的头部移除一个数据，返回移除的值
        /// </summary>  
        public string RemoveStartFromList(string key)
        {
            return Client.RemoveStartFromList(key);
        }

        #endregion

        #region 其它

        /// <summary>
        /// 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值
        /// </summary>  
        public string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return Client.PopAndPushItemBetweenLists(fromKey, toKey);
        }

        #endregion
    }
}
