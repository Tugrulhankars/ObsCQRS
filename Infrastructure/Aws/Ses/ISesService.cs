using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aws.Ses;

public interface ISesService
{
    public Task SendEmailAsync(MailRequest mailRequest);
}
