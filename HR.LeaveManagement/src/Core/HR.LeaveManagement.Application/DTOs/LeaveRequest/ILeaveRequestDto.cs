namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto


    {
    public DateTime StartDate { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime EndDate { get; set; }

         
    }
}