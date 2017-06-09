namespace Case.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RssPage")]
    public partial class RssPage
    {
        public int Id { get; set; }

        public string RssLink { get; set; }

        [Column(TypeName = "xml")]
        public string ContentXml { get; set; }
    }
}
