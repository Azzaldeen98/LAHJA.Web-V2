using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
namespace Infrastructure.DataSource.ApiClient2;

public interface ICheckoutApiClient:  ITBaseApiClient  
{
public Task<CheckoutResponse> CreateCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken);

public Task<CheckoutResponse> ManageAsync(SessionCreate body, CancellationToken cancellationToken);

}

