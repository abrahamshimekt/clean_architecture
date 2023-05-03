using MediatR;
using AutoMapper;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;


public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>{

    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken){

        var validator = new UpdateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
        if (validationResult.IsValid == False)
            throw new ValidationException(validationResult);

            
        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
        _mapper.Map(request.LeaveTypeDto,leaveType);
        await _leaveTypeRepository.Update(leaveType);
        return Unit.Value;

    }

}