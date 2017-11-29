using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using Wikiled.Redis.Logic;

namespace Wikiled.Amazon.Tests
{
    [SetUpFixture]
    public class Global
    {
        private RedisProcessManager manager;

        [OneTimeSetUp]
        public void Setup()
        {
            manager = new RedisProcessManager();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", ConfigurationManager.AppSettings["redis"]);
            manager.Start(path);
        }

        [OneTimeTearDown]
        public void Clean()
        {
            manager.Dispose();
        }
    }
}
