using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        private IImageService _ımageService;
        private IWebHostEnvironment _hostEnvironment;

        public ImagesController(IImageService imageService, IWebHostEnvironment hostEnvironment)
        {
            _ımageService = imageService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ımageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ımageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbypcid")]
        public IActionResult GetImagesByPcId(int id)
        {
            var result = _ımageService.GetImageByPcId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        
        [HttpPost("add")]
        public IActionResult Add([FromForm] Image image)
        {
            var result = _ımageService.Add(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var item = _ımageService.GetById(id);
            var result = _ımageService.Delete(item.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update( [FromForm(Name = ("Id"))] int Id)
        {
            var selectedImage = _ımageService.GetById(Id).Data;
            var result = _ımageService.Update( selectedImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
