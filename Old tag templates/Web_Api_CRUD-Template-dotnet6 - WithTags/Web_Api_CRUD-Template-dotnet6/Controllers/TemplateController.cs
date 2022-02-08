using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TAG_{'modelName'}.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TAG_{'modelName'}Controller : ControllerBase
    {
        private readonly DataContext _context;

        public TAG_{'modelName'}Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TAG_{'modelName'}>>> Get()
        {
            return Ok(await _context.TAG_{'modelName'}.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TAG_{'modelName'}>> Get(int id)
        {
            var TAG_{'modelNameToLower'} = await _context.TAG_{'modelName'}s.FindAsync(id);
            if (TAG_{'modelNameToLower'} == null)
                return BadRequest("TAG_{'modelName'} not found!");
            return Ok(TAG_{'modelNameToLower'});
        }

        [HttpPost]
        public async Task<ActionResult<List<TAG_{'modelName'}>>> AddTAG_{'modelName'}(TAG_{'modelName'} TAG_{'modelNameToLower'})
        {
            _context.TAG_{'modelName'}s.Add(TAG_{'modelNameToLower'});
            await _context.SaveChangesAsync();
            return Ok(await _context.TAG_{'modelName'}s.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TAG_{'modelName'}>>> UpdateTAG_{'modelName'}(TAG_{'modelName'} request)
        {
            var dbTAG_{'modelNameToLower'} = await _context.TAG_{'modelName'}s.FindAsync(request.Id);
            if (dbTAG_{'modelNameToLower'} == null)
                return BadRequest("TAG_{'modelName'} not found!");

            dbTAG_{'modelNameToLower'}.Name = request.Name;
            dbTAG_{'modelNameToLower'}.FirstName = request.FirstName;
            dbTAG_{'modelNameToLower'}.LastName = request.LastName;
            dbTAG_{'modelNameToLower'}.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.TAG_{'modelName'}s.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TAG_{'modelName'}>>> DeleteTAG_{'modelName'}(int id)
        {
            var dbTAG_{'modelNameToLower'} = await _context.TAG_{'modelName'}s.FindAsync(id);
            if (dbTAG_{'modelNameToLower'} == null)
                return BadRequest("TAG_{'modelName'} not found!");

            _context.TAG_{'modelName'}s.Remove(dbTAG_{'modelNameToLower'});
            await _context.SaveChangesAsync();
            return Ok(await _context.TAG_{'modelName'}s.ToListAsync());
        }


    }
}
