using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using MediatR;
using AutoMapper;
namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest,List<LeaveTypeDto>>{
        private readonly ILeaveTypeRepository  _leavTypeRepository;

        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper){
            _leavTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken){
            var leaveTypes = await _leavTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }


    }
