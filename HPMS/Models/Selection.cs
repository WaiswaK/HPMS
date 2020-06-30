using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPMS.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum Line
    {
        One,
        Two,
        Three
    }

    public enum Reason
    {
        Toxicity_or_side_effects,
        Due_to_new_TB,
        New_Drug_available,
        Drug_out_of_stock,
        Clinical_failure,
        Immunological_failure,
        Virological_failure,
        HIV_Drug_resistance,
        Other_reasons
    }

    public enum PosNeg
    {
        Positive,
        Negative
    }

    public enum Pregnancy
    {
        Pregnant,
        Not_pregnant
    }
}