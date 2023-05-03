using AutoMapper;
using MediatR;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand ,int>{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,ILeaveTypeRepository leaveTypeRepository,
    IMapper mapper){
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;

        _mapper = mapper;

    }
    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken){

        var validator = new CreateLeaveAllocationValidatorDto(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
        if(validationResult.IsValid == false)
            throw ValidationException(validationResult);

        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }
}