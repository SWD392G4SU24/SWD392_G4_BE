using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.EmailModel
{
    [NotMapped]
    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public bool UseSsl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
