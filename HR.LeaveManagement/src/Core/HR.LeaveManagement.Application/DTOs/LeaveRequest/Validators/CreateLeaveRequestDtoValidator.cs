namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>{

    private readonly ILeaveRequetRepository _leaveRequestRepository;

    public CreateLeaveRequestDtoValidator(ILeaveRequetRepository leaveRequetRepository){
        _leaveRequestRepository= leaveRequetRepository;
        Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));

    }
}