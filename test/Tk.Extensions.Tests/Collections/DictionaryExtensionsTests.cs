using System;
using System.Collections.Generic;
using Shouldly;
using Tk.Extensions.Collections;
using Xunit;

namespace Tk.Extensions.Tests.Collections
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void GetOrDefault_NullValues_ExceptionThrown()
        {
            Dictionary<string, string> d = null;

            Should.Throw<ArgumentNullException>(() => d.GetOrDefault("abc"));
        }

        [Fact]
        public void GetOrDefault_NullKey_ExceptionThrown()
        {
            var d = new Dictionary<string, string>();

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
            Should.Throw<ArgumentNullException>(() => d.GetOrDefault(null));
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
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
                r.ShouldBe(keyValue);
            }
            else
            {
                r.ShouldBe(default);
            }
        }

        [Theory]
        [InlineData("a", "b")]
        [InlineData("a", "c")]
        public void GetOrDefault_DictionaryQueried_ReturnsNull(string key, string testKey)
        {
            var keyValue = Guid.NewGuid().ToString();
            var d = new Dictionary<string, string>()
            {
                { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                { key, keyValue }
            };

            var r = d.GetOrDefault(testKey);

            r.ShouldBe(default);
        }
    }
}
