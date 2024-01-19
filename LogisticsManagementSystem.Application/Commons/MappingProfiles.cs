using AutoMapper;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserRegisterRequest, User>();
    }
}
