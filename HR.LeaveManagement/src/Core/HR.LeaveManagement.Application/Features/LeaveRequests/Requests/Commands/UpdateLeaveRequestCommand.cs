using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
namespace HR.LeaveManagement.Application.Features.LeaveRequests;
public class UpdateLeaveRequestCommand: IRequest<Unit>{
    public int Id{get;set;}
    public UpdateLeaveRequestDto LeaveRequestDto {get;set;}
    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }

}