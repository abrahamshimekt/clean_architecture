namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices( this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<LeaveManagementDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("")));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository))();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
        
    }
}