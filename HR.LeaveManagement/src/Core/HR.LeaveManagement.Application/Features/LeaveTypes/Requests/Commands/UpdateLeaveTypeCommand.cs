using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveType;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

public class UpdateLeaveTypeCommand: IRequest<Unit>{

    public LeaveTypeDto LeaveTypeDto{get;set;}

}