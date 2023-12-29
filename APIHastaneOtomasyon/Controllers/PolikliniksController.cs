using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIHastaneOtomasyon.Data;
using APIHastaneOtomasyon.Models;

namespace APIHastaneOtomasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolikliniksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PolikliniksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Polikliniks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliklinik>>> Getpolikliniks()
        {
          if (_context.polikliniks == null)
          {
              return NotFound();
          }
            return await _context.polikliniks.ToListAsync();
        }

       

       
    }
}
