using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Photo.Models;
using System.Linq;

namespace Photo.Controllers
{
    public class PlacesController : Controller
    {
        private PlacesContext db = new PlacesContext();

        // GET: Places
        public ActionResult _IndexTable()
        {
            var places = db.Places.Include(p => p.Countries);
            return PartialView( places.ToList().OrderBy(x => x.Placename));
        }

        public ActionResult _LayoutPlaces()
        {
            return View();
        }

        // GET: Places/Details/5
        public async Task<ActionResult> _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Places places = await db.Places.FindAsync(id);

            if (places == null)
            {
                return HttpNotFound();
            }

            return PartialView(places);
        }

        // GET: Places/_Create
        public ActionResult _Create()
        {
            var model = new Places();
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Country");
            return PartialView(model);
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Create([Bind(Include = "PlaceId,Placename,Latitude,Longitude,DateCreated,CountryId")] Places Places)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(Places);
                await db.SaveChangesAsync();
                return RedirectToAction("_IndexTable");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Country", Places.CountryId);
            return PartialView(Places);
        }

        // GET: Places/Edit/5
        public async Task<ActionResult> _Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Places places = await db.Places.FindAsync(id);
            if (places == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Country", places.CountryId);
            return PartialView(places);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Edit([Bind(Include = "PlaceId,Placename,Latitude,Longitude,DateCreated,CountryId")] Places places)
        {
            if (ModelState.IsValid)
            {
                db.Entry(places).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("_IndexTable");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Country", places.CountryId);
            return View(places);
        }

        // GET: Places/Delete/5
        public async Task<ActionResult> _Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Places places = await db.Places.FindAsync(id);
            if (places == null)
            {
                return HttpNotFound();
            }
            return PartialView(places);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Places places = await db.Places.FindAsync(id);
            db.Places.Remove(places);
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
