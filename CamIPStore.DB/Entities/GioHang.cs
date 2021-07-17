using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
   
    public class GioHang
    {
        public int IdCam { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Camera Camera { get; set; }
        public int IdTK { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public TaiKhoan TaiKhoan { get; set; }
        public int Sl { get; set; }
    }
}
