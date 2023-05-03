using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
namespace HR.LeaveManagement.Application.Features.LeaveAllocations;
public class UpdateLeaveAllocationCommand: IRequest<Unit>{
    public LeaveAllocationDto LeaveAllocationDto{get;set;}
    
}