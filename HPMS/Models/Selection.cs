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
    public enum Special_Category
    {
        Uniformed_forces,
        AGYW,
        Fisher_folk,
        Long_distance_driver,
        Migrant_worker,
        Prisoners,
        Refugee,
        People_with_Disability,
        People_who_inject_drugs,
        Other
    }
    public enum Marital_Status
    {
        Single,
        Married,
        Divorced,
        Separated,
        Widowed,
        Not_Applicable
    }
    public enum Yes_No
    {
        Yes,
        No
    }
    public enum Relationship
    {
        Wife,
        Husband,
        Parent,
        Other_Relative
    }
}