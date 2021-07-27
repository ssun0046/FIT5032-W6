using System;

// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
namespace SendEmail
{
    class Program
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            //var apiKey = "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";
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ssun0046@student.monash.edu", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("zzho0079@student.monash.edu", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body);
            Console.WriteLine(response.Headers);
        }
    }
}
