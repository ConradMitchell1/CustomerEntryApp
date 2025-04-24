using CustomerEntryApp.Controllers;
using CustomerEntryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CustomerEntryApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_ValidCustomer_RedirectsToIndex()
        {
            var controller = new CustomerController();
            var customer = CreateCustomer();

            var result = controller.Add(customer) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Name_TooLong_ShouldFailValidation()
        {
            var customer = CreateCustomer(name: new string('A', 51));
            Validator(customer, "Name", "maximum length");
        }

        [Fact]
        public void Age_TooOld_ShouldFailValidation()
        {
            var customer = CreateCustomer(age: 200);
            Validator(customer, "Age", "must be between 0 and 110");
        }

        [Fact]
        public void PostCode_OnlyContainsNumbers_ShouldFailValidation()
        {
            var customer = CreateCustomer(postcode: "11111");
            Validator(customer, "Postcode", "Postcode Must contain characters and numbers.");
        }

        [Fact]
        public void PostCode_OnlyContainsLetters_ShouldFailValidation()
        {
            var customer = CreateCustomer(postcode: "abababa");
            Validator(customer, "Postcode", "Postcode Must contain characters and numbers.");
        }

        [Fact]
        public void Height_GreaterThanRange_ShouldFailValidation()
        {
            var customer = CreateCustomer(height:2.6);
            Validator(customer, "Height", "must be between 0 and 2.50");
        }
        [Fact]
        public void Add_HeightWith3DecimalPlaces_ShouldReturnModelError()
        {
            var controller = new CustomerController();

            var customer = CreateCustomer(height: 1.756);

            var result = controller.Add(customer) as ViewResult;
            Assert.NotNull(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey("Height"));
            var error = controller.ModelState["Height"].Errors.First();
            Assert.Contains("Height must have no more than 2 decimal places", error.ErrorMessage);
        }

        private static void Validator(CustomerModel customer, string expectedMember, string expectedMessage)
        {
            var context = new ValidationContext(customer);
            var results = new List<ValidationResult>();

            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(customer, context, results, true);
            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains(expectedMember) && r.ErrorMessage.Contains(expectedMessage));
        }

        private CustomerModel CreateCustomer(string name = "Test", int age = 23, double height = 1.75, string postcode = "AB22DS")
        {
            CustomerModel customer = new CustomerModel
            {
                Name = name,
                Age = age,
                Height = height,
                Postcode = postcode
            };
            return customer;
        }

    }
}