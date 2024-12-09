using System.Text;
using System.Text.Json;

namespace Webhook.Demo.Sender;

class Program
{
    static async Task Main(string[] args)
    {
        // Receiver endpoint
        var webhookUrl = "http://localhost:5095/api/Webhook";

        // Sample payload to send
        var payload = new
        {
            Event = "TestEvent",
            Timestamp = DateTime.UtcNow,
            Data = new { Message = "Hello from the sender!" }
        };

        // Send the webhook
        await SendWebhookAsync(webhookUrl, payload);
    }

    static async Task SendWebhookAsync(string url, object payload)
    {
        using var httpClient = new HttpClient();

        try
        {
            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Webhook sent successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to send webhook. Status: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending webhook: {ex.Message}");
        }
    }
}
