using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExperience.Test.DataModel;
using WebExperience.Test.Dtos;

namespace WebExperience.Test.Config
{
	public static class AutoMapperConfiguration
	{
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Asset, AssetDetailDto>();
                cfg.CreateMap<Asset, AssetOverviewDto>();
            });

            return mapperConfiguration;
        }
    }
}