using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebMedicine.Models;

namespace WebMedicine;

public partial class MedicineContext : DbContext
{
    public MedicineContext()
    {
    }

    public MedicineContext(DbContextOptions<MedicineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctorvisit> Doctorvisits { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Inventoryresult> Inventoryresults { get; set; }

    public virtual DbSet<Medicationcatalog> Medicationcatalogs { get; set; }

    public virtual DbSet<Medicationprescription> Medicationprescriptions { get; set; }

    public virtual DbSet<Patientfeature> Patientfeatures { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Structure> Structures { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=medicine;User ID=postgres; Password=9988");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctorvisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctorvisit_pkey");

            entity.ToTable("doctorvisit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Conclusion).HasColumnName("conclusion");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.SymptomsDescription).HasColumnName("symptoms_description");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Doctorvisits)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorvisit_doctor_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Doctorvisits)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorvisit_patient_id_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.StructureId).HasColumnName("structure_id");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_person_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_position_id_fkey");

            entity.HasOne(d => d.Structure).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StructureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_structure_id_fkey");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.StructureId).HasColumnName("structure_id");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_equipment_id_fkey");

            entity.HasOne(d => d.Structure).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.StructureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_structure_id_fkey");
        });

        modelBuilder.Entity<Inventoryresult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventoryresults_pkey");

            entity.ToTable("inventoryresults");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.EquipmentPresence).HasColumnName("equipment_presence");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Inventoryresults)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventoryresults_equipment_id_fkey");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Inventoryresults)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventoryresults_inventory_id_fkey");
        });

        modelBuilder.Entity<Medicationcatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicationcatalog_pkey");

            entity.ToTable("medicationcatalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .HasColumnName("dosage");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Medicationprescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicationprescription_pkey");

            entity.ToTable("medicationprescription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MedicationId).HasColumnName("medication_id");
            entity.Property(e => e.TreatmentId).HasColumnName("treatment_id");

            entity.HasOne(d => d.Medication).WithMany(p => p.Medicationprescriptions)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicationprescription_medication_id_fkey");

            entity.HasOne(d => d.Treatment).WithMany(p => p.Medicationprescriptions)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicationprescription_treatment_id_fkey");
        });

        modelBuilder.Entity<Patientfeature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patientfeatures_pkey");

            entity.ToTable("patientfeatures");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeaturesDescription).HasColumnName("features_description");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.Patient).WithMany(p => p.Patientfeatures)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientfeatures_patient_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfDeath).HasColumnName("date_of_death");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.HigherEducation).HasColumnName("higher_education");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_pkey");

            entity.ToTable("position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rate)
                .HasPrecision(10, 2)
                .HasColumnName("rate");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.IsolationFacility).HasColumnName("isolation_facility");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");

            entity.HasOne(d => d.Department).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rooms_department_id_fkey");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_pkey");

            entity.ToTable("schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StructureId).HasColumnName("structure_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_employee_id_fkey");

            entity.HasOne(d => d.Structure).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.StructureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_structure_id_fkey");
        });

        modelBuilder.Entity<Structure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("structure_pkey");

            entity.ToTable("structure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasColumnName("department_name");
            entity.Property(e => e.EmploymentAvailability).HasColumnName("employment_availability");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsolationFacility).HasColumnName("isolation_facility");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("treatment_pkey");

            entity.ToTable("treatment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.PrescriptionDate).HasColumnName("prescription_date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("treatment_doctor_id_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("treatment_event_id_fkey");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visits_pkey");

            entity.ToTable("visits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Visits)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visits_employee_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Visits)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visits_patient_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
