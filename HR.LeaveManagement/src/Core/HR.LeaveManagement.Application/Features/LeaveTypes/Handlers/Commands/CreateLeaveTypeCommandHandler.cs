using MediatR;
using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class CreateLeaveTypeCommandHandler: IRequestHandler<CreateLeaveTypeCommand,int>{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper){
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken){
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
        var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
        if (validationResult.IsValid == False)
            throw new ValidationException(validationResult);

            
        leaveType = await _leaveTypeRepository.Add(leaveType);  
        return leaveType.Id;
    }
}