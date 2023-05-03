namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<IleaveRequestDto>        
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository){
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(p=>p.StartDate)
            .LessThan(p=>p.EndDate)
            .WithMessage("{PropertyName} must be before {ComaprisonValue}");
            RuleFor(p=>p.EndDate)
            .GreaterThan(p=>p.StartDate)
            .WithMessage("{PropertyName} must be after {ComparisonValue}" );
            RuleFor(p=>p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token)=>{
                var leaveTypeExists =  await _leaveRequestRepository.Exists(id);
                return !leaveTypeExists;

            }).WithMessage("{PropertyName}  doesn't exist");
        }
    }
}