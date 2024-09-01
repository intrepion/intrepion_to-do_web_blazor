using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services.Server;

public class BlogService : IBlogService
{
    public Task DeleteBlogPostAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCommentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTagAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost?> GetBlogPostAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetBlogPostCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogPost>> GetBlogPostsAsync(int numberOfPosts, int startIndex)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> GetCommentsAsync(Guid blogPostId)
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> GetTagAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetTagsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost?> SaveBlogPostAsync(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> SaveCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> SaveCommentAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> SaveTagAsync(Tag tag)
    {
        throw new NotImplementedException();
    }
}
