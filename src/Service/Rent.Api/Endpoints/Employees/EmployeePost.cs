using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Rent.Api.Endpoints.Employees
{
    public class EmployeePost
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser { UserName = employeeRequest.Email, Email = employeeRequest.Email };

            var result = userManager.CreateAsync(user, employeeRequest.Password).Result;

            if (!result.Succeeded)
                return Results.BadRequest(result.Errors.First());


            //Funcionario William = codigo ID1234
            var claimResult = userManager.AddClaimAsync(user, new Claim("EmployeeCode", employeeRequest.EmployeeCode)).Result;

            //1. Validação logica, se o funcionario existe
            if (!claimResult.Succeeded)
                //Se não existir, retornar um error 
                return Results.BadRequest(claimResult.Errors.First());

            claimResult = userManager.AddClaimAsync(user, new Claim("Name", employeeRequest.Name)).Result;

            //2. Validação logica, localizando o funcionario por nome dê tudo certo....
            if (!claimResult.Succeeded)
                //Se não existir, retornar um error 
                return Results.BadRequest(claimResult.Errors.First());

            return Results.Created($"/employees/{user.Id}", user.Id);
        }
    }
}
