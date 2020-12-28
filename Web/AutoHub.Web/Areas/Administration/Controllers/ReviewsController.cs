namespace AutoHub.Web.Areas.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoHub.Data;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Services.Data;
    using AutoHub.Web.Areas.Administration.Controllers;
    using AutoHub.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ReviewsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;
        private readonly IWebHostEnvironment environment;
        private readonly IReviewsService reviewService;

        public ReviewsController(
            IDeletableEntityRepository<Review> reviewsRepository,
            IWebHostEnvironment environment,
            IReviewsService reviewService)
        {
            this.reviewsRepository = reviewsRepository;
            this.environment = environment;
            this.reviewService = reviewService;
        }

        // GET: Administration/Reviews
        public async Task<IActionResult> Index()
        {
            return this.View(await this.reviewsRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Administration/Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var review = await this.reviewsRepository.AllAsNoTracking()
                .Include(x => x.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return this.NotFound();
            }

            return this.View(review);
        }

        // GET: Administration/Reviews/Create

        public IActionResult Create()
        {
            var inputModel = new AddReviewInputModel();
            return this.View(inputModel);
        }

        // POST: Administration/Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddReviewInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var imagePath = this.environment.WebRootPath;

            await this.reviewService.CreateAsync(inputModel, imagePath, userId);

            return this.RedirectToAction("Index");
        }

        // GET: Administration/Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var review = this.reviewsRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            if (review == null)
            {
                return this.NotFound();
            }

            return this.View(review);
        }

        // POST: Administration/Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,VideoUrl,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Review review)
        {
            if (id != review.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.reviewsRepository.Update(review);
                    await this.reviewsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ReviewExists(review.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(this.Index));
            }
            return this.View(review);
        }

        // GET: Administration/Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var review = await this.reviewsRepository.AllAsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return this.NotFound();
            }

            return this.View(review);
        }

        // POST: Administration/Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review =  this.reviewsRepository.AllAsNoTracking().FirstOrDefault(x=> x.Id == id);
            this.reviewsRepository.Delete(review);
            await this.reviewsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReviewExists(int id)
        {
            return this.reviewsRepository.AllAsNoTracking().Any(e => e.Id == id);
        }
    }
}
