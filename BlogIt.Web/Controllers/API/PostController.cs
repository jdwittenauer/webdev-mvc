﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;

namespace BlogIt.Web.Controllers.API
{
    /// <summary>
    /// Post web API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class PostController : ApiController
    {
        private IPostRepository repository;

        /// <summary>
        /// Overrides the default constructor.  Uses dependency injection to instantiate repositories.
        /// </summary>
        public PostController(IPostRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a collection of all posts.
        /// </summary>
        /// <returns>Collection of posts</returns>
        [Route("posts", Name = "Posts")]
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await repository.GetPostsAsync();
        }

        /// <summary>
        /// Gets a single post by ID.
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns>Post</returns>
        [Route("posts/{id}", Name = "Post")]
        [HttpGet]
        public async Task<Post> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            return await repository.GetAsync(id);
        }

        /// <summary>
        /// Posts a new post.
        /// </summary>
        /// <param name="value">New post</param>
        [Route("posts")]
        [HttpPost]
        public async Task<Post> Post([FromBody]Post value)
        {
            if (value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            value.Date = DateTime.Now;
            var post = await repository.InsertAsync(value);
            return post;
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <param name="value">Updated post</param>
        [Route("posts/{id}")]
        [HttpPut]
        public async Task<Post> Put(Guid id, [FromBody]Post value)
        {
            if (id == Guid.Empty || value == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            value.ID = id;
            var post = await repository.UpdateAsync(value);
            return post;
        }

        /// <summary>
        /// Deletes an existing post.
        /// </summary>
        /// <param name="id">Post ID</param>
        [Route("posts/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid parameter"));
            }

            var value = await repository.GetAsync(id);
            await repository.DeleteAsync(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}