using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aws.Ses;

public class SesService:ISesService
{
    private readonly IConfiguration _configuration;
    private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;
    public SesService(IConfiguration configuration,IAmazonSimpleEmailService amazonSimpleEmailService)
    {
        _amazonSimpleEmailService = amazonSimpleEmailService;
        _configuration = configuration;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        Body mailBody = new(new Content(mailRequest.Body));
        Message message = new(new Content(mailRequest.Subject),mailBody);
        Destination destination = new([mailRequest.To]);
        SendEmailRequest request = new(_configuration["MailSettings:From"], destination, message);
        SendEmailResponse response = await _amazonSimpleEmailService.SendEmailAsync(request);
    }
}
