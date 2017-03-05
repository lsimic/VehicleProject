using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using AutoMapper;
using VehicleProject.DAL;
using VehicleProject.Web.Models;

namespace VehicleProject.Web.App_Start
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleModelEntity, VehicleModelVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ModelId))
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.VehicleMakeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.Abbr, opt => opt.MapFrom(src => src.ModelAbbr))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.VehicleMake))
                .MaxDepth(3);

                config.CreateMap<VehicleMakeEntity, VehicleMakeVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MakeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MakeName))
                .ForMember(dest => dest.Abbr, opt => opt.MapFrom(src => src.MakeAbbr))
                .ForMember(dest => dest.MakeModels, opt => opt.MapFrom(src => src.MakeModels))
                .MaxDepth(3);

                config.CreateMap<VehicleModelVM, VehicleModelEntity>()
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VehicleMakeId, opt => opt.MapFrom(src => src.MakeId))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ModelAbbr, opt => opt.MapFrom(src => src.Abbr))
                .ForMember(dest => dest.VehicleMake, opt => opt.MapFrom(src => src.Make))
                .MaxDepth(3);

                config.CreateMap<VehicleMakeVM, VehicleMakeEntity>()
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MakeAbbr, opt => opt.MapFrom(src => src.Abbr))
                .ForMember(dest => dest.MakeModels, opt => opt.MapFrom(src => src.MakeModels))
                .MaxDepth(3);


            });

            return Mapper.Instance;
        } 
    }
}