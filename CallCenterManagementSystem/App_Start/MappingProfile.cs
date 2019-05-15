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
            Mapper.CreateMap<Employee, EmployeeDto>()
                .Include<Agent, AgentDto>()
                .Include<Supervisor, SupervisorDto>()
                .Include<Specialist, SpecialistDto>();
            
            Mapper.CreateMap<Supervisor, SupervisorDto>();
            Mapper.CreateMap<Agent, AgentDto>();
            Mapper.CreateMap<Specialist, SpecialistDto>();
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
            Mapper.CreateMap<SupervisorDto, Supervisor>();
            Mapper.CreateMap<AgentDto, Agent>();
            Mapper.CreateMap<SpecialistDto, Specialist>();




            //Dto to Domain
            Mapper.CreateMap<EmployeeDto, Employee>()
                .Include<AgentDto, Agent>()
                .Include<SupervisorDto, Supervisor>()
                .Include<SpecialistDto, Specialist>();


        }
    }
}