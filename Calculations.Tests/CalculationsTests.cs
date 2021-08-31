using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests
{
    public class CalculatorFixture : IDisposable
    {
        public ConsoleApp1.Calculations Calc => new ConsoleApp1.Calculations();

        public void Dispose()
        {
            // Clean
        }
    }

    public class CalculationsTests : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream memoryStream;
        private readonly ITestOutputHelper _testOutputHelper;
        public CalculationsTests(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Constructor");
            _calculatorFixture = calculatorFixture;

            memoryStream = new MemoryStream();
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            // Arrange
            var calculator = _calculatorFixture.Calc;

            // Act
            var result = calculator.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calculator = _calculatorFixture.Calc;
            var result = calculator.AddDouble(1.2, 3.55);
            Assert.Equal(4.7, result, 0);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboIsNotZero()
        {
            _testOutputHelper.WriteLine("CheckFiboIsNotZero");
            var calc = _calculatorFixture.Calc;
            Assert.All(calc.FiboList, n => Assert.NotEqual(0, n));
        }
        [Fact]
        [Trait("Category", "Fibo")]
        public void Check13Exists()
        {
            _testOutputHelper.WriteLine("Check13Exists");
            var calc = _calculatorFixture.Calc;
            Assert.Contains(13, calc.FiboList);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotInclude4()
        {
            var calc = _calculatorFixture.Calc;
            Assert.DoesNotContain(4, calc.FiboList);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine("CheckCollection. Test Startubg at {0}", DateTime.Now);

            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calc = _calculatorFixture.Calc;

            Assert.Equal(expectedCollection, calc.FiboList);
        }

        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
