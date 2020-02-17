using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUser
    {
        public IgniteUser()
        {
            IgniteUserApplication = new HashSet<IgniteUserApplication>();
            IgniteUserClaim = new HashSet<IgniteUserClaim>();
            IgniteUserLogin = new HashSet<IgniteUserLogin>();
            IgniteUserRole = new HashSet<IgniteUserRole>();
            IgniteUserToken = new HashSet<IgniteUserToken>();
        }

        public int IgniteId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime IgniteUserCreatedDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameLastName { get; set; }
        public string IgniteEmail { get; set; }
        public bool IgniteEmailConfirmed { get; set; }
        public string NormalizedIgniteEmail { get; set; }
        public bool IsInternalUser { get; set; }
        public bool WorkedOverOneYear { get; set; }
        public bool IsQualifiedForLongTermEmp { get; set; }
        public bool CompletedUndergraduate { get; set; }
        public bool PreQualificationAccepted { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? TermDate { get; set; }
        public DateTime? ApplicationApprovalDate { get; set; }
        public bool EligibleForQualification { get; set; }
        public bool LinkClicked { get; set; }
        public int FkDepartmentId { get; set; }
        public int FkTitleId { get; set; }
        public int FkLocationId { get; set; }
        public int FkBuid { get; set; }
        public int FkIgniteUserTypeId { get; set; }

        public virtual IgniteBusinessUnit FkBu { get; set; }
        public virtual Department FkDepartment { get; set; }
        public virtual IgniteUserType FkIgniteUserType { get; set; }
        public virtual IgniteUserLocation FkLocation { get; set; }
        public virtual IgniteUserTitle FkTitle { get; set; }
        public virtual ICollection<IgniteUserApplication> IgniteUserApplication { get; set; }
        public virtual ICollection<IgniteUserClaim> IgniteUserClaim { get; set; }
        public virtual ICollection<IgniteUserLogin> IgniteUserLogin { get; set; }
        public virtual ICollection<IgniteUserRole> IgniteUserRole { get; set; }
        public virtual ICollection<IgniteUserToken> IgniteUserToken { get; set; }
    }
}
