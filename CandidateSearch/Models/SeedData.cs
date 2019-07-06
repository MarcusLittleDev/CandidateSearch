using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using CandidateSearch.Models.Candidates;

namespace CandidateSearch.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CandidateSearchContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CandidateSearchContext>>()))
            {
                if(context.Candidate.Any())
                {
                    return;
                }

                context.Candidate.AddRange(
                    new Candidate
                    {
                        FirstName = "Jack",
                        LastName = "Shephard",
                        EmailAddress = "Jack@theisland.com",
                        PhoneNumber = "2239059334",
                        ZipCode = "32012",
                        Qualifications =  new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.WorkExperience,
                                    Name = "Doctor",
                                    StartDate = new DateTime(1997, 8, 15),
                                    EndDate = new DateTime(2009, 12, 05)

                                },
                                new Qualification
                                {
                                    Type = QualificationType.CollegeDegree,
                                    Name = "Doctor University",
                                    StartDate = new DateTime(1991, 4, 25),
                                    EndDate = new DateTime(1997, 5, 16)

                                }
                            }
                    },
                    new Candidate
                    {
                        FirstName = "Kate",
                        LastName = "Austen",
                        EmailAddress = "Kate@theisland.com",
                        PhoneNumber = "9403229849",
                        ZipCode = "21298",
                        Qualifications = new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.ProfessionalCertication,
                                    Name = "Renegade",
                                    StartDate = new DateTime(1995, 5, 11),
                                    EndDate = new DateTime(2004, 4, 19)

                                }
                            }
                    },
                    new Candidate
                    {
                        FirstName = "James",
                        LastName = "Sawyer",
                        EmailAddress = "Sawyer@theisland.com",
                        PhoneNumber = "3332948321",
                        ZipCode = "94832",
                        Qualifications = new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.WorkExperience,
                                    Name = "Con Man",
                                    StartDate = new DateTime(1995, 5, 19),
                                    EndDate = new DateTime(2006, 7, 03)

                                }
                            }
                    },
                    new Candidate
                    {
                        FirstName = "John",
                        LastName = "Locke",
                        EmailAddress = "Locke@theisland.com",
                        PhoneNumber = "2238743847",
                        ZipCode = "76309",
                        Qualifications = new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.WorkExperience,
                                    Name = "SalesMan",
                                    StartDate = new DateTime(1999, 4, 6),
                                    EndDate = new DateTime(2001, 9, 20)

                                },
                                new Qualification
                                {
                                    Type = QualificationType.ProfessionalCertication,
                                    Name = "Nature Expert",
                                    StartDate = new DateTime(1995, 8, 23)

                                }
                            }
                    },
                    new Candidate
                    {
                        FirstName = "Sayid",
                        LastName = "Jarrah",
                        EmailAddress = "Sayid@theisland.com",
                        PhoneNumber = "2223647736",
                        ZipCode = "63527",
                        Qualifications = new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.WorkExperience,
                                    Name = "Soilder",
                                    StartDate = new DateTime(1991, 3, 30),
                                    EndDate = new DateTime(1998, 11, 1)

                                },
                                new Qualification
                                {
                                    Type = QualificationType.ProfessionalCertication,
                                    Name = "Interrogation",
                                    StartDate = new DateTime(1993, 7, 4)

                                }
                            }
                    },
                    new Candidate
                    {
                        FirstName = "Hugo",
                        LastName = "Reyes",
                        EmailAddress = "Hurley@theisland.com",
                        PhoneNumber = "4815162342",
                        ZipCode = "27832",
                        Qualifications = new List<Qualification>
                            {
                                new Qualification
                                {
                                    Type = QualificationType.WorkExperience,
                                    Name = "Customer Service",
                                    StartDate = new DateTime(2001, 2, 26),
                                    EndDate = new DateTime(2004, 1, 05)

                                }
                            }
                    }
                        );
                context.SaveChanges();
            }
        }
    }
}
