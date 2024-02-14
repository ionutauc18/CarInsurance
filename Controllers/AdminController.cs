using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;
using CarInsurance.ViewModel;


namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities1 db = new InsuranceEntities1())
            {
                var customers = db.Insurees;
                var quoteView = new List<QuoteVm>();
                foreach (var client in customers)
                {
                    var quoteVm = new QuoteVm();

                    quoteVm.Id = client.Id;
                    quoteVm.FirstName = client.FirstName;
                    quoteVm.LastName = client.LastName;
                    quoteVm.EmailAddress = client.EmailAddress;
                    quoteVm.Quote = (int)client.Quote;

                    quoteView.Add(quoteVm);
                }
                return View(quoteView);
            }

        }
    }
}