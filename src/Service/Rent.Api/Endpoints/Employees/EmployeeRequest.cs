namespace Rent.Api.Endpoints.Employees
{
    //EmployeeCode - Codigo do empregado
    public record EmployeeRequest(string Email, string Password, string Name, string EmployeeCode);
}
