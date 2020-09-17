using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.FileHelper;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfPostDal>().As<IPostDal>(); 
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>(); 
            builder.RegisterType<EfContactDal>().As<IContactDal>(); 

            builder.RegisterType<CategoryManager>().As<ICategoryService>(); 
            builder.RegisterType<UserManager>().As<IUserService>(); 
            builder.RegisterType<PostManager>().As<IPostService>(); 
            builder.RegisterType<CommentManager>().As<ICommentService>(); 
            builder.RegisterType<ContactManager>().As<IContactService>();

            builder.RegisterType<JwtHelper>().As<ITokenOption>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<FileServices>().As<IFileServices>();


        }
    }
}
