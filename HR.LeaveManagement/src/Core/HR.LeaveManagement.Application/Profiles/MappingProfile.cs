using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
namespace HR.LeaveManagement.Application.Profiles{
class MappingProfile : Profile{
    public MappingProfile(){
        CreateMap<LeaveRequest,LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest,LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveRequest,CreateLeaveRequestDto>.ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDto>.ReverseMap();

        CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType,CreateLeaveTypeDto>.ReverseMap();

        CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>.ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>.ReverseMap();

    }

}
}