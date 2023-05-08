namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Audio")]
    public partial class Audio
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public byte[] Date { get; set; }
    }
}
