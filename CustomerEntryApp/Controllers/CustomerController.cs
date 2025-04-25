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
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (decimal.Round((decimal)updatedCustomer.Height, 2) != (decimal)updatedCustomer.Height)
                {
                    ModelState.AddModelError("Height", "Height must have no more than 2 decimal places.");
                    return View("Edit", updatedCustomer);
                }
                customer.Name = updatedCustomer.Name;
                customer.Age = updatedCustomer.Age;
                customer.Height = updatedCustomer.Height;
                customer.Postcode = updatedCustomer.Postcode;

                return RedirectToAction("Index");
            }
            return View("Edit", updatedCustomer);
        }
        [HttpPost]
        public IActionResult Add(CustomerModel customer)
        {
            
            if (ModelState.IsValid)
            {
                if (decimal.Round((decimal)customer.Height, 2) != (decimal)customer.Height)
                {
                    ModelState.AddModelError("Height", "Height must have no more than 2 decimal places.");
                    return View("Add", customer);
                }
                customer.Id = Guid.NewGuid();
                _customers.Add(customer);
                return RedirectToAction("Index");
            }

            return View("Add", customer);
                     
        }
    }


    
}
