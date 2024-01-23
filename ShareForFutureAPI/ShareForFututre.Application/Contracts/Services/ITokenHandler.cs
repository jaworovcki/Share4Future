using ShareForFuture.Domain.DomainModels;

namespace ShareForFututre.Application.Contracts.Services;

public interface ITokenHandler
{
    string CreateAccessToken(User user, IEnumerable<string> roles);
}