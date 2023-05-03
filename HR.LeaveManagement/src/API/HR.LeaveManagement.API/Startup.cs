namespace HR.LeaveManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration{get;}

        public void ConfigureServices(IServiceCollection services){
            services.ConfigureApplicationServices();
            services.ConfigureInfrastructureServices();
            services.ConfigurePersistenceServices();
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo{title="HR.LeaveManagement.Api",version ="v1"});
            });
            services.AddCors(o=>{
                o.AddPolicy(CorsPolicy,builder=>builder.AllowAnyOrigin()
                .AllowAnyMethode()
                .AllowAnyHeader() 
                );
            });
        }

        public voif Configure(IApplicationBuilder app , IWebHotEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","HR.LeaveManagement.Api v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>   {
                endpoints.MapControllers();
            });
        }
        
    }

}