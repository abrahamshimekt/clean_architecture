using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveType;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeDetailRequest: IRequest<LeaveTypeDto> {
    public int Id{get;set;}
}