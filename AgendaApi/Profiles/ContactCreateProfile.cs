using AgendaApi.Entities;
using AgendaApi.Models.DTOs;
using AutoMapper;

namespace AgendaApi.Profiles
{
    public class ContactCreateProfile : Profile
    { 
        public ContactCreateProfile()
        {
            CreateMap<Contact, CreateContactDto>();
            CreateMap<CreateContactDto, Contact>();
        }

    }


}
