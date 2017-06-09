namespace Case.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        [Key]
        public int MessageID { get; set; }

        public string Message { get; set; }

        [StringLength(5)]
        public string EmptyMessage { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [StringLength(100)]
        public string MessageFrom { get; set; }

        [StringLength(100)]
        public string MessageTo { get; set; }
    }
}
