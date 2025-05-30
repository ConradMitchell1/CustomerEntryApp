using CustomerEntryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerEntryApp.Controllers
{
    public class CustomerController : Controller
    {
        private static List<CustomerModel> _customers = new();

        public IActionResult Index()
        {
            return View(_customers);
        }
        public CustomerController()
        {

            //Added an example customer for viewing purposes
            if (!_customers.Any())
            {
                _customers.Add(new CustomerModel { Name = "Conrad", Age = 23, Height = 1.77, Postcode = "DT11NT" });
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); 
            }
            return View("Edit", customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel updatedCustomer)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);
            if (customer == null)
            {
                TempData["Message"] = "Customer not found.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid || decimal.Round((decimal)updatedCustomer.Height, 2) != (decimal)updatedCustomer.Height)
            {
                TempData["Message"] = "Failed to update customer. Please check input.";
                return RedirectToAction("Index");
            }

            customer.Name = updatedCustomer.Name;
            customer.Age = updatedCustomer.Age;
            customer.Height = updatedCustomer.Height;
            customer.Postcode = updatedCustomer.Postcode;

            TempData["Message"] = "Customer updated successfully!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Add(CustomerModel customer)
        {

            if (!ModelState.IsValid || decimal.Round((decimal)customer.Height, 2) != (decimal)customer.Height)
            {
                TempData["Message"] = "Failed to add customer. Please check input.";
                return RedirectToAction("Index");
            }

            customer.Id = Guid.NewGuid();
            _customers.Add(customer);

            TempData["Message"] = "Customer added successfully!";
            return RedirectToAction("Index");

        }
    }


    
}
