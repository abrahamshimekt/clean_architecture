namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _leaveManagementDbContext;
        public LeaveRequestRepository(LeaveManagementDbContext leaveManagementDbContext):base(leaveManagementDbContext){
            _leaveManagementDbContext = leaveManagementDbContext;

        }
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus){
            leaveRequest.Approved = ApprovalStatus;
            _leaveManagementDbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _leaveManagementDbContext.SaveChangesAsync();
        }
        public async Task <List<LeaveRequest>> GetLeaveRequestsWithDetails(){
            var leaveRequests = await _leaveManagementDbContext.LeaveRequests.Include(q=>q.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task <LeaveRequest> GetLeaveRequestWithDetails(int Id){
            var leaveRequest = await _leaveManagementDbContext.LeaveRequests
            .Include(q=>q.LeaveType)
            .FirstOrDefaultAsync(q=>q.Id = Id);
            return leaveRequest;
        }

    }
}