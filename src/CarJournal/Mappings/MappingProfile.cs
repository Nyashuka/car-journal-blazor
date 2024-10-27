using AutoMapper;

using CarJournal.ClientDtos;
using CarJournal.Domain;

namespace CarJournal.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateUserCarDto, UserCar>()
            .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CurrentMileage, opt => opt.Ignore())
            .ForMember(dest => dest.AverageMileage, opt => opt.Ignore())
            .ForMember(dest => dest.StartMileage, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.DateOfAdd, opt => opt.Ignore())
            .ForMember(dest => dest.CurrentMileage, opt => opt.Ignore());

        CreateMap<UserCar, UpdateUserCarDto>();
    }
}