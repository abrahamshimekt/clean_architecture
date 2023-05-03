using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
public class CreateLeaveAllocationCommand : IRequest<int>{
    public CreateLeaveAllocationDto LeaveAllocationDto {get;set;}
}