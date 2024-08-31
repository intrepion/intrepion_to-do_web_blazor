using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IBlogService
{
    Task<BlogPost?> GetBlogPostAsync(Guid id);
    Task<int> GetBlogPostCountAsync();
    Task<List<BlogPost>> GetBlogPostsAsync(int numberOfPosts, int startIndex);
    Task<List<Category>> GetCategoriesAsync();
    Task<Category?> GetCategoryAsync(Guid id);
    Task<List<Comment>> GetCommentsAsync(Guid blogPostId);
    Task<Tag?> GetTagAsync(Guid id);
    Task<List<Tag>> GetTagsAsync();
    Task<BlogPost?> SaveBlogPostAsync(BlogPost blogPost);
    Task<Category?> SaveCategoryAsync(Category category);
    Task<Comment?> SaveCommentAsync(Comment comment);
    Task<Tag?> SaveTagAsync(Tag tag);
    Task DeleteBlogPostAsync(Guid id);
    Task DeleteCategoryAsync(Guid id);
    Task DeleteCommentAsync(Guid id);
    Task DeleteTagAsync(Guid id);
}
