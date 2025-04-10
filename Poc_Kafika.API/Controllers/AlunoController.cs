using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc_Kafika.API.Features.Aluno.Create;
using Poc_Kafika.API.Features.Aluno.Read;
using Poc_Kafika.API.Features.Aluno.Update;
using Poc_Kafka.Application.Aluno.Create;
using Poc_Kafka.Application.Aluno.Delete;
using Poc_Kafka.Application.Aluno.Read;
using Poc_Kafka.Application.Aluno.Update;

namespace Poc_Kafika.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IMediator _mediator;
    public AlunoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlunoRequest request, CancellationToken cancellationToken)
    {
        var command = CreateAlunoCommand.Create(request.Nome, request.Disciplina, request.Nota);

        var result = await _mediator.Send(command, cancellationToken);
        if (result is null)
            return BadRequest("Erro ao Criar o Aluno!");

        var response = CreateAlunoResponse
            .Create(result.Id, result.Nome, result.Disciplina, result.Nota);

        return Created(string.Empty, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = DeleteAlunoCommand.Create(id);

        var result = await _mediator.Send(command, cancellationToken);
        if (result is null)
            return BadRequest("Erro ao Excluir o Aluno!");

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAlunoRequest request, CancellationToken cancellationToken)
    {
        var command = UpdateAlunoCommand.Create(id, request.Nome, request.Disciplina, request.Nota);

        var result = await _mediator.Send(command, cancellationToken);
        if (result is null)
            return BadRequest("Erro ao Atualizar o Aluno!");

        var response = UpdateAlunoResponse.Create(result.Id, result.Nome, result.Disciplina, result.Nota);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = GetAlunoCommand.Create(id);

        var result = await _mediator.Send(command, cancellationToken);
        if (result is null)
            return BadRequest("Erro ao Obter o Aluno!");

        var response = GetAlunoResponse
            .Create(result.Id, result.Nome, result.Disciplina, result.Nota);

        return Ok(response);
    }
}
