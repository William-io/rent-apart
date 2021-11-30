using Rent.Data.Context;

namespace Rent.Api.Endpoints
{
    public class CategoryGetAll
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(RentContext context)
        {
            var categories = context.Categories.ToList();
            //Privacidade para não retonar a lista de categoria entidade.
            var response = categories.Select(c => new CategoryRespose { Id = c.Id, Name = c.Name, Active = c.Active });

            return Results.Ok(response);
        }
    }
}
