﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.BackEnd.Data;
using Sales.shared.Entities;

namespace Sales.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
            //return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutAsync(int id, Country country)
        {
            var currentCountry = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (currentCountry == null)
            {
                return NotFound();
            }
            currentCountry.Name = country.Name;
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(currentCountry);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            country.Name = country.Name;
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
