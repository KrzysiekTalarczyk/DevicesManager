using AutoMapper;
using DevicesManager.Domain.Entities;
using DevicesManager.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesManager.Services.MappingProfile
{
	public class DeviceMappingProfile : Profile
	{
		public DeviceMappingProfile()
		{
			CreateMap<DeviceDto, Device>().ReverseMap();
		}
	}
}
