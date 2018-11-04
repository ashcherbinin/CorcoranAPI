using System;
using System.Collections;
using System.Threading.Tasks;
using CorcoranAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CorcoranAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {

        private readonly IPresidentRepository _repository;

        public ValuesController(IPresidentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] bool descending = false)
        {
            IEnumerable response = null; 

            try{

                response = await _repository.getPresidentList(descending);
                return Ok(response);
            }
            catch(Exception e){

                return BadRequest(e.Message);

            }
        } 
     }
}
