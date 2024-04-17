using Application.UseCases.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(ISender _sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetUserProjects()
    {
        return Ok(await _sender.Send(new GetProjectsByUserQuery()));
    }
}