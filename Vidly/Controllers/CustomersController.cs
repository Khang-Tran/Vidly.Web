using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        private IEnumerable<Customers> _customers;
        // GET: Customers
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            if (_context != null)
                _customers = _context.CustomerSet.Include(c => c.MembershipTypes).ToList();
        }
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                id = 1;
            var selectedCustomer = _customers.FirstOrDefault(c => c.Id == id);
            if (selectedCustomer == null)
                return HttpNotFound();
            return View(selectedCustomer);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypeSet.ToList();
            var customerView = new CustomersViewModel() { Customers = new Customers(), MembershipTypes = membershipTypes };
            return View("CustomerForm", customerView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomersViewModel()
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypeSet.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customers.Id == 0) 
                _context.CustomerSet.Add(customers);
            else
            {
                var existedCustomer = _context.CustomerSet.Single(c => c.Id == customers.Id);
                existedCustomer.Name = customers.Name;
                existedCustomer.BirthDate = customers.BirthDate;
                existedCustomer.IsSubscribeToLetter = customers.IsSubscribeToLetter;
                existedCustomer.MembershipTypesId = customers.MembershipTypesId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var selectedCustomer = _context.CustomerSet.SingleOrDefault(c => c.Id == id);
            if (selectedCustomer == null)
                return HttpNotFound();
            var viewModel = new CustomersViewModel()
            {
                Customers = selectedCustomer,
                MembershipTypes = _context.MembershipTypeSet.ToList()
        };

            return View("CustomerForm", viewModel);
    }
}
}