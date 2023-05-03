using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
public class CreateLeaveTypeCommand: IRequest<BaseCommandResponse>{
    public CreateLeaveTypeDto LeaveTypeDto{get;set;}
}