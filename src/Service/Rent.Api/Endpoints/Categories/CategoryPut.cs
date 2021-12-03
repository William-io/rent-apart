using Microsoft.AspNetCore.Mvc;
using Rent.Data.Context;

namespace Rent.Api.Endpoints
{
    public class CategoryPut
    {
        public static string Template => "/categories/{id:Guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, RentContext context)
        {
            var category = context.Categories.Where(x => x.Id == id).FirstOrDefault();

            //Se o ID não existir, retorna erro
            if (category == null)
                return Results.NotFound();

            category.EditInfo(categoryRequest.Name, categoryRequest.Active);

            if (!category.IsValid)
                return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
