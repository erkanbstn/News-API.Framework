using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        [Key]
        public int Id { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

    }
}
