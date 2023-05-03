namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _leaveManagementDbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext leaveManagementDbContext): base(leaveManagementDbContext){
            _leaveManagementDbContext = leaveManagementDbContext;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(){
            var leaveAllocations =  await _leaveManagementDbContext.LeaveAllocations
            .Include(q=>q.LeaveType)
            .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id){
            var leaveAllocation = await _leaveManagementDbContext.LeaveAllocations
            .Include(q=>q.LeaveType)
            .FirstOrDefaultAsync(q=>q.Id == Id);

            return leaveAllocation;
        }
    }
}