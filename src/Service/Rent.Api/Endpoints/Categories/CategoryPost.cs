using Rent.Data.Context;
using Rent.Domain.Entities;

namespace Rent.Api.Endpoints
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(CategoryRequest categoryRequest, RentContext context)
        {
            var category = new Category(categoryRequest.Name)
            {
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                EditedBy = "Test",
                EditedOn = DateTime.Now,
            };

            //Category is valid
            if (!category.IsValid)
                return Results.BadRequest(category.Notifications);

            context.Categories.Add(category);
            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}
