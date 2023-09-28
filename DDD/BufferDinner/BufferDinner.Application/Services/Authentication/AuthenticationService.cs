using BufferDinner.Application.Common.Interfaces.Authentication;
namespace BufferDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

/// <summary>
    /// Represents the result of an authentication operation.
    /// </summary>
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user exists

        // create user (generate unique id)

        // Create JWT token
        
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(
            userId,
            firstName,
            lastName
        );

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );

    }

    public AuthenticationResult Login(string email, string password)
    {
      return new AuthenticationResult(
            UserId: Guid.NewGuid(),
            FirstName: "firstName",
            LastName: "lastName",
            Email: email,
            Token: "token"
        );
    }

    
}

