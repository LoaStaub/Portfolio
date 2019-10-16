using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolia.Models.DbModels
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}