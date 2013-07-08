using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tyrannosaurus.Core.Domain
{
    [MetadataType(typeof(ObserveeValidation))]
    public class Observee
    {
        public virtual int ObserveeId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Observation> Observations { get; set; }
    }

    public class ObserveeValidation
    {
        [Required(ErrorMessage = "{0} is required")]
        public int ObserveeId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

    }
}