using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    // Ortak kullanılan fieldler için 
    // Bu fieldleri kullanmak isteyen entityler bu classtan miras alacak !
    public abstract class BaseEntity // New ile classtan obje üretmiyecekesk sınıfı soyut yapabiliriz. (abstract)
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } // Entity Create olduğunda updateddate null olmalı bu yüzden nullable açık "?" ile

    }
}
