﻿using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Domain.Entities;


namespace DanhMucService.Application.Common.Models.QuanHuyens
{
    public class QuanHuyenDto : IMapFrom<QuanHuyen>
    {
        public int Id { get; set; }
        public string MaDinhDanh { get; set; }
        public string Ten { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuanHuyen, QuanHuyenDto>().ReverseMap();
        }
    }
}