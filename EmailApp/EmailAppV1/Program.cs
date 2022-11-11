using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        var sender = new SmtpSender(() => new SmtpClient(host: "localhost")
        {
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Port = 25
        });

        StringBuilder template = new();
        template.Append(value: "Dear @Model.FirstName,");
        template.AppendLine(value: "<p>Thanks for purchasing @ Model.ProductName. Please take a moment to let us know how you like it.</p>");
        template.AppendLine(value: "- The Client Company");

        Email.DefaultSender = sender;

        var email = await Email
            .From(emailAddress: "client@test.com")
            .To(emailAddress: "customer@test.com", name: "Jane Doe")
            .Subject(subject: "Thank You")
            .UsingTemplate(template.ToString(), new { FirstName = "Jane", ProductName = "G50 Sewing Machine" })
            .SendAsync();

        email.ErrorMessages;
    }
}