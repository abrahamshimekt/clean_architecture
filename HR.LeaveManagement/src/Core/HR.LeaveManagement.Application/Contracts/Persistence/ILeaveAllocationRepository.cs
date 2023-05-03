using HR.LeaveManagement.Application.Persistence.Contract;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contract{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>{
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}