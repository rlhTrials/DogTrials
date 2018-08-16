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
    public class IndexModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public IndexModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public IList<Club> Club { get;set; }

        public async Task OnGetAsync()
        {
            Club = await _context.Clubs.ToListAsync();
        }
    }
}
