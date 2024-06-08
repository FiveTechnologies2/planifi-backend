using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Planifi_backend.Workers.Domain.Model.Queries;
using Planifi_backend.Workers.Domain.Services;
using Planifi_backend.Workers.Interfaces.REST.Resources;
using Planifi_backend.Workers.Interfaces.REST.Transform;

namespace Planifi_backend.Workers.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class WorkersController(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateWorker(CreateWorkerResource resource)
    {
        var createWorkerCommand = CreateWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var worker = await workerCommandService.Handle(createWorkerCommand);
        if (worker is null) return BadRequest();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return CreatedAtAction(nameof(GetWorkerById), new { workerId = workerResource.id }, workerResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkers()
    {
        var getAllWorkersQuery = new GetAllWorkersQuery();
        var worker = await workerQueryService.Handle(getWorkerByIdQuery);
        if (worker == null) return NotFound();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return Ok(workerResource);
    }
}