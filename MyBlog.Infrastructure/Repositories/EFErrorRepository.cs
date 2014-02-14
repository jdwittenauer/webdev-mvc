﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Infrastructure.Framework;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// Repository pattern for accessing error data.  Inherits from a base generic
    /// abstract class that implements common functionality.
    /// </summary>
    public class EFErrorRepository : EFRepository<Error>, IErrorRepository
    {
        public EFErrorRepository() : base() { }

        public EFErrorRepository(MyBlogContext context) : base(context) { }
    }
}