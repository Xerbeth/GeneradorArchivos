using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorJsonSaber311.Dto
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Content { get; set; }
        public int OrderVisual { get; set; }
        public int Sesion { get; set; }
        public int Total { get; set; }
        public string TestName { get; set; }
        public string Type { get; set; }
        public string ItemNumero { get; set; }
        public int ItemChild { get; set; }
        public int Order { get; set; }
        public int TotalVisual { get; set; }
        public string RecursosItem { get; set; }
        public string IdEstado { get; set; }
        public int IdCombo { get; set; }
        public string Code { get; set; }

        public Item() { }

    }
}
