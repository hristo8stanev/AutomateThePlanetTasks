﻿namespace EcommerceLambdaProject.Factories;

public static class CustomerFactory
{
    public static PersonalInformation GenerateUserDetails(string firstName = null, string lastName = null, string email = null, int? telephone = null, string password = null, string confirmPass = null)
    {
        var faker = new Faker<PersonalInformation>()

            .RuleFor(c => c.FirstName, f => firstName ?? f.Name.FirstName())
            .RuleFor(c => c.LastName, f => lastName ?? f.Name.LastName())
            .RuleFor(c => c.Email, (f, c) => email ?? f.Internet.Email(c.FirstName, c.LastName))
            .RuleFor(c => c.Password, f => password ?? f.Internet.Password())
            .RuleFor(c => c.ConfirmPassword, (f, c) => confirmPass ?? c.Password)
            .RuleFor(c => c.Telephone, f => "08899772233");
        return faker.Generate();
    }

    public static BillingInformation GenerateBillingAddress(string firstName = null, string lastName = null, string company = null, string address1 = null, string address2 = null, string City = null,
        string PostCode = null, string Country = null, string Region = null)
    {
        var faker = new Faker<BillingInformation>()
            .RuleFor(c => c.FirstName, f => firstName ?? f.Name.FirstName())
            .RuleFor(c => c.LastName, f => lastName ?? f.Name.LastName())
            .RuleFor(c => c.Company, f => company ?? f.Company.CompanyName())
            .RuleFor(c => c.Address1, f => address1 ?? f.Address.StreetAddress())
            .RuleFor(c => c.Address2, f => address2 ?? f.Address.FullAddress())
            .RuleFor(c => c.City, f => City ?? f.Address.City())
            .RuleFor(c => c.PostCode, f => "90004")
            .RuleFor(c => c.Country, f => "United Kingdom")
            .RuleFor(c => c.Region, f => "London");
        return faker.Generate();
    }

    public static LoginInformation LoginUser(string email, string password)
    {
        var loginDetails = new LoginInformation();
        loginDetails.EmailAddress = email;
        loginDetails.PasswordField = password;
        return loginDetails;
    }

   
    public static PurchaseGiftCertificate GenerateGiftCertificate(string recipientName = null, string recipientEmail = null, string name = null, string email = null, string amount = null)
    {
        var faker = new Faker<PurchaseGiftCertificate>()
           .RuleFor(c => c.RecipientName, f => recipientName ?? f.Name.FirstName())
           .RuleFor(c => c.RecipientEmail, f => recipientEmail ?? f.Internet.Email())
           .RuleFor(c => c.YourName, f => name ?? f.Name.FirstName())
           .RuleFor(c => c.YourEmail, f => email ?? f.Internet.Email())
           .RuleFor(c => c.Amount, f => "300");
        return faker.Generate();
    }
}