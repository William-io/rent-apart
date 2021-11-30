using Microsoft.AspNetCore.Mvc;
using Rent.Data.Context;

namespace Rent.Api.Endpoints
{
    public class CategoryDelete
    {
        public static string Template => "/categories/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, RentContext context)
        {
            var category = context.Categories.Where(x => x.Id == id).FirstOrDefault();

            context.Categories.Remove(category);
            context.SaveChanges();

            return Results.Ok("Categoria deletada com sucesso!");
        }
    }
}
