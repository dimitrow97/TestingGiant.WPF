using System;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Certificate : IKeepDates
    {
        [Key]
        public int Id { get; set; }

        public string CertificateTemplateId { get; set; }

        public virtual CertificateTemplate CertificateTemplate { get; set; }

        public virtual User CertificateOwner { get; set; }

        public virtual int CertificateOwnerId { get; set; }

        public decimal OwnerScore { get; set; }        

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Grade { get; set; }

        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
