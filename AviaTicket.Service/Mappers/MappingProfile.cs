using AutoMapper;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Airplanes;
using AviaTicket.Model.Races;
using AviaTicket.Model.Seats;
using AviaTicket.Model.Tickets;
using AviaTicket.Model.Users;

namespace AviaTicket.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Airplane, AirplaneCreateModel>().ReverseMap();
        CreateMap<Airplane, AirplaneUpdateModel>().ReverseMap();
        CreateMap<Airplane, AirplaneViewModel>().ReverseMap();

        CreateMap<Race, RaceCreateModel>().ReverseMap();
        CreateMap<Race, RaceUpdateModel>().ReverseMap();
        CreateMap<Race, RaceViewModel>().ReverseMap();

        CreateMap<Seat, SeatCreateModel>().ReverseMap();
        CreateMap<Seat, SeatUpdateModel>().ReverseMap();
        CreateMap<Seat, SeatViewModel>().ReverseMap();

        CreateMap<Ticket, TicketCreateModel>().ReverseMap();
        CreateMap<Ticket, TicketUpdateModel>().ReverseMap();
        CreateMap<Ticket, TicketViewModel>().ReverseMap();

        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();
    }
}
