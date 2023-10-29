using Microsoft.AspNetCore.Mvc;
using WrightBrothersApi.Models;

namespace WrightBrothersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;

        public PlanesController(ILogger<PlanesController> logger)
        {
            _logger = logger;
        }

        private static readonly List<Plane> planes = new List<Plane>
        {
            new Plane
            {
                Id = 1,
                Name = "Wright Flyer",
                Year = 1903,
                Description = "The first successful heavier-than-air powered aircraft."
            },
            new Plane
            {
                Id = 2,
                Name = "Wright Flyer II",
                Year = 1904,
                Description = "A refinement of the original Flyer with better performance."
            },
            new Plane
            {
                Id = 3,
                Name = "Wright Flyer III",
                Year = 1905,
                Description = "The first fully controllable Flyer."
            },
        };

        [HttpGet]
        public ActionResult<List<Plane>> Get()
        {
            return planes;
        }

        [HttpGet("{id}")]
        public ActionResult<Plane> Get(int id)
        {
            var plane = planes.Find(p => p.Id == id);

            if (plane == null)
            {
                return NotFound();
            }

            return plane;
        }

        [HttpPost]
        public ActionResult<Plane> Post(Plane plane)
        {
            planes.Add(plane);

            return CreatedAtAction(nameof(Get), new { id = plane.Id }, plane);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Plane plane)
        {
            if (id != plane.Id)
            {
                return BadRequest();
            }

            var index = planes.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            planes[index] = plane;

            return NoContent();
        }
    }
}
