namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
       public CreateLeaveTypeDtoValidator(){
        Include(new ILeaveTypeDtoValidator());
        RuleFor(p=>p.Id).NotNull.WithMessage("{PropertyName} must be present");
       }
        
    }
}