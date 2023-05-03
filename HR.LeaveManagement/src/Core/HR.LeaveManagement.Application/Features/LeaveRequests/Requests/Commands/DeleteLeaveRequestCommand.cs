using MediatR;
namespace HR.LeaveManagement.Application.Features.LeaveRequests;
public class DeleteLeaveRequestCommand: IRequest{

    public int Id{get;set;}


}