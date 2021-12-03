using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Rent.Api.Endpoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(UserManager<IdentityUser> userManager)
        {
            var users = userManager.Users.ToList();

            var employees = new List<EmployeeResponse>();
            foreach (var item in users)
            {
                var claims = userManager.GetClaimsAsync(item).Result;
                var claimName = claims.FirstOrDefault(x => x.Type == "Name");
                var userName = claimName != null ? claimName.Value : string.Empty;
                employees.Add(new EmployeeResponse(item.Email, userName));
            }
            return Results.Ok(employees);
        }
    }
}
