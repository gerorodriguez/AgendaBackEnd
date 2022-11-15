using AgendaApi.Entities;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Profiles
{
    public class ContactUpdateProfile : Profile
    {
        public ContactUpdateProfile()
        {
            CreateMap<Contact, UpdateContactDto>();
            CreateMap<UpdateContactDto, Contact>();
        }
    }
}
