using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StumeetAPI.Business.Abstract;
using StumeetAPI.Business.Concrete.Managers;
using StumeetAPI.DataAccess.Concrete.EntityFramework;
using StumeetAPI.DTOs;

namespace StumeetAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IMailService, MailManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAssetService, AssetManager>();
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddScoped<IDataTypeExtensionService, DataTypeExtensionManager>();
            services.AddScoped<IDataTypeService, DataTypeManager>();
            services.AddScoped<IDeletedMessageService, DeletedMessageManager>();
            services.AddScoped<IEducationInformationService, EducationInformationManager>();
            services.AddScoped<IEventParticipantService, EventParticipantManager>();
            services.AddScoped<IEventService, EventManager>();
            services.AddScoped<IMessageGroupService, MessageGroupManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IPostCommentService, PostCommentManager>();
            services.AddScoped<IUniversityService, UniversityManager>();
            services.AddScoped<IWorkInformationService, WorkInformationManager>();
            services.AddDbContext<StumeetDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder => builder.UseRowNumberForPaging()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
