using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Domain;
using AutoMapper;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;


public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest,LeaveRequestDto>{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository requestRepository, IMapper mapper){
        _leaveRequestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken){
        var leaveRequest = _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}