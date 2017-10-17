using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Photo.Models;

namespace Photo.Controllers
{
    public class PicturesController : Controller
    {
        private PicturesContext db = new PicturesContext();

        // GET: Pictures
        public async Task<ActionResult> Index()
        {
            var pictures = db.Pictures.Include(p => p.Places);
            return View(await pictures.ToListAsync());
        }

        public ActionResult _LayoutPictures()
        {
            return View();
        }

        // GET: Pictures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictures pictures = await db.Pictures.FindAsync(id);
            if (pictures == null)
            {
                return HttpNotFound();
            }
            return View(pictures);
        }

        // GET: Pictures/Create
        public ActionResult _Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Placename");
            return PartialView();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Create([Bind(Include = "PictureId,PhotoDescription,DateTaken,DateCreated,PlaceId")] Pictures pictures)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Add(pictures);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Placename", pictures.PlaceId);
            return PartialView(pictures);
        }

        // GET: Pictures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictures pictures = await db.Pictures.FindAsync(id);
            if (pictures == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Placename", pictures.PlaceId);
            return View(pictures);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PictureId,PhotoDescription,DateTaken,DateCreated,PlaceId")] Pictures pictures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pictures).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Placename", pictures.PlaceId);
            return View(pictures);
        }

        // GET: Pictures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pictures pictures = await db.Pictures.FindAsync(id);
            if (pictures == null)
            {
                return HttpNotFound();
            }
            return View(pictures);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pictures pictures = await db.Pictures.FindAsync(id);
            db.Pictures.Remove(pictures);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
