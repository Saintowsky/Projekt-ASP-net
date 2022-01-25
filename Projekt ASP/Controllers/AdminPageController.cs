using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Data;

namespace Projekt_ASP.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly AuthDbContext ___context;
        private readonly IWebHostEnvironment ___hostEnvironment;

        public AdminPageController(AuthDbContext context, IWebHostEnvironment hostEnvironment)
        {
            ___context = context;
            this.___hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await ___context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        public async Task<IActionResult> ShowPosts(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await ___context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }
        public async Task<IActionResult> Index()
        {
            return View(await ___context.Users.ToListAsync());
        }
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await ___context.Users
                .FirstOrDefaultAsync(n => n.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }
        private bool ImageModelExists(int id)
        {
            return ___context.Users.Any(e => Convert.ToInt32(e.Id) == id);
        }

        
        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var ApplicationUser = await ___context.Users.FindAsync(id);

            //Delete the record
            ___context.Users.Remove(ApplicationUser);
            await ___context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
