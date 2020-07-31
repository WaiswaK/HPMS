namespace HPMS.Models
{
    using System.Data.Entity;

    public partial class HPMS : DbContext
    {
        public HPMS()
            : base("name=HPMS")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<COHORT> COHORTs { get; set; }
        public virtual DbSet<Demographic> Demographics { get; set; }
        public virtual DbSet<Diet_Chart> Diet_Charts { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Forum_Comment> Forum_Comments { get; set; }
        public virtual DbSet<Forum_Header> Forum_Headers { get; set; }
        public virtual DbSet<Health_Tip> Health_Tips { get; set; }
        public virtual DbSet<Heath_Center> Heath_Centers { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patient_Diet_Chart> Patient_Diet_Charts { get; set; }
        public virtual DbSet<Patient_Health_Tip> Patient_Health_Tips { get; set; }
        public virtual DbSet<Patient_Medication> Patient_Medications { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Substitution> Substitutions { get; set; }
        public virtual DbSet<Substitution_Line> Substitution_Lines { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Demographic>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Demographic>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Demographic>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.Demographic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demographic>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Demographic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diet_Chart>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Forum_Comment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Forum_Header>()
                .Property(e => e.Topic)
                .IsUnicode(false);

            modelBuilder.Entity<Forum_Header>()
                .HasMany(e => e.Forum_Comment)
                .WithOptional(e => e.Forum_Header)
                .HasForeignKey(e => e.Forum_ID);

            modelBuilder.Entity<Health_Tip>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<Heath_Center>()
                .Property(e => e.Center)
                .IsFixedLength();

            modelBuilder.Entity<Medication>()
                .Property(e => e.Medicine)
                .IsUnicode(false);

            modelBuilder.Entity<Medication>()
                .HasMany(e => e.Patient_Medication)
                .WithRequired(e => e.Medication)
                .HasForeignKey(e => e.Medication_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Educations)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Histories)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.FP)
                .IsUnicode(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Hep_Result)
                .IsUnicode(false);

            modelBuilder.Entity<Visit>()
                .Property(e => e.MUAC_SCORE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Height)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.BMI_Score)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Blood_pressure___Systolic)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Blood_pressure___Diastolic)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Blood_Sugar)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Temperature)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.CD4_Count)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Viral_Load)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Visit>()
                .Property(e => e.Medical_report)
                .IsUnicode(false);
        }
    }
}
