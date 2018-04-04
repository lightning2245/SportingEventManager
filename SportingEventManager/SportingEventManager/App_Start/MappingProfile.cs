using AutoMapper;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organizer, OrganizerDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Guardian, GuardianDto>();
            CreateMap<Coach, CoachDto>();
            CreateMap<Sport, SportDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<AgeRange, AgeRangeDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<SportsEvent, SportsEventDto>();


            CreateMap<OrganizerDto, Organizer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<PlayerDto, Player>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<CoachDto, Coach>().ForMember(c => c.Id, opt => opt.Ignore());            
            CreateMap<SportDto, Sport>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<LocationDto, Location>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<AgeRangeDto, AgeRange>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<GuardianDto, Guardian>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<GenderDto, Gender>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<ScheduleDto, Schedule>().ForMember(c => c.Id, opt => opt.Ignore());            
            CreateMap<SportsEventDto, SportsEvent>().ForMember(c => c.Id, opt => opt.Ignore());


            //// Domain to Dto
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Customer, CustomerDto>();
            //    cfg.CreateMap<Movie, MovieDto>();
            //    cfg.CreateMap<MembershipType, MembershipTypeDto>();
            //    cfg.CreateMap<Genre, GenreDto>();


            //    // Dto to Domain
            //    cfg.CreateMap<CustomerDto, Customer>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());

            //    cfg.CreateMap<MovieDto, Movie>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
            //});
        }
    }
}