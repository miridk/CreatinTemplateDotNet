using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_CRUD_Template_dotnet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly DataContext _context;

        public TemplateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Template>>> Get()
        {
            return Ok(await _context.Templates.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> Get(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template == null)
                return BadRequest("Template not found!");
            return Ok(template);
        }

        [HttpPost]
        public async Task<ActionResult<List<Template>>> AddTemplate(Template template)
        {
            _context.Templates.Add(template);
            await _context.SaveChangesAsync();
            return Ok(await _context.Templates.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Template>>> UpdateTemplate(Template request)
        {
            var dbtemplate = await _context.Templates.FindAsync(request.Id);
            if (dbtemplate == null)
                return BadRequest("Template not found!");

            dbtemplate.Name = request.Name;
            dbtemplate.FirstName = request.FirstName;
            dbtemplate.LastName = request.LastName;
            dbtemplate.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Templates.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Template>>> DeleteTemplate(int id)
        {
            var dbtemplate = await _context.Templates.FindAsync(id);
            if (dbtemplate == null)
                return BadRequest("Template not found!");

            _context.Templates.Remove(dbtemplate);
            await _context.SaveChangesAsync();
            return Ok(await _context.Templates.ToListAsync());
        }


    }
}
