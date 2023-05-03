using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveType;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeListRequest: IRequest<List<LeaveTypeDto>>{

}