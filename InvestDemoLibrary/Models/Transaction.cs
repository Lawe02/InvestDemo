using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestDemoLibrary.Models
{
    public enum TransactionType
    {
        Buy,
        Sell
    }

    public class Transaction
    {
        public int TransactionID { get; set; }

        // Assuming UserID is a string to align with ASP.NET Identity's IdentityUser
        [Required]
        public string UserID { get; set; }

        [Required]
        public int StockID { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public IdentityUser User { get; set; }
        public Stock Stock { get; set; }
    }
}