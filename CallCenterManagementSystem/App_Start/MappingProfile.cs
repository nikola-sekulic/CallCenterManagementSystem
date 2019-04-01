using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCenterManagementSystem.Models;
using AutoMapper;
using CallCenterManagementSystem.Dtos;

namespace CallCenterManagementSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Employee, EmployeeDto>();
            
            Mapper.CreateMap<Department, DepartmentDto>();
            Mapper.CreateMap<DepartmentDto, Department>();

            Mapper.CreateMap<Designation, DesignationDto>();
            Mapper.CreateMap<DesignationDto, Designation>();

            Mapper.CreateMap<SoldDevice, SoldDeviceDto>();
            Mapper.CreateMap<SoldDeviceDto, SoldDevice>();

            Mapper.CreateMap<Buyer, BuyerDto>();
            Mapper.CreateMap<DeviceSupplier, DeviceSupplierDto>();

            Mapper.CreateMap<Reclamation, NewReclamationDto>();
            Mapper.CreateMap<NewReclamationDto, Reclamation>();




            //Dto to Domain
            Mapper.CreateMap<EmployeeDto, Employee>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            
        }
    }
}