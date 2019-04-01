using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membership = _context.MembershipTypes.ToList();


            var viewmodel = new CustomerFormViewModel(new Customers())
            {
                
                MembershipTypes=membership
              
            };
            return View("CustomerForm",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }

            if (customer.Id == 0)
                {
                    _context.Customerses.Add(customer);
                }

                else
                {
                    var customerInDb = _context.Customerses.Single(c => c.Id == customer.Id);

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                    customerInDb.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Customer");
            }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {

            var customer = _context.Customerses.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                return View(customer);
            }

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customerses.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
              else
            {
                var viewmodel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewmodel);
            }
           
        }
    }
}