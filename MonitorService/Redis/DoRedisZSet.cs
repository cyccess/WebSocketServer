﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService.Redis
{
    /// <summary>
    /// 操作Redis数据类型有序集合Zset 
    /// </summary>
    public class DoRedisZSet : RedisBase
    {
        #region 添加
        /// <summary>
        /// 添加key/value，默认分数是从1.多*10的9次方以此递增的,自带自增效果
        /// </summary>
        public bool AddItemToSortedSet(string key, string value)
        {
            return Client.AddItemToSortedSet(key, value);
        }
        /// <summary>
        /// 添加key/value,并设置value的分数
        /// </summary>
        public bool AddItemToSortedSet(string key, string value, double score)
        {
            return Client.AddItemToSortedSet(key, value, score);
        }
        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public bool AddRangeToSortedSet(string key, List<string> values, double score)
        {
            return Client.AddRangeToSortedSet(key, values, score);
        }
        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public bool AddRangeToSortedSet(string key, List<string> values, long score)
        {
            return Client.AddRangeToSortedSet(key, values, score);
        }
        #endregion
        #region 获取
        /// <summary>
        /// 获取key的所有集合
        /// </summary>
        public List<string> GetAllItemsFromSortedSet(string key)
        {
            return Client.GetAllItemsFromSortedSet(key);
        }
        /// <summary>
        /// 获取key的所有集合，倒叙输出
        /// </summary>
        public List<string> GetAllItemsFromSortedSetDesc(string key)
        {
            return Client.GetAllItemsFromSortedSetDesc(key);
        }
        /// <summary>
        /// 获取可以的说有集合，带分数
        /// </summary>
        public IDictionary<string, double> GetAllWithScoresFromSortedSet(string key)
        {
            return Client.GetAllWithScoresFromSortedSet(key);
        }
        /// <summary>
        /// 获取key为value的下标值
        /// </summary>
        public long GetItemIndexInSortedSet(string key, string value)
        {
            return Client.GetItemIndexInSortedSet(key, value);
        }
        /// <summary>
        /// 倒叙排列获取key为value的下标值
        /// </summary>
        public long GetItemIndexInSortedSetDesc(string key, string value)
        {
            return Client.GetItemIndexInSortedSetDesc(key, value);
        }
        /// <summary>
        /// 获取key为value的分数
        /// </summary>
        public double GetItemScoreInSortedSet(string key, string value)
        {
            return Client.GetItemScoreInSortedSet(key, value);
        }
        /// <summary>
        /// 获取key所有集合的数据总数
        /// </summary>
        public long GetSortedSetCount(string key)
        {
            return Client.GetSortedSetCount(key);
        }
        /// <summary>
        /// key集合数据从分数为fromscore到分数为toscore的数据总数
        /// </summary>
        public long GetSortedSetCount(string key, double fromScore, double toScore)
        {
            return Client.GetSortedSetCount(key, fromScore, toScore);
        }
        /// <summary>
        /// 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据
        /// </summary>
        public List<string> GetRangeFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return Client.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore);
        }
        /// <summary>
        /// 获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据
        /// </summary>
        public List<string> GetRangeFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return Client.GetRangeFromSortedSetByLowestScore(key, fromscore, toscore);
        }
        /// <summary>
        /// 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据，带分数
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return Client.GetRangeWithScoresFromSortedSetByHighestScore(key, fromscore, toscore);
        }
        /// <summary>
        ///  获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据，带分数
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return Client.GetRangeWithScoresFromSortedSetByLowestScore(key, fromscore, toscore);
        }
        /// <summary>
        ///  获取key集合数据，下标从fromRank到分数为toRank的数据
        /// </summary>
        public List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank)
        {
            return Client.GetRangeFromSortedSet(key, fromRank, toRank);
        }
        /// <summary>
        /// 获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据
        /// </summary>
        public List<string> GetRangeFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return Client.GetRangeFromSortedSetDesc(key, fromRank, toRank);
        }
        /// <summary>
        /// 获取key集合数据，下标从fromRank到分数为toRank的数据，带分数
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSet(string key, int fromRank, int toRank)
        {
            return Client.GetRangeWithScoresFromSortedSet(key, fromRank, toRank);
        }
        /// <summary>
        ///  获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据，带分数
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return Client.GetRangeWithScoresFromSortedSetDesc(key, fromRank, toRank);
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除key为value的数据
        /// </summary>
        public bool RemoveItemFromSortedSet(string key, string value)
        {
            return Client.RemoveItemFromSortedSet(key, value);
        }
        /// <summary>
        /// 删除下标从minRank到maxRank的key集合数据
        /// </summary>
        public long RemoveRangeFromSortedSet(string key, int minRank, int maxRank)
        {
            return Client.RemoveRangeFromSortedSet(key, minRank, maxRank);
        }
        /// <summary>
        /// 删除分数从fromscore到toscore的key集合数据
        /// </summary>
        public long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore)
        {
            return Client.RemoveRangeFromSortedSetByScore(key, fromscore, toscore);
        }
        /// <summary>
        /// 删除key集合中分数最大的数据
        /// </summary>
        public string PopItemWithHighestScoreFromSortedSet(string key)
        {
            return Client.PopItemWithHighestScoreFromSortedSet(key);
        }
        /// <summary>
        /// 删除key集合中分数最小的数据
        /// </summary>
        public string PopItemWithLowestScoreFromSortedSet(string key)
        {
            return Client.PopItemWithLowestScoreFromSortedSet(key);
        }
        #endregion
        #region 其它
        /// <summary>
        /// 判断key集合中是否存在value数据
        /// </summary>
        public bool SortedSetContainsItem(string key, string value)
        {
            return Client.SortedSetContainsItem(key, value);
        }
        /// <summary>
        /// 为key集合值为value的数据，分数加scoreby，返回相加后的分数
        /// </summary>
        public double IncrementItemInSortedSet(string key, string value, double scoreBy)
        {
            return Client.IncrementItemInSortedSet(key, value, scoreBy);
        }
        /// <summary>
        /// 获取keys多个集合的交集，并把交集添加的newkey集合中，返回交集数据的总数
        /// </summary>
        public long StoreIntersectFromSortedSets(string newkey, string[] keys)
        {
            return Client.StoreIntersectFromSortedSets(newkey, keys);
        }
        /// <summary>
        /// 获取keys多个集合的并集，并把并集数据添加到newkey集合中，返回并集数据的总数
        /// </summary>
        public long StoreUnionFromSortedSets(string newkey, string[] keys)
        {
            return Client.StoreUnionFromSortedSets(newkey, keys);
        }
        #endregion
    }
}
