using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageChartController : ControllerBase
    {
        private readonly BeadevContext _context;
        public ProgrammingLanguageChartController(BeadevContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetTopThree()
        {
            try
            {

                var top3 = await _context.Statistics.GroupBy(x => x.ProgrammLangID)
                    .Where(g => g.Count() > 0)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .OrderByDescending(r => r.Counter)
                    .Take(3)
                    .ToListAsync();

                var test1 = await _context.Statistics
                   .Where(x => x.ProgrammLangID == top3[0].Element)
                   .OrderBy(u => u.MonthID)
                   .ToListAsync();

                var test2 = await _context.Statistics
                    .Where(x => x.ProgrammLangID == top3[1].Element)
                    .OrderBy(u => u.MonthID)
                    .ToListAsync();



                var test3 = await _context.Statistics
                    .Where(x => x.ProgrammLangID == top3[2].Element)
                    .OrderBy(u => u.MonthID)
                    .ToListAsync();


                var finalResult = new
                {
                    a01 = test1,
                    a02 = test2,
                    a03 = test3,
                };

                return finalResult != null ? Ok(finalResult) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}