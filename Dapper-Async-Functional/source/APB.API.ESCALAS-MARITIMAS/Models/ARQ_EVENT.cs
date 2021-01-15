using System;
using System.Collections.Generic;

namespace APB.API.ESCALAS_MARITIMAS.Models
{
    public partial class ARQ_EVENT
    {
        public ARQ_EVENT()
        {
            InverseARQ_EVENT_PARENavigation = new HashSet<ARQ_EVENT>();
        }

        public int ARQ_EVENT_ID { get; set; }
        public string ARQ_USUARI_NI { get; set; }
        public string ARQ_EXPEDIENT_NI { get; set; }
        public string ARQ_EVENTTIPUS_NI { get; set; }
        public DateTime DATAEVENT { get; set; }
        public string DESCRIPCIO { get; set; }
        public string ARQ_APP_NI { get; set; }
        public string AUDIT_USER { get; set; }
        public string AUDIT_APP { get; set; }
        public DateTime AUDIT_DATAOPERACIOBBDD { get; set; }
        public string AUDIT_OPERACIOBBDD_NI { get; set; }
        public string ESBORRAT { get; set; }
        public int? ARQ_EVENT_PARE { get; set; }

        public virtual ARQ_EVENT ARQ_EVENT_PARENavigation { get; set; }
        public virtual ICollection<ARQ_EVENT> InverseARQ_EVENT_PARENavigation { get; set; }
    }
}
