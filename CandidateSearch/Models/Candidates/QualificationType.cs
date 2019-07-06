using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandidateSearch.Models.Candidates
{
        public enum QualificationType
        {
            [Display(Name="Professional Certification")]
            ProfessionalCertication,
            [Display(Name = "Work Experience")]
            WorkExperience,
            [Display(Name = "College Degree")]
            CollegeDegree
        }
}
