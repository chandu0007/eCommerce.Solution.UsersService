using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
namespace eCommerce.Infrastructure.Repositories;
/// <summary>
/// 
/// </summary>
public class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") " +
            "VALUES (@UserID,@Email,@PersonName,@Gender,@Password)";
        var rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query,user);
        if(rowCountAffected>0)
        {
            return user;
        }
        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query ="SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var paramters = new { Email = email, Password = password };
        ApplicationUser? applicationUser = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, paramters);
        return applicationUser;


    }
}
