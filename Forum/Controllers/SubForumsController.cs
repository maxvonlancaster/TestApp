using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using Forum.BLL.Services.Interfaces;

namespace Forum.Controllers
{
    public class SubForumsController : Controller
    {
        private readonly ISubforumService _subforumService;

        public SubForumsController(ISubforumService subforumService)
        {
            _subforumService = subforumService;
        }

        // GET: SubForums
        public async Task<IActionResult> Index()
        {
            return View(await _subforumService.Get());
        }

        // GET: SubForums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subForum = await _subforumService.Get((int)id);
            if (subForum == null)
            {
                return NotFound();
            }

            return View(subForum);
        }

        // GET: SubForums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubForums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubForumId,Name,Description,Picture")] SubForum subForum)
        {
            if (ModelState.IsValid)
            {
                await _subforumService.Add(subForum);
                return RedirectToAction(nameof(Index));
            }
            return View(subForum);
        }

        // GET: SubForums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subForum = await _subforumService.Get((int)id);
            if (subForum == null)
            {
                return NotFound();
            }
            return View(subForum);
        }

        // POST: SubForums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubForumId,Name,Description,Picture")] SubForum subForum)
        {
            if (id != subForum.SubForumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _subforumService.Update(subForum);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_subforumService.SubForumExists(subForum.SubForumId))
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
            return View(subForum);
        }

        // GET: SubForums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subForum = await _subforumService.Get((int)id);
            if (subForum == null)
            {
                return NotFound();
            }

            return View(subForum);
        }

        // POST: SubForums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subforumService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
