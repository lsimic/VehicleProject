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
                //mapping VehicleMakeDeleteDetailVM
                config.CreateMap<MakeModel, VehicleModelEntity>()
                .ForMember(dest => dest.VehicleMake, opt => opt.Ignore());

                config.CreateMap<VehicleModelEntity, MakeModel>()
                .ForSourceMember(src => src.VehicleMake, opt => opt.Ignore());

                config.CreateMap<VehicleMakeDeleteDetailVM, VehicleMakeEntity>();
                config.CreateMap<VehicleMakeEntity, VehicleMakeDeleteDetailVM>();
                //mapping VehicleMakeDeleteDetailVM finished

                //mapping VehicleMakeCreateVM
                config.CreateMap<VehicleMakeCreateVM, VehicleMakeEntity>()
                .ForMember(dest => dest.MakeId, opt => opt.Ignore())
                .ForMember(dest => dest.MakeModels, opt => opt.Ignore());
                //mapping VehicleMakeCreateVM finished

                //mapping VehicleMakeIndexUpdateVM
                config.CreateMap<VehicleMakeIndexUpdateVM, VehicleMakeEntity>()
                .ForMember(dest => dest.MakeModels, opt => opt.Ignore());

                config.CreateMap<VehicleMakeEntity, VehicleMakeIndexUpdateVM>()
                .ForSourceMember(src => src.MakeModels, opt => opt.Ignore());
                //mapping VehicleMakeIndexUpdateVM finished



                //mapping VehicleModelCreateVM
                config.CreateMap<VehicleModelCreateVM, VehicleModelEntity>()
                .ForMember(dest => dest.VehicleMakeId, opt => opt.MapFrom(src => Int32.Parse(src.MakeId)))
                .ForMember(dest => dest.ModelId, opt => opt.Ignore())
                .ForMember(dest => dest.VehicleMake, opt => opt.Ignore());
                //mapping VehicleModelCreateVM finished

                //mapping VehicleModelDetailVM
                config.CreateMap<VehicleMakeEntity, ModelMake>()
                .ForSourceMember(src => src.MakeModels, opt => opt.Ignore());

                config.CreateMap<VehicleModelEntity, VehicleModelDetailVM>();
                //mapping VehicleModelDetailVM finished

                //mapping VehicleModelIndexVm 
                config.CreateMap<VehicleModelEntity, VehicleModelIndexVM>()
                .ForSourceMember(src => src.VehicleMakeId, opt => opt.Ignore())
                .ForSourceMember(src => src.VehicleMake, opt => opt.Ignore())
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.VehicleMake.MakeName));
                //mapping VehicleModelIndexVm finished

                //mapping VehicleModelUpdateDeleteVM
                config.CreateMap<VehicleModelEntity, VehicleModelUpdateDeleteVM>()
                .ForSourceMember(src => src.VehicleMake, opt => opt.Ignore())
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.VehicleMake.MakeName));

                config.CreateMap<VehicleModelUpdateDeleteVM, VehicleModelEntity>()
                .ForMember(dest => dest.VehicleMake, opt => opt.Ignore())
                .ForSourceMember(src => src.MakeName, opt => opt.Ignore());
            });

            return Mapper.Instance;
        } 
    }
}