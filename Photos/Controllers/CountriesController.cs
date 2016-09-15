using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Photo.Models;

namespace Photo.Controllers
{
    public class CountriesController : Controller
    {
        private CountriesContext db = new CountriesContext();

        // GET: Countries
        public ActionResult _IndexTable()
        {
            return PartialView(db.Countries.OrderBy(x => x.Country));
        }

        public ActionResult _LayoutCountries()
        {
            return View();
        }

        // GET: Countries/Details/5
        public async Task<ActionResult> _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return PartialView(countries);
        }

        // GET: Countries/Create
        public ActionResult _Create()
        {
            var model = new Countries();
            return PartialView(model);
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Create([Bind(Include = "CountryId,Country,DateCreated")] Countries countries)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(countries);
                await db.SaveChangesAsync();
                return RedirectToAction("_IndexTable");
            }
            return  PartialView(countries);
        }

        // GET: Countries/Edit/5
        public async Task<ActionResult> _Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return PartialView(countries);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Edit([Bind(Include = "CountryId,Country,DateCreated")] Countries countries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countries).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("_IndexTable");
            }
            return PartialView(countries);
        }

        // GET: Countries/Delete/5
        public async Task<ActionResult> _Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return PartialView(countries);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Countries countries = await db.Countries.FindAsync(id);
            db.Countries.Remove(countries);
            await db.SaveChangesAsync();
            return RedirectToAction("_IndexTable");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
