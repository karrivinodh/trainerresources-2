using EcommerceWebsiteDemo.Core.Entities.OrderAggregate;
using EcommerceWebsiteDemo.Core.Entities;

namespace EcommerceWebsiteDemo.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
