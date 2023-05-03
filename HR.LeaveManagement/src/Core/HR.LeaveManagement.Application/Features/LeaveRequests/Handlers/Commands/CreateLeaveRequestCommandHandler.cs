using AutoMapper;
using MediatR;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Persistence.Contract;
namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;
public class CreateLeaveRequestCommandHandler :IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,IEmailSender emailSender,
     IMapper mapper){
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request,CancellationToken cancellationToken){

        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestValidatorDto(_leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request.leaveRequestDto);
        if(validationResult.IsValid==false)
            response.Success = false;
            response.Messgae = "creation failed";
            response.Errors = validationResult.Errors.Select(q=>q.ErrorMessage).ToList();
            // throw new ValidationException(validationResult); 


        var leaveRequest = _mapper.Map<LeaveRequest>(request.leaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
        response.Success = true;
        response.Messgae = "successfully created";
        response.Id = request.Id;

        var email = new Email{
                To= "a2sv@ganvaknv",
                body = $"your leave request for {request.LeaveRequestDto.StartDate:D} to {request.leaveRequestDto.EndDate}",
                Subject = "leave request submitted"

        };
        try{
            await _emialSender.SendEmail(email);
    } catch(Exception e){
    }
        return response;

        
    }



}