using System;
using System.Collections.Generic;
using FluentAssertions;
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

            Action a = () => d.GetOrDefault("abc");

            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetOrDefault_NullKey_ExceptionThrown()
        {
            var d = new Dictionary<string, string>();

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
            Action a = () => d.GetOrDefault(null);
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

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
                r.Should().Be(default);
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

            r.Should().Be(default);
        }
    }
}
