using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    internal class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Stock { get; set; }
        public decimal Price { get; set; }
        public decimal CategoryId { get; set; } // EF Core otomatik olarak isimlendirmeyi anlar ve Foreign key olarak ayarlar.
        public Category Category{ get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}
