using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

[ApiController]
[Authorize(Policy = "Bearer")]
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

    [HttpGet("quantidade-veiculos")]
    [ProducesResponseType((200))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> GetVehicleQuantity()
    {
        return Ok(await _veiculoUseCases.ObterQuantidadeVeiculosCadastradosUseCaseAsync());
    }

    [HttpPost]
    [ProducesResponseType((201))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Post([FromBody] VeiculoInsertDTO vehicle)
    {
        if (vehicle is null) return BadRequest();
        var result = await _veiculoUseCases.AdicionarVeiculoUseCaseAsync(vehicle);
        return result ? Created() : BadRequest("Usuário já possui um veículo cadastrado");
    }

    [HttpPut]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Put([FromBody] VeiculoUpdateDTO vehicle)
    {
        if (vehicle is null) return BadRequest();
        await _veiculoUseCases.AtualizarVeiculoUseCaseAsync(vehicle);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public async Task<IActionResult> Delete(int id)
    {
        await _veiculoUseCases.DeletarVeiculoUseCaseAsync(id);
        return NoContent();
    }
}