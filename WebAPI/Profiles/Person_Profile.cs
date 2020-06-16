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
            CreateMap<Person, Person_Read_DTO>();
            CreateMap<Person_Create_DTO, Person>();
            CreateMap<Person_Update_DTO, Person>();
            CreateMap<Person, Person_Update_DTO>();
        }
    }
}