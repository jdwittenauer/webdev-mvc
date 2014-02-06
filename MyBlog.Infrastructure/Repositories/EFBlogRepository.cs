﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Domain.Services;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing blogs.  Inherits from a base generic abstract class
    /// the implements common functionality.
    /// </summary>
    public class EFBlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public EFBlogRepository() : base() { }

        public EFBlogRepository(MyBlogContext context) : base(context) { }
    }
}
