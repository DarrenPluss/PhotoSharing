using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PhotoSharing.Model;
using PhotoSharing.Models;

namespace PhotoSharing.App_Start
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<PhotoDetails, PhotoDisplayModel>();
            Mapper.CreateMap<PhotoEditModel, Photo>();
            Mapper.CreateMap<AdminPhotoEditModel, Photo>();
            Mapper.CreateMap<PhotoDetails, PhotoEditModel>();
            Mapper.CreateMap<PhotoDetails, AdminPhotoEditModel>();    
        }
    }
}