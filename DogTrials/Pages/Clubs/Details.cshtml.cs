using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Clubs
{
    public class DetailsModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public DetailsModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = await _context.Clubs.SingleOrDefaultAsync(m => m.ID == id);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
