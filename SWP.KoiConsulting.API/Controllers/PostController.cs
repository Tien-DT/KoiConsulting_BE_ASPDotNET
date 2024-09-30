using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.KoiConsulting.Service.Services;
using SWP.KoiConsulting.API.RequestModel;
using SWP.KoiConsulting.API.ResponseModel;
using SWP.KoiConsulting.Repository.Models;
using SWP.KoiConsulting.Service.BusinessModels;
using Microsoft.Extensions.Hosting;

namespace SWP.KoiConsulting.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        //CREATE Posts
        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult> CreatePost(PostRequestModel request)
        {
            var postModel = new PostModel
            {
                Title = request.Title,
                Detail = request.Detail,
                ElementId = request.ElementId,
                UserId = request.UserId,
                KoiId = request.KoiId
            };

            var rs = await _postService.InsertPostAsync(postModel);
            postModel.Id = rs;
            return CreatedAtAction(nameof(GetPostById), new { id = postModel.Id }, postModel);
        }

        //GET Post
        [HttpGet]
        [Route("Posts")]
        public async Task<ActionResult<IEnumerable<PostResponseModel>>> GetPosts()
        {
            var posts = await _postService.GetPostAsync();
            var response = posts.Select(post => new PostResponseModel
            {
                Id = post.Id,
                UserId = post.UserId,
                OrderId = post.OrderId,
                Title = post.Title,
                Detail = post.Detail,
                CreatedTime = post.CreatedTime,
                ExpTime = post.ExpTime,
                ElementId = post.ElementId,
                KoiId = post.KoiId,
                Status = post.Status
            });

            return Ok(response);
        }

        //GET Post
        [HttpGet]
        [Route("Post/{id}")]

        public async Task<ActionResult<PostResponseModel>> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();

            var response = new PostResponseModel
            {
                Id = post.Id,
                UserId = post.UserId,
                OrderId = post.OrderId,
                Title = post.Title,
                Detail = post.Detail,
                CreatedTime = post.CreatedTime,
                ExpTime = post.ExpTime,
                ElementId = post.ElementId,
                KoiId = post.KoiId,
                Status = post.Status
            };

            return Ok(response);
        }

        //UPDATE Post
        [HttpPut]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(int id, PostRequestModel request)
        {
            var postModel = new PostModel
            {
                Title = request.Title,
                Detail = request.Detail
            };

            var success = await _postService.UpdatePostAsync(id, postModel);
            if (!success) return NotFound();

            return Ok(success);
        }

        //DELETE Post
        [HttpDelete]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var success = await _postService.DeletePostAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
