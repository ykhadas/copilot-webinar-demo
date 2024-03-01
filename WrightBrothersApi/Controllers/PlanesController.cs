using Microsoft.AspNetCore.Mvc;
using WrightBrothersApi.Models;
using WrightBrothersApi.UseCases;

namespace WrightBrothersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;
        private readonly IPlanesUseCase _planesUseCase;

        public PlanesController(ILogger<PlanesController> logger, IPlanesUseCase useCase)
        {
            _logger = logger;
            _planesUseCase = useCase;
        }

        [HttpGet("{id}")]
        public ActionResult<Plane> Get(int id)
        {
            var plane = _planesUseCase.GetPlane(id);

            if (plane == null)
            {
                return NotFound();
            }

            return plane;
        }

        [HttpGet]
        public ActionResult<List<Plane>> Get()
        {
            return _planesUseCase.GetPlanes();
        }

        [HttpPost]
        public ActionResult<Plane> Post(Plane plane)
        {
            _planesUseCase.AddPlane(plane);

            return CreatedAtAction(nameof(Get), new { id = plane.Id }, plane);
        }





   }
}