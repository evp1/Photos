using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Photo.Models;

namespace Photo.Controllers
{
    public class FoldersController : Controller
    {
        private FoldersContext db = new FoldersContext();

        // GET: Folders
        public ActionResult _IndexTable() => PartialView( db.Folders.OrderBy( x => x.FolderName ));

        public ActionResult _LayoutFolders() => View();

        // GET: Folders/Details/5
        public async Task<ActionResult> _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folders folders = await db.Folders.FindAsync(id);
            if (folders == null)
            {
                return HttpNotFound();
            }
            return PartialView( folders);
        }

        // GET: Folders/Create
        public ActionResult _Create()
        {
            var model = new Folders();
            return PartialView(model);
        }

        // POST: Folders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Create([Bind(Include = "FolderId,FolderName")] Folders folders)
        {
            if (ModelState.IsValid)
            {
                db.Folders.Add(folders);
                await db.SaveChangesAsync();
                return RedirectToAction( "_IndexTable" );
            }

            return PartialView( folders);
        }

        // GET: Folders/Edit/5
        public async Task<ActionResult> _Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folders folders = await db.Folders.FindAsync(id);
            if (folders == null)
            {
                return HttpNotFound();
            }
            return PartialView( folders);
        }

        // POST: Folders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _Edit([Bind(Include = "FolderId,FolderName")] Folders folders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folders).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction( "_IndexTable" );
            }
            return PartialView(folders);
        }

        // GET: Folders/Delete/5
        public async Task<ActionResult> _Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Folders folders = await db.Folders.FindAsync(id);
            if (folders == null)
            {
                return HttpNotFound();
            }
            return PartialView(folders);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Folders folders = await db.Folders.FindAsync(id);
            db.Folders.Remove(folders);
            await db.SaveChangesAsync();
            return RedirectToAction( "_IndexTable" );
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
