using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using AutoMapper;
using MediatR;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler <GetLeaveRequestListRequest, List<LeaveRequestDto>>{

    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper){
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request,CancellationToken cancellationToken){
        var leaveRequests = _leaveRequestRepository.GetLeaveRequestsWithDetails();

        return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
    } 

}