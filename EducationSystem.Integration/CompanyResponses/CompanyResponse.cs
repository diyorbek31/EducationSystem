namespace EducationSystem.Integration.CompanyResponses;

public class CompanyResponse
{
    public string? Tin { get; set; }
    public decimal Fund { get; set; }
    public string? Name { get; set; }
    public string? Okpo { get; set; }
    public string? RegNum { get; set; }
    public string? Account { get; set; }
    public string? Address { get; set; }
    public string? DateTin { get; set; }
    public int MriCode { get; set; }
    public string? RegDate { get; set; }
    public string? NameFull { get; set; }
    public string? HeadPinfl { get; set; }
    public int StateCode { get; set; }
    public string? StateName { get; set; }
    public int TaxRegime { get; set; }
    public int RegionCode { get; set; }
    public string? RegionName { get; set; }
    public int StatusCode { get; set; }
    public string? StatusName { get; set; }
    public int CriteriaAll { get; set; }
    public string? DirectorTin { get; set; }
    public string? CriteriaType { get; set; }
    public int DistrictCode { get; set; }
    public string? DistrictName { get; set; }
    public string? AccountantTin { get; set; }
    public string? DirectorPinfl { get; set; }
    public string? AccountantPinfl { get; set; }
    public string? DirectorTelHome { get; set; }
    public string? DirectorTelWork { get; set; }
    public int ActivityTypeCode { get; set; }
    public string? ActivityTypeName { get; set; }
    public string? BankNameInternal { get; set; }
    public string? DirectorFullName { get; set; }
    public int TaxpayerTypeCode { get; set; }
    public string? TaxpayerTypeName { get; set; }
    public string? AccountantTelHome { get; set; }
    public string? AccountantTelWork { get; set; }
    public int OwnershipFormCode { get; set; }
    public string? OwnershipFormName { get; set; }
    public string? AccountantFullName { get; set; }
    public int ActivityStatusCode { get; set; }
    public string? ActivityStatusName { get; set; }
    public string? EconomicActivityName { get; set; }
    public string? GovernmentAgencyCode { get; set; }
    public string? RegistrationRegionName { get; set; }
    public string? InterbankTransferMfoCode { get; set; }
    public string? EconomicActivityOkvedCode { get; set; }
    public int TertiaryClassificationCode { get; set; }
    public string? TertiaryClassificationName { get; set; }
    public string? RegistrationRegionOkatoCode { get; set; }
    public List<StaffInfo> StaffInfos { get; set; } = new();
}
public class StaffInfo
{
    public int Year { get; set; } = default!;
    public int Month { get; set; } = default!;

    public decimal? PaidSalary { get; set; }

    public int? StaffCount { get; set; }

    public int? StaffCountPaid { get; set; }
}