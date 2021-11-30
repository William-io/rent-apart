using Rent.Data.Context;

namespace Rent.Api.Endpoints
{
    public class CategoryRespose
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
