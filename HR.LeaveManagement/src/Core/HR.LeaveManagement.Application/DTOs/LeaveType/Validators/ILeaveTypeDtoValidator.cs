namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {   
        public ILeaveTypeDtoValidator(){
        RuleFor(p=>p.Name)
        .NotEmpty.WithMessage("{PropertyName} is required")
        .NotNull
        .MaximumLength(50)
        .WithMessage("{PropertyName} must be less than {ComparisonValue}" );

        RuleFor(p=>p.DefaultDays)
        .NotEmpty.WithMessage("{PropertyName} is required")
        .GreaterThan(0).WithMessage("{PropertyName} must be less than 1 ")
        .LessThan(100).WithMessage("{PropertyName} must be less than{Comparion}" );
        }
       
        
    }
}