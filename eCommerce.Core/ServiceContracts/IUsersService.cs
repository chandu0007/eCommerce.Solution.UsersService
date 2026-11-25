
using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Contract for users service that contains use cases for users
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case and returns an AuthenticationResponse that contains status of login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle Users Registration use case and returns an object of 
    /// AuthenticationResponse type that represents status of user registration
    /// </summary>
    /// <param name="registerrequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse> Register(RegisterRequest registerrequest);
}
