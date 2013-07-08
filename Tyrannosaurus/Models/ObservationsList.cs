using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tyrannosaurus.UI.Models
{

    public class ObservationsList
    {
        public virtual int ObservationId { get; set; }
        public virtual string ObserveeName { get; set; }
        public virtual DateTime ObservationDate { get; set; }
        public virtual float? Succinylacetone { get; set; }
        public virtual int? Tyrosine { get; set; }
        public virtual int? Phenylalanine { get; set; }
        public virtual float? Height { get; set; }
        public virtual float? Weight { get; set; }
        public virtual string Comment { get; set; }
    }

}