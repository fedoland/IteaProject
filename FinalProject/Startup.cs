using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Database;
using FinalProject.Models.Entities;
using FinalProject.Models.Entities.ManyToMany;
using FinalProject.Services;
using FinalProject.Services.Interfaces;
using FinalProject.Services.ManyToManyServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FinalProject
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
            services.AddDbContext<ProjectDbContext>(options =>
                options.UseSqlServer(
#if DEBUG
                    Configuration.GetConnectionString("SQLConnectionString")
#else
                    Configuration.GetConnectionString("SQLConnectionString_Release")
#endif
                    )
            );
            #region BaseTask
            services.AddTransient<IService<User>, UserService>();
            services.AddTransient<IService<UserInfo>, UserInfoService>();
            services.AddTransient<IService<LoginHistory>, LoginHistoryService>();
            services.AddTransient<IService<UserAddress>, UserAddressService>();
            #endregion
            #region ManyToMany
            services.AddTransient<IService<Student>, StudentService>();
            services.AddTransient<IService<Course>, CourseService>();
            services.AddTransient<IService<StudentCourse>, StudentCourseService>();
            #endregion
            services.AddMvc(options => { options.AllowEmptyInputInBodyModelBinding = true; })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
