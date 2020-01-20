namespace HPMS.Models
{
    using System.Data.Entity;

    public partial class HPMS : DbContext
    {
        public HPMS()
            : base("name=HPMS")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<COHORT> COHORTs { get; set; }
        public virtual DbSet<Demographic> Demographics { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Reason> Reasons { get; set; }
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
                .HasMany(e => e.Patients)
                .WithRequired(e => e.Demographic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demographic>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Demographic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reason>()
                .HasMany(e => e.Substitutions)
                .WithOptional(e => e.Reason)
                .HasForeignKey(e => e.Reason_ID);

            modelBuilder.Entity<Reason>()
                .HasMany(e => e.Substitutions1)
                .WithOptional(e => e.Reason1)
                .HasForeignKey(e => e.Reason_ID);

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
        }
    }
}
