using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tk.Extensions.Tests
{
    public class DictionaryExtensionsTests
    {
        // guards for null values/key
        // key exists
        // key does not exist

        [Fact]
        public void GetOrDefault_NullValues_ExceptionThrown()
        {
            Dictionary<string, string> d = null;

            Action a = () => d.GetOrDefault("abc");

            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetOrDefault_NullKey_ExceptionThrown()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            Action a = () => d.GetOrDefault(null);

            a.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("a", "a")]
        [InlineData("a", "b")]
        public void GetOrDefault_DictionaryQueried_ReturnsExpected(string key, string testKey)
        {
            var keyValue = Guid.NewGuid().ToString();
            var d = new Dictionary<string, string>()
            {
                { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                { key, keyValue }
            };

            var r = d.GetOrDefault(testKey);

            if (key == testKey) 
            {
                r.Should().Be(keyValue);
            }
            else
            {
                r.Should().Be(default(String));
            }
            
        
        }
        

    }
}
