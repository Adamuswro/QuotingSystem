using QuotingSystem.DAL;
using QuotingSystem.Models;
using QuotingSystem.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuotingSystem.Controllers
{
    public class QuotesController : Controller
    {
        [HttpGet]
        public ActionResult Delete (int? id, bool? saveChangesError = false)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();

            Quote quote = db.Quotes.Find(id);
            if (quote==null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();

            try
            {
                Quote quote = db.Quotes.Find(id);
                db.Quotes.Remove(quote);
                db.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            TempData["QuoteAdded"] = "Quote succesfully removed.";
            return RedirectToAction("Index");
        }

        public ActionResult Details (int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();
            Quote quote = db.Quotes.Find(id);

            if (quote==null)
            {
                return HttpNotFound();
            }

            return View(quote);
        }

        public ActionResult Index(int? pageNumber)
        {
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();
            IEnumerable<Quote> quotes = db.Quotes.ToList();

            int pageSize = 10;
            return View(PaginateList<Quote>.Create(quotes, pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        [HttpGet]
        public ActionResult CreateQuote(int? minPN, int? minTemp)
        {
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();
            var filteredProducts = db.Products.ToList();
            if (minPN!=null)
                filteredProducts = filteredProducts.Where(p => p.PN >= minPN).ToList();
            if (minTemp != null)
                filteredProducts = filteredProducts.Where(p => p.Temp>= minTemp).ToList();

            Product PrefferedProduct = filteredProducts.OrderBy(p => p.Price).FirstOrDefault();

            CreateQuoteViewModel vm = new CreateQuoteViewModel(minPN, minTemp, filteredProducts, PrefferedProduct, db.Customers.ToList());

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult CreateQuote(CreateQuoteViewModel quote)
        {
            if (!ModelState.IsValid)
            {
                //TODO: Check what should be returned in case of wrong input
                return View("CreateQuote", quote);
            }
            QuotingSystemDbEntities db = new QuotingSystemDbEntities();

            var newQuote = new Quote() { 
                SelectedCustomer=db.Customers.Find(quote.SelectedCustomerId),
                SelectedProduct=db.Products.Find(quote.SelectedProductId)
            };

            db.Quotes.Add(newQuote);
            db.SaveChanges();
            TempData["QuoteAdded"] = $"New quote (Id: {newQuote.QuoteId}) successfully added!";

            return RedirectToAction("Index");
        }
    }
}