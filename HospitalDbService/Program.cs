using HospitalDbService.Core.Interfaces.IRepository;
using HospitalDbService.Core.Interfaces.IService;
using HospitalDbService.Core.Interfaces.IUnitOfWork;
using HospitalDbService.Core.Services;
using HospitalDbService.Infraestructure;
using HospitalDbService.Infraestructure.Data;
using HospitalDbService.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HospitalDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDBContext"))
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IConsultService, ConsultService>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//  var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
//  context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
