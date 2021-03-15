using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Categoria
    {
        [JsonProperty("cd_cat")]
        public int cd_cat { get; set; }

        [JsonProperty("nm_cat")]
        public string nm_cat { get; set; }

        [JsonProperty("img_cat")]
        public string img_cat { get; set; }
    }
}
