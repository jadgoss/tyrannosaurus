using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tyrannosaurus.Core.Domain
{
    [MetadataType(typeof(ObservationValidation))]
    public class Observation 
    {
        public virtual int ObservationId { get; set; }
        public virtual int ObserveeId { get; set; }
        public virtual Observee Observee { get; set; }
        public virtual DateTime ObservationDate { get; set; }
        public virtual float? Succinylacetone { get; set; }
        public virtual int? Tyrosine { get; set; }
        public virtual int? Phenylalanine { get; set; }
        public virtual float? Height { get; set; }
        public virtual float? Weight { get; set; }
        public virtual string Comment { get; set; }

    }

    public class ObservationValidation
    {

        public int ObserveeId { get; set; }

        [UIHint("ObserveeDropDown")]
        public string Observee { get; set; }

        [Required(ErrorMessage="Observation Date is required")]
        public DateTime ObservationDate { get; set; }

        [Range(0,10)]
        public float Succinylacetone { get; set; }

        [Range(0,2000)]
        public int Tyrosine { get; set; }

        [Range(0,100)]
        public int Phenylalanine { get; set; }

        [Range(0,300)]
        public float Height { get; set; }

        [Range(0,300)]
        public float Weight { get; set; }

        [MaxLength(300, ErrorMessage = "{0} must not exceed 300 characters")]
        public string Comment { get; set; }

    }
}