using MediatR;
using AutoMapper;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
namespace HR.LeaveManagement.Application.Features.LeaveAllocations;
public class UpdateLeaveAllocationCommandHandler: IRequestHandler<UpdateLeaveAllocationCommand,Unit>{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper){
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken){

        var validator = new UpdateLeaveAllocationValditorDto(_leaveAllocationRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
        if(validationResult.IsValid==false)
            throw ValidationException(validationResult);

        var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
        _mapper.Map(request.LeaveAllocationDto,leaveAllocation);

        await _leaveAllocationRepository.Update(leaveAllocation);

        return Unit.Value;
        
    }

}