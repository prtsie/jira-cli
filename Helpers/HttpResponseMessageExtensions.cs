using System.Text.Json;

namespace JiraCli.Helpers;

public static class HttpResponseMessageExtensions
{
    private static JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };
    
    public static async Task<T?> Parse<T>(this HttpResponseMessage response)
    {
        var stream = await response.Content.ReadAsStreamAsync(); // Должно вывести имя
        return await JsonSerializer.DeserializeAsync<T>(stream, serializerOptions);
    }
}