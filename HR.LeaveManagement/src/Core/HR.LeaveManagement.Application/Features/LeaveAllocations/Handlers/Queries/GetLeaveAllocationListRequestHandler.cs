using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using AutoMapper;
using MediatR;
namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries;

public class GetLeaveAllocationListRequestHandler: IRequestHandler<GetLeaveAllocationListRequest , List<LeaveAllocationDto>>{
    private readonly ILeaveAllocationRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper){
        _leaveRequestRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken){
        var leaveAllocations = await _leaveRequestRepository.GetLeaveAllocationsWithDetails();

        return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
    }
}