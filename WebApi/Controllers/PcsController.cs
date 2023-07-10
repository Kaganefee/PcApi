using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PcsController : ControllerBase
    {
        IPcService _pcService;

        public PcsController(IPcService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _pcService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _pcService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Pc pc)
        {
            var result = _pcService.Add(pc);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var item = _pcService.GetById(id);
            var result =_pcService.Delete(item.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
