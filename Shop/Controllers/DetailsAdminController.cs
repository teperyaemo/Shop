using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    public class DetailsAdminController : Controller
    {
        private readonly AppDBContent _context;
        private readonly IAllDetails _allDetails;
        private readonly IDetailCharecs _detailCharecs;

        public DetailsAdminController(AppDBContent context, IAllDetails iallDetails, IDetailCharecs detailCharecs)
        {
            _context = context;
            _allDetails = iallDetails;
            _detailCharecs = detailCharecs;
        }

        public IActionResult Index(string currCategory, string searchString)
        {
            IEnumerable<Detail> details = _allDetails.getVisibleDetails;

            // Use LINQ to get list of genres.
            var categoryQuery = _context.Category.Select(a => new SelectListItem()
            {
                Value = a.categoryId.ToString(),
                Text = a.categoryName
            }).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                details = _allDetails.getVisibleDetails.Where(s => s.detailName!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(currCategory))
            {
                //details = details.Where(x => x.categoryId == int.Parse(detailCategory.Value));
                details = _allDetails.getVisibleDetails.Where(i => i.Category.categoryId == int.Parse(currCategory));
            }

            var detailsVM = new DetailsListViewModel
            {
                currCategory = currCategory,
                Categories = categoryQuery,
                allDetails = details
            };

            return View(detailsVM);
        }

        public IActionResult DetailReview(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = _allDetails.getObjectDetail(id);
            if (detail == null)
            {
                return NotFound();
            }
            var OneDetailVM = new OneDetailViewModel
            {
                Detail = detail,
                DetailCharacteristics = _detailCharecs.DetailCharacteristics(id)
            };

            return View(OneDetailVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("detailId,categoryId,detailName,model,gost,drawingNumber,description,visible")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("detailId,categoryId,detailName,model,gost,drawingNumber,description,visible")] Detail detail)
        {
            if (id != detail.detailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(detail.detailId))
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
            return View(detail);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.detailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Detail.FindAsync(id);
            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Detail.Any(e => e.detailId == id);
        }
    }
}
