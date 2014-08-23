// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Data.Entity;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Integration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<AnsweringService>().As<IAnsweringService>().InstancePerRequest();
            builder.RegisterType<ExaminationService>().As<IExaminationService>().InstancePerRequest();
            builder.RegisterType<ManagementService>().As<IManagementService>().InstancePerRequest();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
            builder.RegisterType<SubjectService>().As<ISubjectService>().InstancePerRequest();

            builder.RegisterType<OnlineAssessmentContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>().InstancePerDependency();
            builder.RegisterType<UserManager<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<IdentityRole>();
            builder.RegisterType<RoleManager<IdentityRole>>().InstancePerRequest();
        }
    }
}