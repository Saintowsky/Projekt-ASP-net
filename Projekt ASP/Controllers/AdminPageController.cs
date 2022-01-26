using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Data;
using Projekt_ASP.Models;


namespace Projekt_ASP.Controllers
{
    [Authorize]
    public class AdminPageController : Controller
    {
        private readonly ImageDbContext _context;
        private readonly AuthDbContext ___context;
        private readonly IWebHostEnvironment ___hostEnvironment;

        public AdminPageController(AuthDbContext context, ImageDbContext ImageContext, IWebHostEnvironment hostEnvironment)
        {
            ___context = context;
            _context = ImageContext;
            this.___hostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> ShowPosts()
        {
            return View(await _context.Images.ToListAsync());
        }

        public async Task<IActionResult> UserDetails(string id)
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
        public async Task<IActionResult> DeleteUser(string id)
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
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDeleteConfirmed(string id)
        {

            var ApplicationUser = await ___context.Users.FindAsync(id);

            //Delete the record
            ___context.Users.Remove(ApplicationUser);
            await ___context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Images

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var imageModel = await _context.Images.FindAsync(id);

            //Delete image from images folder
            var imagePath = Path.Combine(___hostEnvironment.WebRootPath, "image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //Delete the record
            _context.Images.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowPosts));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        public async Task<IActionResult> Show(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Images.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,Title,ImageName,Author")] ImageModel imageModel)
        {
            if (id != imageModel.ImageID)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.ImageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

    }
}
