﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTrials.Models;

namespace DogTrials.Pages.Stakes
{
    public class CreateModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public CreateModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stake Stake { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stakes.Add(Stake);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}