using Microsoft.AspNetCore.Mvc;
using Rent.Data.Context;

namespace Rent.Api.Endpoints
{
    public class CategoryPut
    {
        public static string Template => "/categories/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, RentContext context)
        {
            var category = context.Categories.Where(x => x.Id == id).FirstOrDefault();
            category.Name = categoryRequest.Name;
            category.Active = categoryRequest.Active;

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
