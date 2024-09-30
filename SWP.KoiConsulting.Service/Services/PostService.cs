using SWP.KoiConsulting.Repository;
using SWP.KoiConsulting.Repository.Models;
using SWP.KoiConsulting.Service.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.KoiConsulting.Service.Services
{
    public class PostService
    {
        private readonly UnitOfWork _unitOfWork;

        public PostService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostModel>> GetPostAsync()
        {
            var posts = await _unitOfWork.Posts.GetAsync();
            return posts.Select(post => new PostModel
            {
                Id = post.Id,
                Title = post.Title,
                Detail = post.Detail,
            });
        }

        public async Task<PostModel> GetPostByIdAsync(int id)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null) return null;

            return new PostModel
            {
                Id = post.Id,
                Title = post.Title,
                Detail = post.Detail,
            };
        }

        public async Task<bool> UpdatePostAsync(int id, PostModel postModel)
        {
            var postToUpdate = await _unitOfWork.Posts.GetByIdAsync(id);
            if (postToUpdate == null) return false;

            postToUpdate.Title = postModel.Title;
            postToUpdate.Detail = postModel.Detail;

            _unitOfWork.Posts.Update(postToUpdate);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<int> InsertPostAsync(PostModel postModel)
        {
            var postEntity = new Post
            {
                Title = postModel.Title,
                Detail = postModel.Detail
            };

            await _unitOfWork.Posts.InsertAsync(postEntity);
            await _unitOfWork.SaveAsync();
            return postEntity.Id;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null) return false;

            _unitOfWork.Posts.Delete(post);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
