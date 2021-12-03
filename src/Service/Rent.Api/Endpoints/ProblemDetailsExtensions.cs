using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace Rent.Api.Endpoints
{
    public static class ProblemDetailsExtensions
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
        {
            return notifications.GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(s => s.Message).ToArray());
        }

        public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
        {
            var dictionary = new Dictionary<string, string[]>();
            dictionary.Add("Error", error.Select(s => s.Description).ToArray());

            return dictionary;
        }
    }
}