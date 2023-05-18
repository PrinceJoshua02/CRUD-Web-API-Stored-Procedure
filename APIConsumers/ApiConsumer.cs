using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class ApiConsumer
{
    public async Task ConsumeApiWithJwtToken()
    {
        // Create an instance of HttpClient
        using var httpClient = new HttpClient();

        // Set the JWT token in the Authorization header
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your-jwt-token");

        // Make the request to the API endpoint
        var response = await httpClient.GetAsync("https://localhost:5001/api/products/1");

        // Process the response
        var content = await response.Content.ReadAsStringAsync();

        Console.WriteLine(content);
    }
}
