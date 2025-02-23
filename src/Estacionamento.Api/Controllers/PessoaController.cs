using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

public class PessoaController : ControllerBase
{
    private readonly ILogger<PessoaController> _logger;
    private readonly IPessoaUseCases _pessoaUseCases;

    public PessoaController(ILogger<PessoaController> logger, IPessoaUseCases pessoaUseCases)
    {
        _logger = logger;
        _pessoaUseCases = pessoaUseCases;
    }

    [HttpGet]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _pessoaUseCases.ObterPessoasUseCaseAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Get(string id)
    {
        var person = await _pessoaUseCases.ObterPessoaUseCaseAsync(id);
        if (person is null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Post([FromBody] Pessoa pessoa)
    {
        if (pessoa is null) return BadRequest();
        return Ok(_pessoaUseCases.AdicionarPessoaUseCaseAsync(pessoa));
    }

    [HttpPut]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Put([FromBody] Pessoa pessoa)
    {
        if (pessoa is null) return BadRequest();
        return Ok(_pessoaUseCases.AtualizarPessoaUseCaseAsync(pessoa));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(string id)
    {
        _pessoaUseCases.DeletarPessoaUseCaseAsync(id);
        return NoContent();
    }
}