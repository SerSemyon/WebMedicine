﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebMedicine;

#nullable disable

namespace WebMedicine.Migrations
{
    [DbContext(typeof(MedicineContext))]
    partial class MedicineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebMedicine.Models.Doctorvisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Conclusion")
                        .HasColumnType("text")
                        .HasColumnName("conclusion");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<string>("SymptomsDescription")
                        .HasColumnType("text")
                        .HasColumnName("symptoms_description");

                    b.HasKey("Id")
                        .HasName("doctorvisit_pkey");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("doctorvisit", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer")
                        .HasColumnName("position_id");

                    b.Property<int>("StructureId")
                        .HasColumnType("integer")
                        .HasColumnName("structure_id");

                    b.HasKey("Id")
                        .HasName("employee_pkey");

                    b.HasIndex("PersonId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StructureId");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("equipment_pkey");

                    b.ToTable("equipment", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer")
                        .HasColumnName("equipment_id");

                    b.Property<int>("StructureId")
                        .HasColumnType("integer")
                        .HasColumnName("structure_id");

                    b.HasKey("Id")
                        .HasName("inventory_pkey");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("StructureId");

                    b.ToTable("inventory", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Inventoryresult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer")
                        .HasColumnName("equipment_id");

                    b.Property<bool>("EquipmentPresence")
                        .HasColumnType("boolean")
                        .HasColumnName("equipment_presence");

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer")
                        .HasColumnName("inventory_id");

                    b.HasKey("Id")
                        .HasName("inventoryresults_pkey");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("InventoryId");

                    b.ToTable("inventoryresults", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Medicationcatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("dosage");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("manufacturer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("medicationcatalog_pkey");

                    b.ToTable("medicationcatalog", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Medicationprescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Duration")
                        .HasColumnType("date")
                        .HasColumnName("duration");

                    b.Property<int>("MedicationId")
                        .HasColumnType("integer")
                        .HasColumnName("medication_id");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("integer")
                        .HasColumnName("treatment_id");

                    b.HasKey("Id")
                        .HasName("medicationprescription_pkey");

                    b.HasIndex("MedicationId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("medicationprescription", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Patientfeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FeaturesDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("features_description");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id")
                        .HasName("patientfeatures_pkey");

                    b.HasIndex("PatientId");

                    b.ToTable("patientfeatures", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateOnly?>("DateOfDeath")
                        .HasColumnType("date")
                        .HasColumnName("date_of_death");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("gender");

                    b.Property<bool?>("HigherEducation")
                        .HasColumnType("boolean")
                        .HasColumnName("higher_education");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("patronymic");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("person_pkey");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Rate")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("rate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("position_pkey");

                    b.ToTable("position", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("department_id");

                    b.Property<bool?>("IsolationFacility")
                        .HasColumnType("boolean")
                        .HasColumnName("isolation_facility");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer")
                        .HasColumnName("room_number");

                    b.HasKey("Id")
                        .HasName("rooms_pkey");

                    b.HasIndex("DepartmentId");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<int>("StructureId")
                        .HasColumnType("integer")
                        .HasColumnName("structure_id");

                    b.HasKey("Id")
                        .HasName("schedule_pkey");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StructureId");

                    b.ToTable("schedule", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Structure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("department_name");

                    b.Property<bool?>("EmploymentAvailability")
                        .HasColumnType("boolean")
                        .HasColumnName("employment_availability");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<bool?>("IsolationFacility")
                        .HasColumnType("boolean")
                        .HasColumnName("isolation_facility");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("structure_pkey");

                    b.ToTable("structure", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<DateOnly>("PrescriptionDate")
                        .HasColumnType("date")
                        .HasColumnName("prescription_date");

                    b.HasKey("Id")
                        .HasName("treatment_pkey");

                    b.HasIndex("DoctorId");

                    b.HasIndex("EventId");

                    b.ToTable("treatment", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id")
                        .HasName("visits_pkey");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PatientId");

                    b.ToTable("visits", (string)null);
                });

            modelBuilder.Entity("WebMedicine.Models.Doctorvisit", b =>
                {
                    b.HasOne("WebMedicine.Models.Employee", "Doctor")
                        .WithMany("Doctorvisits")
                        .HasForeignKey("DoctorId")
                        .IsRequired()
                        .HasConstraintName("doctorvisit_doctor_id_fkey");

                    b.HasOne("WebMedicine.Models.Person", "Patient")
                        .WithMany("Doctorvisits")
                        .HasForeignKey("PatientId")
                        .IsRequired()
                        .HasConstraintName("doctorvisit_patient_id_fkey");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebMedicine.Models.Employee", b =>
                {
                    b.HasOne("WebMedicine.Models.Person", "Person")
                        .WithMany("Employees")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("employee_person_id_fkey");

                    b.HasOne("WebMedicine.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .IsRequired()
                        .HasConstraintName("employee_position_id_fkey");

                    b.HasOne("WebMedicine.Models.Structure", "Structure")
                        .WithMany("Employees")
                        .HasForeignKey("StructureId")
                        .IsRequired()
                        .HasConstraintName("employee_structure_id_fkey");

                    b.Navigation("Person");

                    b.Navigation("Position");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("WebMedicine.Models.Inventory", b =>
                {
                    b.HasOne("WebMedicine.Models.Equipment", "Equipment")
                        .WithMany("Inventories")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("inventory_equipment_id_fkey");

                    b.HasOne("WebMedicine.Models.Structure", "Structure")
                        .WithMany("Inventories")
                        .HasForeignKey("StructureId")
                        .IsRequired()
                        .HasConstraintName("inventory_structure_id_fkey");

                    b.Navigation("Equipment");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("WebMedicine.Models.Inventoryresult", b =>
                {
                    b.HasOne("WebMedicine.Models.Equipment", "Equipment")
                        .WithMany("Inventoryresults")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("inventoryresults_equipment_id_fkey");

                    b.HasOne("WebMedicine.Models.Inventory", "Inventory")
                        .WithMany("Inventoryresults")
                        .HasForeignKey("InventoryId")
                        .IsRequired()
                        .HasConstraintName("inventoryresults_inventory_id_fkey");

                    b.Navigation("Equipment");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("WebMedicine.Models.Medicationprescription", b =>
                {
                    b.HasOne("WebMedicine.Models.Medicationcatalog", "Medication")
                        .WithMany("Medicationprescriptions")
                        .HasForeignKey("MedicationId")
                        .IsRequired()
                        .HasConstraintName("medicationprescription_medication_id_fkey");

                    b.HasOne("WebMedicine.Models.Treatment", "Treatment")
                        .WithMany("Medicationprescriptions")
                        .HasForeignKey("TreatmentId")
                        .IsRequired()
                        .HasConstraintName("medicationprescription_treatment_id_fkey");

                    b.Navigation("Medication");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("WebMedicine.Models.Patientfeature", b =>
                {
                    b.HasOne("WebMedicine.Models.Person", "Patient")
                        .WithMany("Patientfeatures")
                        .HasForeignKey("PatientId")
                        .IsRequired()
                        .HasConstraintName("patientfeatures_patient_id_fkey");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebMedicine.Models.Room", b =>
                {
                    b.HasOne("WebMedicine.Models.Structure", "Department")
                        .WithMany("Rooms")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("rooms_department_id_fkey");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebMedicine.Models.Schedule", b =>
                {
                    b.HasOne("WebMedicine.Models.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("schedule_employee_id_fkey");

                    b.HasOne("WebMedicine.Models.Structure", "Structure")
                        .WithMany("Schedules")
                        .HasForeignKey("StructureId")
                        .IsRequired()
                        .HasConstraintName("schedule_structure_id_fkey");

                    b.Navigation("Employee");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("WebMedicine.Models.Treatment", b =>
                {
                    b.HasOne("WebMedicine.Models.Employee", "Doctor")
                        .WithMany("Treatments")
                        .HasForeignKey("DoctorId")
                        .IsRequired()
                        .HasConstraintName("treatment_doctor_id_fkey");

                    b.HasOne("WebMedicine.Models.Doctorvisit", "Event")
                        .WithMany("Treatments")
                        .HasForeignKey("EventId")
                        .HasConstraintName("treatment_event_id_fkey");

                    b.Navigation("Doctor");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("WebMedicine.Models.Visit", b =>
                {
                    b.HasOne("WebMedicine.Models.Employee", "Employee")
                        .WithMany("Visits")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("visits_employee_id_fkey");

                    b.HasOne("WebMedicine.Models.Person", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .IsRequired()
                        .HasConstraintName("visits_patient_id_fkey");

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebMedicine.Models.Doctorvisit", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("WebMedicine.Models.Employee", b =>
                {
                    b.Navigation("Doctorvisits");

                    b.Navigation("Schedules");

                    b.Navigation("Treatments");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("WebMedicine.Models.Equipment", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Inventoryresults");
                });

            modelBuilder.Entity("WebMedicine.Models.Inventory", b =>
                {
                    b.Navigation("Inventoryresults");
                });

            modelBuilder.Entity("WebMedicine.Models.Medicationcatalog", b =>
                {
                    b.Navigation("Medicationprescriptions");
                });

            modelBuilder.Entity("WebMedicine.Models.Person", b =>
                {
                    b.Navigation("Doctorvisits");

                    b.Navigation("Employees");

                    b.Navigation("Patientfeatures");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("WebMedicine.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebMedicine.Models.Structure", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Inventories");

                    b.Navigation("Rooms");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("WebMedicine.Models.Treatment", b =>
                {
                    b.Navigation("Medicationprescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
