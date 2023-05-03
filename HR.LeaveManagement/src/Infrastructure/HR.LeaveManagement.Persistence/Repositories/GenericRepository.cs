namespace HR.LeaveManagement.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class{
    private readonly LeaveManagementDbContext _leaveManagementDbContext;

    public GenericRepository(LeaveManagementDbContext leaveManagementDbContext){
        _leaveManagementDbContext = leaveManagementDbContext;
    }

    public async Task<T> Add(T entity){
        await _leaveManagementDbContext.AddAsync(entity);
        await _leaveManagementDbContext.SaveChangesAsync();
        return entity;
    }
    public async Task Delete(T entity){
        _leaveManagementDbContext.Set<R>().Remove(entity);
        await _leaveManagementDbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int Id){
        var entity = await Get(Id);
        return entity !=null;
    }

    public async Task<T> Get(int Id){
        return _leaveManagementDbContext.Set<T>().FindAsync(Id);
    }

    public async Task<IReadOnlyList<T>> GetAll(){
        return await _leaveManagementDbContext.Set<T>().ToListAsync();
    }

    public async Task Update(T entity){
        _leaveManagementDbContext.Entry(entity).State = EntityState.Modified;
        return await _leaveManagementDbContext.SaveChangesAsync();
    }


}