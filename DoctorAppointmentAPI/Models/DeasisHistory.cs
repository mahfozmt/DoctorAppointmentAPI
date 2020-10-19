using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class DeasisHistory
    {
        public int DeasisHistoryId { get; set; }
        [ForeignKey("Pateint")]
        public int PateintId { get; set; }

        [Display(Name = "Deasis Histories")]
        public string DeasisHistories { get; set; }

        //nev
        public virtual Pateint Pateint { get; set; }
        //public virtual List<Pateint> Pateints { get; set; }
    }
}
