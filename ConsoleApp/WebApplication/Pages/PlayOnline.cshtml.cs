﻿using System.Reflection.PortableExecutable;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class Start : PageModel
    {
        private readonly AppDbContext _context;

        public GameSettings Settings { get; set; } = default!;

        public Start(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                Settings = _context.Settings.Find(id);
            }
            else
            {
                Settings = _context.Settings.Find(0);
            }
        }
    }
}