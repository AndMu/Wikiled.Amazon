using System;
using System.Collections.Generic;
using StackExchange.Redis;
using Wikiled.Redis.Keys;
using Wikiled.Redis.Logic;
using Wikiled.Redis.Persistency;
using Wikiled.Redis.Serialization;

namespace Wikiled.Amazon.Logic
{
    public class AnalysedDocRepository : IRepository
    {
        private readonly IRedisLink manager;

        public AnalysedDocRepository(IRedisLink manager)
        {
            this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
            manager.PersistencyRegistration.RegisterHashsetSingle(new DictionarySerializer(new[] { "No" }));
        }

        public string Name => "Analysed";

        public void Save(AmazonReview amazon, Dictionary<string, RedisValue> review)
        {
            var value = new Dictionary<string, string>();
            foreach (var redisValue in review)
            {
                value[redisValue.Key] = redisValue.Value.ToString();
            }

            var dataKey = new RepositoryKey(this, new ObjectKey(amazon.Id));
            dataKey.AddIndex(new IndexKey(this, "All", false));
            manager.Client.AddRecord(dataKey, value);
        }
    }
}
