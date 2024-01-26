using AutoMapper;
using MinhasFinancas.Infra.Models;
using MinhasFinancas.Web.ViewModels;
using System.Reflection;
using System;
using System.Linq;

namespace MinhasFinancas.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Papel, PapelViewModel>().ReverseMap().ReverseMap();
            CreateMap<Dividendo, DividendoViewModel>().ReverseMap().ReverseMap();
            CreateMap<Transacao, TransacaoViewModel>().ReverseMap().ReverseMap();
            CreateMap<Segmento, SegmentoViewModel>().ReverseMap().ReverseMap();

        }
    }
}