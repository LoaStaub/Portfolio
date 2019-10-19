using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolia.Models
{
    public partial class Files
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}