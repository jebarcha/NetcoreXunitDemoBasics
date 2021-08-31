using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests
{
    public class NamesTests
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Jesus", "Barajas");
            Assert.Equal("Jesus barajas".ToLower(), result.ToLower(), ignoreCase: true);
            Assert.Equal("Jesus barajas", result, ignoreCase: true);
            Assert.Contains("jesus", result, StringComparison.InvariantCultureIgnoreCase);

            // Use regular expression
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            names.NickName = "Jesus";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Jesus", "Barajas");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
