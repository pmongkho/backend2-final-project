using Microsoft.AspNetCore.Mvc;
using DotNetServer.Models;
using DotNetServer.Services;
using System.Threading.Tasks;
using Stripe;
using DotNetServer;


[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;
    private readonly IConfiguration _configuration;

    public PaymentController(PaymentService paymentService, IConfiguration configuration)
    {
        _paymentService = paymentService;
        _configuration = configuration;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _paymentService.GetAllPaymentsAsync());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null) return NotFound();

        return Ok(payment);
    }

    // [HttpPost]
    // public async Task<IActionResult> Create(Payment payment)
    // {
    //     await _paymentService.CreateAsync(payment);
    //     return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
    // }

    [HttpPost("CreateCheckoutSesh")]
public IActionResult CreatePaymentLink([FromBody] CheckoutSessionRequest request)
{
        StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

  var customerStripeId = "cus_PBRMSVMHM9WgZH"; // Replace with your actual customer ID.

var options = new Stripe.Checkout.SessionCreateOptions
{
    SuccessUrl = "http://localhost:4200/get-drone",
    CancelUrl = "http://localhost:4200/get-drone",
    Customer = customerStripeId, // Set the customer ID here.
    PaymentMethodTypes = new List<string> {
        "card",
    },
    LineItems =
    [
        new() {
            Price = request.PriceId,
            Quantity = 1,
        },
    ],
    Mode = "payment",
};

var service = new Stripe.Checkout.SessionService();
var session = service.Create(options);

    return Ok(new { paymentLinkUrl = session.Url });
}

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Payment payment)
    {
        await _paymentService.UpdateAsync(id, payment);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _paymentService.RemoveAsync(id);
        return NoContent();
    }
}