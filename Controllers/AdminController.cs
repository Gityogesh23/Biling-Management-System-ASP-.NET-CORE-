using BillingSystem.Data;
using BillingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly CustomerContext customerContext;

        public AdminController(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        [HttpGet]
        public async Task<IActionResult> ReadData()
        {
            var customers = await customerContext.Customers.ToListAsync();
            return View(customers);
        }


        [HttpGet]
        public ActionResult LoginAd()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LoginAd(LoginAd log)
        {
            var query = await customerContext.Admins.SingleOrDefaultAsync(m => m.Email == log.Email && m.Password == log.Password);
            if (query != null)
            {
                TempData["AlertMessage"] = "Login Successful";
                return RedirectToAction("ReadData");
            }
            else
            {
                TempData["AlertMessage"] = "Login Unsuccessful";
                return View("LoginAd");
            }
        }



       [HttpGet]
        public async Task<IActionResult> ViewData(int Id)
        {
            var customer = await customerContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);

            if (customer != null)
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
                return await Task.Run(() => View("ViewData", ViewModel));
            };
            return RedirectToAction("Index");
        }

         [HttpPost]
                public async Task<IActionResult> ViewData(UpdateViewModel model)
                {
                    var customer = await customerContext.Customers.FindAsync(model.Id);
                    if (customer != null)
                    {
                        customer.FName = model.FName;
                        customer.LName = model.LName;
                        customer.Gender = model.Gender;
                        customer.City = model.City;
                        customer.Phone = model.Phone;
                        customer.Email = model.Email;
                        customer.Password = model.Password;

                        await customerContext.SaveChangesAsync();

                        return RedirectToAction("ReadData");
                    }
                    return RedirectToAction("ReadData");

                }

        [HttpGet]
        public IActionResult Adder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adder(AdminViewmodel adminViewmodel)
        {
            var admin = new AdminModel()
            {
                FiName = adminViewmodel.FiName,
                LaName = adminViewmodel.LaName,
                EmployeeId = adminViewmodel.EmployeeId,
                Email = adminViewmodel.Email,
                Password = adminViewmodel.Password


            };
            await customerContext.Admins.AddAsync(admin);
            await customerContext.SaveChangesAsync();
            return RedirectToAction("Adder");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateViewModel model)
        {
            var customer = await customerContext.Customers.FindAsync(model.Id);

            if (customer != null)
            {
                customerContext.Customers.Remove(customer);
                await customerContext.SaveChangesAsync();

                return RedirectToAction("ReadData");
            }
            return RedirectToAction("ReadData");
        }
    }   
    
}
