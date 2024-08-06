using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BPS_Shared.Models
{
    //[Keyless]

    public class Bill
    {
        [Key]
        public int B_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Company_Id { get; set; }

        public float B_Amount { get; set; }

        public DateTime? B_CreationDate { get; set; } = DateTime.Now;

        public DateTime? B_DueDate { get; set; }

        public bool B_Status { get; set; }

    }
}
