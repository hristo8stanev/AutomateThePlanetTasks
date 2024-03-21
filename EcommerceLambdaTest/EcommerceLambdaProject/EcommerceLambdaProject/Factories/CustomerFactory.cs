using Bogus;
using EcommerceLambdaProject.Pages.LoginPage;
using EcommerceLambdaProject.Pages.RegisterPage;


namespace EcommerceLambdaProject.Factories;
public static class CustomerFactory
{


    public static PersonalInformation UserDetails(string firstName = null, string lastName = null, string email = null, int? telephone = null, string password = null, string confirmPass = null)
    {
        var faker = new Faker<PersonalInformation>()

            .RuleFor(c => c.FirstName, f => firstName ?? f.Name.FirstName())
            .RuleFor(c => c.LastName, f => lastName ?? f.Name.LastName())
            .RuleFor(c => c.Email, (f, c) => email ?? f.Internet.Email(c.FirstName, c.LastName))
            .RuleFor(c => c.Password, f => password ?? f.Internet.Password())
            .RuleFor(c => c.ConfirmPassword, (f, c) => confirmPass ?? c.Password)
            .RuleFor(c => c.Telephone, f => "0728237123");

        return faker.Generate();
    }

    public static LoginInformation LoginUser(string email, string password)
    {
        var loginDetails = new LoginInformation();
        loginDetails.EmailAddress = email;
        loginDetails.PasswordField = password;

        return loginDetails;
    }
}