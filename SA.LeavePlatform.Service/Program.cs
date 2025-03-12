using SA.LeavePlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using SA.LeavePlatform.Service.Query;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure Ef Core with SQL Server

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<SADbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 41))));
        //Register Repository
        builder.Services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
        builder.Services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
        builder.Services.AddScoped<IProjetQueryRepository, ProjetQueryRepository>();
        builder.Services.AddScoped<IStatusQueryRepository, StatusQueryRepository>();
        builder.Services.AddScoped<ILeaveTypeQueryRepository, LeaveTypeQueryRepository>();
        builder.Services.AddScoped<IAffectationQueryRepository, AffectationQueryRepository>();
        builder.Services.AddScoped<ILeaveDocQueryRepository, LeaveDocQueryRepository>();
        builder.Services.AddScoped<ILeaveRequestQueryRepository, LeaveRequestQueryRepository>();









        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
