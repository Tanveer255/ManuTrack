using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcessFlow.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebhookController : ControllerBase
{
    //[HttpPost("stripe")]
    //public async Task<IActionResult> StripeWebhook()
    //{
    //    var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
    //    var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], "whsec_...");
    //    switch (stripeEvent.Type)
    //    {
    //        case "checkout.session.completed":
    //            var session = stripeEvent.Data.Object as Session;
    //            // Fulfill the purchase...
    //            break;
    //        case "payment_intent.succeeded":
    //            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
    //            // Fulfill the purchase...
    //            break;
    //        default:
    //            // Handle other event types...
    //            break;
    //    }
    //    return Ok();
    //}
}
