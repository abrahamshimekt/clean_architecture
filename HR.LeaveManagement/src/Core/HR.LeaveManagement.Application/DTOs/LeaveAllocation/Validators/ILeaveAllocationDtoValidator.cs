namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository){
            _leaveAllocationRepository= leaveAllocationRepository;

            RuleFor(p=>p.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p=p.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p=>p.LeaveTypeId).GreaterThan(0).MustAsync(async(id, token)=>{
                var leaveTypeExists = _leaveAllocationRepository.Exists(id);
                return !leaveTypeExists;

            }).WithMessage("{PropertyName} doesn't exist");

        }
    }
}