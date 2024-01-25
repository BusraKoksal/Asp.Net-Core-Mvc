using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;

namespace Abc.Northwind.MvcWebUI.Middlewares
{
    public static class SessionExtentions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
        // 4.9.23 Bu kod parçası, ASP.NET Core oturum (session) nesnesi üzerinde çalışan özel
        // genişletme (extension) yöntemlerini tanımlar. Bu genişletme yöntemleri,
        // bir nesneyi JSON formatında serileştirip oturumda saklamak ve oturumdan almak için kullanılır.
    }
}
