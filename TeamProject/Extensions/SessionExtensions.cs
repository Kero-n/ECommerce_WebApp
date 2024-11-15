using Microsoft.AspNetCore.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace TeamProject.Extensions
{
    public static class SessionExtensions
    {
        // Get the value from session safely with a null check.
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default!; // Return the default value for the type if null
            }
            return JsonSerializer.Deserialize<T>(value) ?? default!; 
        }

        // Set the value to session
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
    }
}
