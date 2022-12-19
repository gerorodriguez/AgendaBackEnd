using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Models.DTOs;
using AutoMapper;

namespace AgendaApi.Profiles;

public class ContactsBookProfile : Profile
{

    public ContactsBookProfile()
    {
        CreateMap<ContactsBook, ContactsBookDto>().ReverseMap();
        CreateMap<ContactsBook, ContactsBookDto>();
    }

}