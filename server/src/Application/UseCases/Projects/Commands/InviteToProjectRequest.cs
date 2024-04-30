using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Ardalis.Specification;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Projects.Commands;

public class InviteToProjectRequest : IRequest<string>
{
    public List<string> Emails { get; set; }
    public string Origin { get; set;}
    public Guid ProjectId { get; set; }
}

public class InviteToProjectRequestHandler(
    IMailService _mailService,
    UserManager<AppUser> _userManager,
    IAppDbContext _appDbContext) : IRequestHandler<InviteToProjectRequest, string>
{
    public async Task<string> Handle(InviteToProjectRequest request, CancellationToken cancellationToken)
    {
        var result =
            await _appDbContext.Projects
                .Where(x => x.Id.Equals(request.ProjectId))
                .Select(x => new { x.InviteCode, x.Name })
                .FirstOrDefaultAsync(cancellationToken);
        
        if (result is null) return "No project was found";

        foreach (var email in request.Emails)
        {
                await _mailService.SendProjectInvitation(email,
                    result.Name,
                    $"{request.Origin}/api/projects/invite/{result.InviteCode}");
        }

        return "Done";
    }
}
