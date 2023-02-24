using GameShopDA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopBI.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
    }
}
