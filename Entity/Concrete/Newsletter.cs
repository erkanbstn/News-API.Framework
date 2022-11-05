using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Newsletter : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation Propertie
        public User User { get; set; }

        // Relationship on User
        public int UserID { get; set; }

        // Relationship on NewsImage
        public bool IsActive { get; set; }
    }
}
