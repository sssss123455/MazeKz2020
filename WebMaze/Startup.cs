using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Morgue;
using WebMaze.DbStuff.Repository;
using WebMaze.DbStuff.Repository.Morgue;
using WebMaze.Models.Account;
using WebMaze.Models.Bus;
using WebMaze.Models.Department;
using WebMaze.Models.Morgue;
using WebMaze.Models.UserTasks;
using WebMaze.Services;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace WebMaze
{
    public class Startup
    {
        public const string AuthMethod = "CoockieAuth";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=WebMazeKz;Trusted_Connection=True;";
            services.AddDbContext<WebMazeContext>(option => option.UseSqlServer(connectionString));

            services.AddAuthentication(AuthMethod)
                .AddCookie(AuthMethod, config =>
                {
                    config.Cookie.Name = "User.Auth";
                    config.LoginPath = "/Account/Login";
                    config.AccessDeniedPath = "/Account/AccessDenied";
                });

            RegistrationMapper(services);

            RegistrationRepository(services);

            services.AddScoped(s => new UserService(s.GetService<CitizenUserRepository>(),
                s.GetService<IHttpContextAccessor>()));

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();
        }

        private void RegistrationMapper(IServiceCollection services)
        {
            var configurationExpression = new MapperConfigurationExpression();

            configurationExpression.CreateMap<CitizenUser, ProfileViewModel>();
            configurationExpression.CreateMap<ProfileViewModel, CitizenUser>();

            configurationExpression.CreateMap<CitizenUser, RegistrationViewModel>();
            configurationExpression.CreateMap<RegistrationViewModel, CitizenUser>();

            configurationExpression.CreateMap<Adress, AdressViewModel>();
            configurationExpression.CreateMap<AdressViewModel, Adress>();

            configurationExpression.CreateMap<HealthDepartment, HealthDepartmentViewModel>();
            configurationExpression.CreateMap<HealthDepartmentViewModel, HealthDepartment>();

            configurationExpression.CreateMap<Bus, BusViewModel>();
            configurationExpression.CreateMap<BusViewModel, Bus>();

            configurationExpression.CreateMap<Bus, BusManageViewModel>();
            configurationExpression.CreateMap<BusManageViewModel, Bus>();

            configurationExpression.CreateMap<BusRoute, BusManageViewModel>();
            configurationExpression.CreateMap<BusManageViewModel, BusRoute>();

            configurationExpression.CreateMap<Bus, BusOrderViewModel>();
            configurationExpression.CreateMap<BusOrderViewModel, Bus>();

            configurationExpression.CreateMap<UserTask, UserTaskViewModel>();
            configurationExpression.CreateMap<UserTaskViewModel, UserTask>();

            configurationExpression.CreateMap<RegisterCardForMorgue, RegisterCardForMorgueViewModel>()
                .ForPath(x => x.IsReportRecorded, y => y.MapFrom(z => z.ForensicReport.IsReportRecorded))
                .ForPath(x => x.IsDateSet, y => y.MapFrom(z => z.BodyIdentificationReport.IsDateSet))
                .ForPath(x => x.DateOfIdentification, y => y.MapFrom(z => z.BodyIdentificationReport.DateOfIdentification))
                .ForPath(x => x.Name, y => y.MapFrom(z => z.Corpse.FirstName))
                .ForPath(x => x.Surname, y => y.MapFrom(z => z.Corpse.LastName))
                .ForPath(x => x.IsIdentified, y => y.MapFrom(z => z.BodyIdentificationReport.IsIdentified));
            configurationExpression.CreateMap<RegisterCardForMorgueViewModel, RegisterCardForMorgue>()
                .ForPath(x => x.ForensicReport.IsReportRecorded, y => y.MapFrom(z => z.IsReportRecorded))
                .ForPath(x => x.BodyIdentificationReport.IsDateSet, y => y.MapFrom(z => z.IsDateSet))
                .ForPath(x => x.BodyIdentificationReport.DateOfIdentification, y => y.MapFrom(z => z.DateOfIdentification))
                .ForPath(x => x.Corpse.FirstName, y => y.MapFrom(z => z.Name))
                .ForPath(x => x.Corpse.LastName, y => y.MapFrom(z => z.Surname))
                .ForPath(x => x.BodyIdentificationReport.IsIdentified, y => y.MapFrom(z => z.IsIdentified));

            configurationExpression.CreateMap<ForensicReport, ForensicReportViewModel>();
            configurationExpression.CreateMap<ForensicReportViewModel, ForensicReport>();

            configurationExpression.CreateMap<BodyIdentificationReport, BodyIdentificationReportViewModel>()
                .ForPath(x => x.PoliceOfficerName, y => y.MapFrom(z => z.PoliceOfficer.FirstName))
                .ForPath(x => x.PoliceOfficerSurname, y => y.MapFrom(z => z.PoliceOfficer.LastName))
                .ForPath(x => x.IdentifyingPersonName, y => y.MapFrom(z => z.IdentifyingPerson.FirstName))
                .ForPath(x => x.IdentifyingPersonSurname, y => y.MapFrom(z => z.IdentifyingPerson.LastName));
            configurationExpression.CreateMap<BodyIdentificationReportViewModel, BodyIdentificationReport>()
                .ForPath(x => x.PoliceOfficer.FirstName, y => y.MapFrom(z => z.PoliceOfficerName))
                .ForPath(x => x.PoliceOfficer.LastName, y => y.MapFrom(z => z.PoliceOfficerSurname))
                .ForPath(x => x.IdentifyingPerson.FirstName, y => y.MapFrom(z => z.IdentifyingPersonName))
                .ForPath(x => x.IdentifyingPerson.LastName, y => y.MapFrom(z => z.IdentifyingPersonSurname));

            configurationExpression.CreateMap<BodyIdentificationReport, IdentificationDateViewModel>();
            configurationExpression.CreateMap<IdentificationDateViewModel, BodyIdentificationReport>();

            var mapperConfiguration = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(s => mapper);
        }

        private void RegistrationRepository(IServiceCollection services)
        {
            services.AddScoped<CitizenUserRepository>(serviceProvider =>
            {
                var webContext = serviceProvider.GetService<WebMazeContext>();
                return new CitizenUserRepository(webContext);
            });

            services.AddScoped(s => new AdressRepository(s.GetService<WebMazeContext>()));

            services.AddScoped(s => new PolicemanRepository(s.GetService<WebMazeContext>()));

            services.AddScoped(s => new HealthDepartmentRepository(s.GetService<WebMazeContext>()));

            services.AddScoped(s => new BusRepository(s.GetService<WebMazeContext>()));
            services.AddScoped(s => new BusStopRepository(s.GetService<WebMazeContext>()));
            services.AddScoped(s => new BusRouteRepository(s.GetService<WebMazeContext>()));

            services.AddScoped(s => new UserTaskRepository(s.GetService<WebMazeContext>()));

            services.AddScoped(s => new RegisterCardForMorgueRepository(s.GetService<WebMazeContext>()));
            services.AddScoped(s => new ForensicReportRepository(s.GetService<WebMazeContext>()));
            services.AddScoped(s => new BodyIdentificationReportRepository(s.GetService<WebMazeContext>()));
            services.AddScoped(s => new RitualServiceRepository(s.GetService<WebMazeContext>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //  то ты?
            app.UseAuthentication();

            //  уда у теб€ есть доступ?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
