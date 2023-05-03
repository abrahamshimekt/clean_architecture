namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository){
            _leaveTypeRepository= leaveTypeRepository;

            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
            RuleFor(p=>p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
        
    }
}