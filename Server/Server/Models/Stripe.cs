
namespace DotNetServer
{


            public class CheckoutSessionRequest
    {
        public required string PriceId { get; set; }

        public static implicit operator string(CheckoutSessionRequest v)
        {
            throw new NotImplementedException();
        }
    }
}        
        
