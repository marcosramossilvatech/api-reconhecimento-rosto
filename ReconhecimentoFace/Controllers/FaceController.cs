using Microsoft.AspNetCore.Mvc;
using ReconhecimentoFace.Services;

namespace ReconhecimentoFace.Controllers
{
    [Route("api/faces")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        [HttpPost("detect")]
        public async Task<IActionResult> DetectFaces(IFormFile file,
            [FromServices] IDetectFaceService service)
        {
            var result = await service.DetectFace(file);

            return Ok(new { faceFileName = result });
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFaceResult([FromRoute] string fileName)
        {
            if (System.IO.File.Exists(fileName) is false)
                return NotFound();

            var bytes = await System.IO.File.ReadAllBytesAsync(fileName);

            return File(bytes, "image/jpeg");
        }
    }
}
