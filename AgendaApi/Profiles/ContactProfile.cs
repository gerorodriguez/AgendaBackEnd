using AgendaApi.Entities;
using AgendaApi.Models.DTOs;
using AutoMapper;

namespace AgendaApi.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<Contact, ContactDto>();
    }
}