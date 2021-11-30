namespace Rent.Api.Endpoints
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
