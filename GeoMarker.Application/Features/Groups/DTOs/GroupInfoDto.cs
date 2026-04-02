
namespace GeoMarker.Application.Features.Groups.DTOs
{
    public record GroupInfoDto
    (
         Guid Id,
        string Name,
        string? Description,
        Guid OwnerId,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );   
}
