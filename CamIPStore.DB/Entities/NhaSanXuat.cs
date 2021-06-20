using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{

    public class NhaSanXuat
    {
        public int IdNSX { get; set; }
        public string TenNSX { get; set; }
        public List<Camera> DsCamera { get; set; }
    }
}
