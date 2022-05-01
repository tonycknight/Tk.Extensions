using System;
using FluentAssertions;
using Xunit;

namespace Tk.Extensions.Tests
{
    public class GuardExtensionsTests
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
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
            string s = "abc";
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

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }
}
