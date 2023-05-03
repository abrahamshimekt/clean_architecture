using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;
namespace HR.LeaveManagement.Application.DTOs.LeaveRequest{

    class LeaveRequestListDto : BaseDto{

        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
     

    }
}