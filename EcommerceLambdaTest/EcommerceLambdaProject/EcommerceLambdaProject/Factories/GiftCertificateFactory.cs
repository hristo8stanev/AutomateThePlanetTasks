namespace EcommerceLambdaProject.Factories;
public class GiftCertificateFactory
{
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
