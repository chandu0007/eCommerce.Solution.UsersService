using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email,loginRequest.Password);
        if(user==null)
        {
            return null;
        }
        return new AuthenticationResponse(user.UserID, user.Email, user.PersonName,user.Gender,"token",Success:true);
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest registerrequest)
    {
        // Create a new Applicationuser object from RegisterRequest
        ApplicationUser user = new ApplicationUser()
        {
            PersonName= registerrequest.PersonName,
            Email = registerrequest.Email,
            Password = registerrequest.Password,
            Gender = registerrequest.Gender.ToString()
        };
        ApplicationUser? registerdUser= await _usersRepository.AddUser(user);
        if (registerdUser == null)
        {
            return null;
        }
        return new AuthenticationResponse(
            registerdUser.UserID, 
            registerdUser.Email, 
            registerdUser.PersonName, 
            registerdUser.Gender, "token", Success: true);
    }
}
