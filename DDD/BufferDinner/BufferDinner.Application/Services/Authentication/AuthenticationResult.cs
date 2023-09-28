namespace BufferDinner.Application.Services.Authentication;

    public record AuthenticationResult(
        Guid UserId,
        string FirstName,
        string LastName,
        string Email,
        string Token);
    

// public class AuthenticationResult
// {
//     public AuthenticationResult(
//         Guid userId,
//         string firstName,
//         string lastName,
//         string token)
//     {
//         UserId = userId;
//         FirstName = firstName;
//         LastName = lastName;
//         Token = token;
//     }

//     public Guid UserId { get; }
//     public string FirstName { get; }
//     public string LastName { get; }
//     public string Token { get; }
// }

