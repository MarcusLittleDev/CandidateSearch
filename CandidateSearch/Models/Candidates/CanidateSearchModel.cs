using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CandidateSearch.Models.Candidates
{
    public class CandidateSearchModel
    {
        public List<Candidate> Candidates { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [DisplayName("Qualification Type")]
        public QualificationType? Type { get; set; }
        [DisplayName("Qualification Name")]
        public string QualificationName { get; set; }
        [DisplayName("Qualification Start")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Qualification End")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Method for searching the database for canidates depending on the search criteria entered on the page
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IQueryable<Candidate> GetCandidatesFromSearch(CandidateSearchContext context)
        {
            var result = context.Candidate.AsQueryable();

            if (!string.IsNullOrWhiteSpace(this.FirstName))
            {
                result = result.Where(c => c.FirstName.Contains(this.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(this.LastName))
            {
                result = result.Where(c => c.LastName.Contains(this.LastName));
            }

            if (!string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                result = result.Where(c => c.EmailAddress.Contains(this.EmailAddress));
            }

            if (!string.IsNullOrWhiteSpace(this.PhoneNumber))
            {
                result = result.Where(c => c.PhoneNumber.Contains(this.PhoneNumber));
            }

            if (!string.IsNullOrWhiteSpace(this.ZipCode))
            {
                result = result.Where(c => c.ZipCode.Contains(this.ZipCode));
            }

            if (!string.IsNullOrWhiteSpace(this.QualificationName))
            {

                result = result.Where(c => c.Qualifications.Any(q => q.Name.Contains(this.QualificationName)));
                
            }

            if (this.Type.HasValue)
            {
                result = result.Where(c => c.Qualifications.Any(q => q.Type == this.Type));
            }

            if (this.StartDate.HasValue)
            {
                result = result.Where(c => c.Qualifications.Any(q => q.StartDate >= this.StartDate));
            }

            if (this.EndDate.HasValue)
            {
                result = result.Where(c => c.Qualifications.Any(q => q.EndDate <= this.EndDate));
            }

            return result;
        }
    }
}
