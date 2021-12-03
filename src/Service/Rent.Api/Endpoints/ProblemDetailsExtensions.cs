using Flunt.Notifications;

namespace Rent.Api.Endpoints
{
    public static class ProblemDetailsExtensions
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
        {
            return notifications.GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(s => s.Message).ToArray());

        }
    }
}