using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.EmailModel
{
    [Table("EmailVerification")]
    public class EmailVerification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmailVerificationId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }

        public required string CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public virtual UserEntity Customer { get; set; } = null!;
    }
}
