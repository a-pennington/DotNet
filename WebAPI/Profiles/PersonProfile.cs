using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            //  Map = Source -> Target
            CreateMap<Person, PersonReadDTO>();
            CreateMap<PersonCreateDTO, Person>();
        }
    }
}