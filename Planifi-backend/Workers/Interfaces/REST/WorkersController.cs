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
public class WorkersController : ControllerBase
{
    private readonly IWorkerCommandService _workerCommandService;
    private readonly IWorkerQueryService _workerQueryService;

    public WorkersController(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService)
    {
        _workerCommandService = workerCommandService;
        _workerQueryService = workerQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorker(CreateWorkerResource resource)
    {
        var createWorkerCommand = CreateWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var worker = await _workerCommandService.Handle(createWorkerCommand);
        if (worker is null) return BadRequest();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return CreatedAtAction(nameof(GetWorkerById), new {workerId = workerResource.Id}, workerResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkers()
    {
        var getAllWorkersQuery = new GetAllWorkersQuery();
        var workers = await _workerQueryService.Handle(getAllWorkersQuery);
        var workerResources = workers.Select(WorkerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(workerResources);
    }

    [HttpGet("{workerId:int}")]
    public async Task<IActionResult> GetWorkerById(int workerId)
    {
        var getWorkerByIdQuery = new GetWorkerByIdQuery(workerId);
        var worker = await _workerQueryService.Handle(getWorkerByIdQuery);
        if (worker == null) return NotFound();
        var workerResource = WorkerResourceFromEntityAssembler.ToResourceFromEntity(worker);
        return Ok(workerResource);
    }
}