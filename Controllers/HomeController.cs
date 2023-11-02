using Microsoft.AspNetCore.Mvc;
using rest.Models;
using rest.Service;

namespace rest.Controllers;

[ApiController]
[Route( "/api/homeController")]
public class HomeController : ControllerBase
{
       private readonly IHomeService _homeService;
       private readonly ILogger<HomeController> _logger;

       public HomeController(IHomeService homeService, ILogger<HomeController> logger)
       {
              _homeService = homeService;
              _logger = logger;
       }

       [HttpGet("/list")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status204NoContent)]
       public async Task<ActionResult<List<Person>>> GetListOfPersons()
       {
              var person = _homeService.GetListOfPersons();
              _logger.LogInformation("Getting list of persons!");
              if (person.Count() < 0)
                     return NoContent();
              return Ok(person);
       }

       [HttpGet("/person/{id:int}")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       public async Task<ActionResult<Person>> GetPersonById(int id)
       {
              var person = _homeService.GetPersonById(id);
              _logger.LogInformation("Get person by Id!");
              if (person is null)
                     return NotFound("Oops! person not found");
              return Ok(person);
       }

       [HttpPost("/create/")]
       [ProducesResponseType(StatusCodes.Status201Created)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       public async Task<ActionResult<Person>> AddPerson([FromBody]Person person)
       {
              if (!ModelState.IsValid)
              { 
                     return BadRequest(ModelState);
              }
              var person_ =  _homeService.AddPerson(person);
              return Ok(person_);
              
       }

       [HttpDelete("/person/{id:int}")]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [ProducesResponseType(StatusCodes.Status204NoContent)]
       public async Task<ActionResult<List<Person>>> DeletePerson(int id)
       {
              var person = _homeService.DeletePerson(id);
              if (person is null)
                     return NotFound("Oops! person not found");
              return Ok(person);
       }


}