namespace Portfolia.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LegitimationList")]
    public partial class LegitimationList
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        [Required]
        [StringLength(40)]
        public string Password { get; set; }

        public bool Used { get; set; }

        public DateTime? UsedDate { get; set; }
    }
}
