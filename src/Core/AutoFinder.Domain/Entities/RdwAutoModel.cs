using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinder.Domain.Entities
{
    public class RdwAutoModel
    {
        public string Kenteken { get; set; }
        public string Voertuigsoort { get; set; }
        public string Merk { get; set; }
        public string Handelsbenaming { get; set; }
        public string Vervaldatum_apk { get; set; }
        public string Datum_tenaamstelling { get; set; }
        public string Datum_eerste_toelating_dt { get; set; }
        public string Bruto_bpm { get; set; }
        public string Inrichting { get; set; }
        public string Aantal_zitplaatsen { get; set; }
        public string Eerste_kleur { get; set; }
    }
}
