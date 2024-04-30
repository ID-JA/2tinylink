using Application.UseCases.Projects.Commands;
using Application.UseCases.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpPost]
    public async Task<Guid> CreateProjectAsync(CreateProjectRequest request)
    {
        return await _sender.Send(request);
    }

    [HttpPost("invite")]
    public async Task<string> InviteToProjectAsync([FromBody] InviteToProjectRequest request)
    {
        return await _sender.Send(new InviteToProjectRequest()
        {
            Origin = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}",
            Emails = request.Emails,
            ProjectId = request.ProjectId
        });
    }

    [HttpPost("invite/{code}")]
    public async Task<bool> VerifyProjectInvitation([FromRoute] string code)
    {
        return await _sender.Send(new VerifyProjectInvitationRequest() { Code = code });
    }
}