using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Domain;
namespace HR.LeaveManagement.Application.Persistence.Contract{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>{}
}