using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
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
    [Authorize(Policy = "Bearer")]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _pessoaUseCases.ObterPessoasUseCaseAsync());
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "Bearer")]
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
    [ProducesResponseType((201))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Post([FromBody] PessoaDTO pessoa)
    {
        if (pessoa is null) return BadRequest();

        await _pessoaUseCases.AdicionarPessoaUseCaseAsync(pessoa);
        return Created();
    }

    [HttpPut]
    [Authorize(Policy = "Bearer")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Put([FromBody] PessoaUpdateDTO pessoa)
    {
        if (pessoa is null) return BadRequest();

        await _pessoaUseCases.AtualizarPessoaUseCaseAsync(pessoa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "Bearer")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Delete(string id)
    {
        await _pessoaUseCases.DeletarPessoaUseCaseAsync(id);
        return NoContent();
    }
}