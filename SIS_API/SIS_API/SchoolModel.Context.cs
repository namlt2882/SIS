﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIS_API
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolInformationSystemEntities : DbContext
    {
        public SchoolInformationSystemEntities()
            : base("name=SchoolInformationSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassMember> ClassMembers { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
