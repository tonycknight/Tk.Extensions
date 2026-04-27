using System;
using Shouldly;
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

            var ex = Should.Throw<ArgumentNullException>(() => s.ArgNotNull(nameof(s)));
            ex.ParamName.ShouldBe(nameof(s));
        }

        [Fact]
        public void ArgNotNull_NotNull_ReturnsValue()
        {
            var s = "abc";
            var r = s.ArgNotNull(nameof(s));

            r.ShouldBe(s);
        }

        [Fact]
        public void InvalidOpArg_Invalid_ThrowsException()
        {
            string s = null;

            Should.Throw<InvalidOperationException>(() => s.InvalidOpArg(x => false, "Invalid"));
        }

        [Fact]
        public void InvalidOpArg_NullPredicate_ThrowsException()
        {
            Should.Throw<ArgumentNullException>(() => 1.InvalidOpArg(null, "invalid"));
        }

        [Fact]
        public void InvalidOpArg_NoError_ReturnsValue()
        {
            var value = 1234;
            var r = value.InvalidOpArg(x => false, "invalid");

            r.ShouldBe(value);
        }
    }
}
