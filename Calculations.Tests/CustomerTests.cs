using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void Customer_NameIsNotEmpty()
        {
            //var customer = new Customer();
            var customer = _customerFixture.Cust;

            Assert.NotNull(customer.Name);
            Assert.NotEmpty(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void Customer_AgeRangeBetween18And50()
        {
            var customer = _customerFixture.Cust;
            Assert.InRange(customer.Age, 18, 50);
        }

        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = _customerFixture.Cust;
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GetOrderByName(null));
            Assert.Equal("Name should not be null or empty", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(110);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
        

    }
}
