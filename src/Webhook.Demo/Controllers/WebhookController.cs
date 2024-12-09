using Microsoft.AspNetCore.Mvc;

namespace Webhook.Demo.Controllers;

[ApiController]
[Route ("api/webhook")]
public class WebhookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ReceiveWebhook([FromBody] object payload)
    {
        // Log the received payload (optional)
        Console.WriteLine("Webhook received:");
        Console.WriteLine(payload);

        // TODO: Process the payload as needed
        // E.g., save to database, trigger other services, etc.

        // Return a success response
        return Ok(new { message = "Webhook received successfully!" });
    }
}