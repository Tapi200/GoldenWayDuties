using AutoMapper;
using GoldenWayDuties.Dtos;
using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Owner, OwnerDto>();
            Mapper.CreateMap<Taskitem, TaskitemDto>();
            Mapper.CreateMap<ResidentType, ResidentTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Dto to Domain
            Mapper.CreateMap<OwnerDto, Owner>().
                ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<TaskitemDto, Taskitem>().
                ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}