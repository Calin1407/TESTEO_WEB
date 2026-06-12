using NovaTech.TerraTech.Platform.ProfileManagement.Application.CommandServices;
using NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.ProfileManagement.Domain.Repositories;
using NovaTech.TerraTech.Platform.Shared.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.ProfileManagement.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        
        await profileRepository.AddAsync(profile);
        await unitOfWork.CompleteAsync(); 
        
        return profile;
    }
}