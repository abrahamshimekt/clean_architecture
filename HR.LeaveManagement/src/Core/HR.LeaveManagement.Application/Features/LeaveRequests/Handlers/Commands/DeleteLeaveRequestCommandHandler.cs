using MediatR;
using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contract;
namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    
    
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper){
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken){

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if(leaveRequest ==null){
                new NotFoundException(nameof(LeaveRequest),request.Id);
            }
            await _leaveRequestRepository.Delete(leaveRequest);

            return Unit.Value;


        }
    }
}