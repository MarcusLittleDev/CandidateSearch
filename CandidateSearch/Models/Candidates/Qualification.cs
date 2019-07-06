using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CandidateSearch.Models.Candidates;

namespace CandidateSearch.Models.Candidates
{
    public class Qualification
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        [DisplayName("Qualification Type")]
        public QualificationType Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        public int CandidateId {get;set;}
        [ForeignKey("CandidateId")]
        public Candidate Candidate { get; set; }
        #endregion

    }
}
