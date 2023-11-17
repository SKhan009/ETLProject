using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;

namespace YSU.Models
{
  
        // RootTag class represents the root element in the XML
        [XmlRoot("rootTag")]
        public class RootTag
        {
            [XmlElement("Award")]
            public Award? Award { get; set; }
        }

        // Award class represents the Award element in the XML
        public class Award
        {
            [XmlElement("AwardTitle")]
            public string? AwardTitle { get; set; }

            [XmlElement("AGENCY")]
            public string? Agency { get; set; }

            [XmlElement("AwardEffectiveDate")]
            public string? AwardEffectiveDate { get; set; }

            // Add a computed property for AwardEffectiveDate as DateTime
            [XmlIgnore]
            public DateTime? AwardEffectiveDateTime
            {
                get
                {
                    if (!string.IsNullOrEmpty(AwardEffectiveDate) &&
                        DateTime.TryParseExact(AwardEffectiveDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    {
                        return result;
                    }

                    return null; // or any default value if parsing fails
                }
            }

        [XmlElement("AwardExpirationDate")]
        public string? AwardExpirationDate { get; set; }

        // Add a computed property for AwardEffectiveDate as DateTime
        [XmlIgnore]
        public DateTime? AwardExpirationDateTime
        {
            get
            {
                if (!string.IsNullOrEmpty(AwardEffectiveDate) &&
                    DateTime.TryParseExact(AwardEffectiveDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }

                return null; // or any default value if parsing fails
            }
        }


        [XmlElement("AwardTotalIntnAmount")]
            public decimal AwardTotalIntnAmount { get; set; }

            [XmlElement("AwardAmount")]
            public int AwardAmount { get; set; }

            [XmlElement("AwardInstrument")]
            public AwardInstrument? AwardInstrument { get; set; }

            [XmlElement("Organization")]
            public Organization? Organization { get; set; }

            [XmlElement("ProgramOfficer")]
            public ProgramOfficer? ProgramOfficer { get; set; }

            [XmlElement("AbstractNarration")]
            public string? AbstractNarration { get; set; }

            [XmlElement("ARRAAmount")]
            public string? ARRAAmount { get; set; }

            [XmlElement("TRAN_TYPE")]
            public string? TransactionType { get; set; }

            [XmlElement("CFDA_NUM")]
            public string? CFDANumber { get; set; }

            [XmlElement("NSF_PAR_USE_FLAG")]
            public int NSFParUseFlag { get; set; }

            [XmlElement("FUND_AGCY_CODE")]
            public string? FundAgencyCode { get; set; }

            [XmlElement("AWDG_AGCY_CODE")]
            public string? AwardAgencyCode { get; set; }

            [XmlElement("AwardID")]
            public string? AwardID { get; set; }

            [XmlElement("Investigator")]
            public Investigator? Investigator { get; set; }

            [XmlElement("Institution")]
            public Institution? Institution { get; set; }

            [XmlElement("Performance_Institution")]
            public PerformanceInstitution? PerformanceInstitution { get; set; }

            [XmlElement("ProgramElement")]
            public ProgramElement? ProgramElement { get; set; }

            [XmlElement("ProgramReference")]
            public ProgramReference? ProgramReference { get; set; }

            [XmlElement("Appropriation")]
            public Appropriation? Appropriation { get; set; }

            [XmlElement("Fund")]
            public Fund? Fund { get; set; }

            [XmlElement("FUND_OBLG")]
            public string? FundObligation { get; set; }
        }

        public class AwardInstrument
        {
            [XmlElement("Value")]
            public string? Value { get; set; }
        }

        public class Organization
        {
            [XmlElement("Code")]
            public string? Code { get; set; }

            [XmlElement("Directorate")]
            public Directorate? Directorate { get; set; }

            [XmlElement("Division")]
            public Division? Division { get; set; }
        }

        public class Directorate
        {
            [XmlElement("Abbreviation")]
            public string? Abbreviation { get; set; }

            [XmlElement("LongName")]
            public string? LongName { get; set; }
        }

        public class Division
        {
            [XmlElement("Abbreviation")]
            public string? Abbreviation { get; set; }

            [XmlElement("LongName")]
            public string? LongName { get; set; }
        }

        public class ProgramOfficer
        {
            [XmlElement("SignBlockName")]
            public string? SignBlockName { get; set; }

            [XmlElement("PO_EMAI")]
            public string? POEmail { get; set; }

            [XmlElement("PO_PHON")]
            public string? POPhone { get; set; }
        }

        public class Investigator
        {
            [XmlElement("FirstName")]
            public string? FirstName { get; set; }

            [XmlElement("LastName")]
            public string? LastName { get; set; }

            [XmlElement("PI_MID_INIT")]
            public string? PIMiddleInitial { get; set; }

            [XmlElement("PI_SUFX_NAME")]
            public string? PISuffixName { get; set; }

            [XmlElement("PI_FULL_NAME")]
            public string? PIFullName { get; set; }

            [XmlElement("EmailAddress")]
            public string? EmailAddress { get; set; }

            [XmlElement("NSF_ID")]
            public string? NSFID { get; set; }

            [XmlElement("RoleCode")]
            public string? RoleCode { get; set; }
        }

        public class Institution
        {
            [XmlElement("Name")]
            public string? Name { get; set; }

            [XmlElement("CityName")]
            public string? CityName { get; set; }

            [XmlElement("ZipCode")]
            public string? ZipCode { get; set; }

            [XmlElement("PhoneNumber")]
            public string? PhoneNumber { get; set; }

            [XmlElement("StreetAddress")]
            public string? StreetAddress { get; set; }

            [XmlElement("StreetAddress2")]
            public string? StreetAddress2 { get; set; }

            [XmlElement("CountryName")]
            public string? CountryName { get; set; }

            [XmlElement("StateName")]
            public string? StateName { get; set; }

            [XmlElement("StateCode")]
            public string? StateCode { get; set; }

            [XmlElement("CONGRESSDISTRICT")]
            public string? CongressDistrict { get; set; }

            [XmlElement("CONGRESS_DISTRICT_ORG")]
            public string? CongressDistrictOrg { get; set; }

            [XmlElement("ORG_UEI_NUM")]
            public string? OrganizationUEINumber { get; set; }

            [XmlElement("ORG_LGL_BUS_NAME")]
            public string? OrganizationLegalBusinessName { get; set; }

            [XmlElement("ORG_PRNT_UEI_NUM")]
            public string? OrganizationParentUEINumber { get; set; }
        }

        public class PerformanceInstitution
        {
            [XmlElement("Name")]
            public string? Name { get; set; }

            [XmlElement("CityName")]
            public string? CityName { get; set; }

            [XmlElement("StateCode")]
            public string? StateCode { get; set; }

            [XmlElement("ZipCode")]
            public string? ZipCode { get; set; }

            [XmlElement("StreetAddress")]
            public string? StreetAddress { get; set; }

            [XmlElement("CountryCode")]
            public string? CountryCode { get; set; }

            [XmlElement("CountryName")]
            public string? CountryName { get; set; }

            [XmlElement("StateName")]
            public string? StateName { get; set; }

            [XmlElement("CountryFlag")]
            public int CountryFlag { get; set; }

            [XmlElement("CONGRESSDISTRICT")]
            public string? CongressDistrict { get; set; }

            [XmlElement("CONGRESS_DISTRICT_PERF")]
            public string? CongressDistrictPerformance { get; set; }
        }

        public class ProgramElement
        {
            [XmlElement("Code")]
            public string? Code { get; set; }

            [XmlElement("Text")]
            public string? Text { get; set; }
        }

        public class ProgramReference
        {
            [XmlElement("Code")]
            public string? Code { get; set; }

            [XmlElement("Text")]
            public string? Text { get; set; }
        }

        public class Appropriation
        {
            [XmlElement("Code")]
            public string? Code { get; set; }

            [XmlElement("Name")]
            public string? Name { get; set; }

            [XmlElement("APP_SYMB_ID")]
            public string? AppSymbolID { get; set; }
        }

        public class Fund
        {
            [XmlElement("Code")]
            public string? Code { get; set; }

            [XmlElement("Name")]
            public string? Name { get; set; }

            [XmlElement("FUND_SYMB_ID")]
            public string? FundSymbolID { get; set; }
        }
}
