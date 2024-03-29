﻿using System;
using FluentAssertions;
using Tk.Extensions.Guards;
using Xunit;

namespace Tk.Extensions.Tests.Guards
{
    public class GuardExtensionsTests
    {
        [Fact]
        public void ArgNotNull_Null_ThrowsException()
        {
            string s = null;

            Action a = () => s.ArgNotNull(nameof(s));

            a.Should().Throw<ArgumentNullException>().WithParameterName(nameof(s));
        }

        [Fact]
        public void ArgNotNull_NotNull_ReturnsValue()
        {
            var s = "abc";
            var r = s.ArgNotNull(nameof(s));

            r.Should().Be(s);
        }

        [Fact]
        public void InvalidOpArg_Invalid_ThrowsException()
        {
            string s = null;

            Action a = () => s.InvalidOpArg(x => false, "Invalid");

            a.Should().Throw<InvalidOperationException>().WithMessage("?*");
        }

        [Fact]
        public void InvalidOpArg_NullPredicate_ThrowsException()
        {
            Action a = () => 1.InvalidOpArg(null, "invalid");

            a.Should().Throw<ArgumentNullException>().WithMessage("?*");
        }

        [Fact]
        public void InvalidOpArg_NoError_ReturnsValue()
        {
            var value = 1234;
            var r = value.InvalidOpArg(x => false, "invalid");

            r.Should().Be(value);
        }
    }
}
