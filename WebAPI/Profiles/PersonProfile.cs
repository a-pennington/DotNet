using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonReadDTO>();
        }
    }
}