using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StumeetAPI.Controllers
{
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private IPostService _postManager;
        private IAuthenticationService _authManager;

        public PostsController(IPostService postManager, IAuthenticationService authManager)
        {
            _postManager = postManager;
            _authManager = authManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var postList = await _postManager.GetAll(u => u.IsDeleted != true);
            if (postList == null)
            {
                return NotFound();
            }
            return Ok(postList);
        }

        // POST: api/<controller>
        [HttpPost]
        public async Task<ActionResult> AddPost([FromBody] PostForAdd postForAdd)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var recordedPost = await _postManager.Add(new Post
            {
                UserId = postForAdd.UserId,
                PostContent = postForAdd.PostContent,
                CreationDate = DateTime.Now,
                IsDeleted = false
            });
            if (recordedPost == null)
            {
                return NotFound();
            }
            return Ok(recordedPost);
        }

        // POST: api/<controller>
        [HttpPost]
        public async Task<ActionResult> UpdatePost([FromBody] Post postForUpdate)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            postForUpdate.UpdatedDate = DateTime.Now;
            var recordedPost = await _postManager.Add(postForUpdate);
            if (recordedPost == null)
            {
                return NotFound();
            }
            return Ok(recordedPost);
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
