using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateSearch.Models;
using CandidateSearch.Models.Candidates;

namespace CandidateSearch.Controllers.Candidates
{
    public class CandidatesController : Controller
    {
        private readonly CandidateSearchContext _context;

        public CandidatesController(CandidateSearchContext context)
        {
            _context = context;
        }

        // GET: Canidates
        public async Task<IActionResult> Index(CandidateSearchModel candidateSearchModel)
        {
            candidateSearchModel.Candidates = await candidateSearchModel.GetCandidatesFromSearch(_context).ToListAsync();
            return View(candidateSearchModel);
        }

        // GET: Canidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .FirstOrDefaultAsync(m => m.Id == id);

            if (candidate != null)
            {
                await _context.Entry(candidate).Collection(c => c.Qualifications).LoadAsync();
            }
            else
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Canidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Canidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate != null)
            {
                await _context.Entry(candidate).Collection(c => c.Qualifications).LoadAsync();
            }
            else
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Canidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // remove any deleted qualifications since they are null
                    candidate.Qualifications.RemoveAll(q => q == null);
                    // grab qualifications from the db whose id is not in the edited canidate's qualifications
                    var deletedQualifications = _context.Qualification.Where(q => !candidate.Qualifications.Any(cq => cq.Id == q.Id && cq.CandidateId == id));

                    foreach (var qualification in deletedQualifications)
                    {
                        _context.Qualification.Remove(qualification);
                    }

                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanidateExists(candidate.Id))
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
            return View(candidate);
        }

        // GET: Canidates/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canidate = await _context.Candidate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canidate == null)
            {
                return NotFound();
            }

            return View(canidate);
        }

        // POST: Canidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canidate = await _context.Candidate.FindAsync(id);
            _context.Candidate.Remove(canidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanidateExists(int id)
        {
            return _context.Candidate.Any(e => e.Id == id);
        }

        public ActionResult AddQualification()
        {
            return PartialView("_Qualification", new Qualification());
        }
    }
}
