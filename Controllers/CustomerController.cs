using BillingSystem.Data;
using BillingSystem.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext customerContext;

        public CustomerController(CustomerContext customerContext) 
        {
            this.customerContext = customerContext;
        }

        /* [HttpGet]
         public async Task<IActionResult> Read() 
         {
            var customers = await customerContext.Customers.ToListAsync();
             return View(customers); 
         } */


        [HttpGet]
        public IActionResult Mobile()
        {
            return View("Mobile");
        }
        [HttpPost]
        public async Task<IActionResult> Mobile( Mobile mob ) 
        {
            var Mobile = new Mobile()
            {
                number = mob.number,
                amount = mob.amount,
            };
            await customerContext.Mobile.AddAsync(Mobile);
            await customerContext.SaveChangesAsync();
            return View("CustHome");

        }

        [HttpGet]
        public IActionResult Electricity()
        {
            return View("Electricity");
        }

        [HttpPost]
        public async Task<IActionResult> Electricity(Electricity electricity)
        {
            var Electricity = new Electricity()
            {
                meternumber = electricity.meternumber,
                amount = electricity.amount,
            };
            await customerContext.Electricity.AddAsync(Electricity);
            await customerContext.SaveChangesAsync();
            return View("CustHome");

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel addCustomerRequest)
        {
            var Customers = new Customer()
            {
                FName = addCustomerRequest.FName,
                LName = addCustomerRequest.LName,
                Gender = addCustomerRequest.Gender,
                City = addCustomerRequest.City,
                Phone = addCustomerRequest.Phone,
                Email = addCustomerRequest.Email,
                Password = addCustomerRequest.Password
            };

            await customerContext.Customers.AddAsync(Customers);
            await customerContext.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        /*[HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var customer = await customerContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);

            if( customer != null)
            {
                var ViewModel = new UpdateViewModel() 
                {
                    Id = customer.Id,
                    FName = customer.FName,
                    LName = customer.LName,
                    Gender = customer.Gender,
                    City = customer.City,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Password = customer.Password
                };
                return await Task.Run(() => View("View",ViewModel));
            };
            return RedirectToAction("Index");
        }*/

        /*[HttpPost]
        public async Task<IActionResult> View(UpdateViewModel model) 
        {
            var customer = await customerContext.Customers.FindAsync(model.Id);
            if( customer != null )
            {
                customer.FName = model.FName;
                customer.LName = model.LName;
                customer.Gender = model.Gender;
                customer.City = model.City;
                customer.Phone = model.Phone;
                customer.Email = model.Email;
                customer.Password = model.Password;

                await customerContext.SaveChangesAsync();

                return RedirectToAction("Read");
            }
            return RedirectToAction("Read");

        }*/



        /* [HttpPost]
         public async Task<IActionResult> Delete(UpdateViewModel model)
         {
             var customer = await customerContext.Customers.FindAsync(model.Id);

             if( customer != null )
             {
                 customerContext.Customers.Remove(customer);
                 await customerContext.SaveChangesAsync();

                 return RedirectToAction("Read");
             }
             return RedirectToAction("Read");
         }*/

        



        [HttpGet]
        public  ActionResult Login()
        {  
            return View(); 
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login log) 
        {
            var query = await customerContext.Customers.SingleOrDefaultAsync(m => m.Email == log.Email && m.Password == log.Password);
            if (query != null) 
            {
                TempData["AlertMessage"] = "Login Successful";
                return View("CustHome");
            }
            else
            {
                TempData["AlertMessage"] = "Login Unsuccessful";
                return View("Login");
            }
        }
    }
}
 