using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

public class PessoaController : ControllerBase
{
    private readonly ILogger<PessoaController> _logger;

    public PessoaController(ILogger<PessoaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);
        if (person is null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Post([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}