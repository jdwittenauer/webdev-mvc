﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;
using MyBlog.Web.Models;
using MyBlog.Web.Models.DTO;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Comment controller.
    /// </summary>
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public CommentController(ICommentRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index(Guid authorID)
        {
            var model = new CommentViewModel
            {
                Comments = Mapper.Map<List<Comment>, List<CommentDTO>>(repository.GetByAuthor(authorID))
            };

            return View(model);
        }

        /// <summary>
        /// New comment partial view.
        /// </summary>
        public ActionResult NewComment(Guid id)
        {
            var model = repository.Get(id);
            return View(model);
        }
	}
}