using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class VeiculoController : ControllerBase
{
    private readonly ILogger<VeiculoController> _logger;
    private readonly IVeiculoUseCases _veiculoUseCases;

    public VeiculoController(ILogger<VeiculoController> logger, IVeiculoUseCases veiculoUseCases)
    {
        _logger = logger;
        _veiculoUseCases = veiculoUseCases;
    }

    [HttpGet]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Get()
    {
        return Ok(await _veiculoUseCases.ObterVeiculosUseCaseAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Get(int id)
    {
        var vehicle = await _veiculoUseCases.ObterVeiculoUseCaseAsync(id);
        if (vehicle is null) return NotFound();
        return Ok(vehicle);
    }

    [HttpPost]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Post([FromBody] Veiculo vehicle)
    {
        if (vehicle is null) return BadRequest();
        return Ok(_veiculoUseCases.AdicionarVeiculoUseCaseAsync(vehicle));
    }

    [HttpPut]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Put([FromBody] Veiculo vehicle)
    {
        if (vehicle is null) return BadRequest();
        return Ok(_veiculoUseCases.AtualizarVeiculoUseCaseAsync(vehicle));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(int id)
    {
        _veiculoUseCases.DeletarVeiculoUseCaseAsync(id);
        return NoContent();
    }
}