using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contract;
using AutoMapper;
using MediatR;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers;
class GetLeaveTypeDetailRequestHandler: IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>{

    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository , Mapper  mapper){
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request,CancellationToken cancellationToken){
        var leaveType = await _leaveTypeRepository.Get(request.Id);
        return _mapper.Map<LeaveTypeDto>(leaveType);

    }

}