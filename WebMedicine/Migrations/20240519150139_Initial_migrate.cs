using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebMedicine.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("equipment_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicationcatalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dosage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("medicationcatalog_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    date_of_death = table.Column<DateOnly>(type: "date", nullable: true),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    higher_education = table.Column<bool>(type: "boolean", nullable: true),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("person_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rate = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("position_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structure",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    department_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isolation_facility = table.Column<bool>(type: "boolean", nullable: true),
                    employment_availability = table.Column<bool>(type: "boolean", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("structure_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patientfeatures",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    features_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("patientfeatures_pkey", x => x.id);
                    table.ForeignKey(
                        name: "patientfeatures_patient_id_fkey",
                        column: x => x.patient_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    position_id = table.Column<int>(type: "integer", nullable: false),
                    hire_date = table.Column<DateOnly>(type: "date", nullable: false),
                    structure_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.id);
                    table.ForeignKey(
                        name: "employee_person_id_fkey",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employee_position_id_fkey",
                        column: x => x.position_id,
                        principalTable: "position",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employee_structure_id_fkey",
                        column: x => x.structure_id,
                        principalTable: "structure",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    equipment_id = table.Column<int>(type: "integer", nullable: false),
                    structure_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_pkey", x => x.id);
                    table.ForeignKey(
                        name: "inventory_equipment_id_fkey",
                        column: x => x.equipment_id,
                        principalTable: "equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventory_structure_id_fkey",
                        column: x => x.structure_id,
                        principalTable: "structure",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    room_number = table.Column<int>(type: "integer", nullable: false),
                    isolation_facility = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rooms_pkey", x => x.id);
                    table.ForeignKey(
                        name: "rooms_department_id_fkey",
                        column: x => x.department_id,
                        principalTable: "structure",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "doctorvisit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    symptoms_description = table.Column<string>(type: "text", nullable: true),
                    conclusion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctorvisit_pkey", x => x.id);
                    table.ForeignKey(
                        name: "doctorvisit_doctor_id_fkey",
                        column: x => x.doctor_id,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "doctorvisit_patient_id_fkey",
                        column: x => x.patient_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    structure_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_pkey", x => x.id);
                    table.ForeignKey(
                        name: "schedule_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "schedule_structure_id_fkey",
                        column: x => x.structure_id,
                        principalTable: "structure",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "visits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visits_pkey", x => x.id);
                    table.ForeignKey(
                        name: "visits_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "visits_patient_id_fkey",
                        column: x => x.patient_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inventoryresults",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inventory_id = table.Column<int>(type: "integer", nullable: false),
                    equipment_id = table.Column<int>(type: "integer", nullable: false),
                    equipment_presence = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventoryresults_pkey", x => x.id);
                    table.ForeignKey(
                        name: "inventoryresults_equipment_id_fkey",
                        column: x => x.equipment_id,
                        principalTable: "equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventoryresults_inventory_id_fkey",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "treatment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    event_id = table.Column<int>(type: "integer", nullable: true),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("treatment_pkey", x => x.id);
                    table.ForeignKey(
                        name: "treatment_doctor_id_fkey",
                        column: x => x.doctor_id,
                        principalTable: "employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "treatment_event_id_fkey",
                        column: x => x.event_id,
                        principalTable: "doctorvisit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "medicationprescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    medication_id = table.Column<int>(type: "integer", nullable: false),
                    treatment_id = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("medicationprescription_pkey", x => x.id);
                    table.ForeignKey(
                        name: "medicationprescription_medication_id_fkey",
                        column: x => x.medication_id,
                        principalTable: "medicationcatalog",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "medicationprescription_treatment_id_fkey",
                        column: x => x.treatment_id,
                        principalTable: "treatment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctorvisit_doctor_id",
                table: "doctorvisit",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctorvisit_patient_id",
                table: "doctorvisit",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_person_id",
                table: "employee",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_position_id",
                table: "employee",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_structure_id",
                table: "employee",
                column: "structure_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_equipment_id",
                table: "inventory",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_structure_id",
                table: "inventory",
                column: "structure_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryresults_equipment_id",
                table: "inventoryresults",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryresults_inventory_id",
                table: "inventoryresults",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicationprescription_medication_id",
                table: "medicationprescription",
                column: "medication_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicationprescription_treatment_id",
                table: "medicationprescription",
                column: "treatment_id");

            migrationBuilder.CreateIndex(
                name: "IX_patientfeatures_patient_id",
                table: "patientfeatures",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_department_id",
                table: "rooms",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_employee_id",
                table: "schedule",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_structure_id",
                table: "schedule",
                column: "structure_id");

            migrationBuilder.CreateIndex(
                name: "IX_treatment_doctor_id",
                table: "treatment",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_treatment_event_id",
                table: "treatment",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_employee_id",
                table: "visits",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_visits_patient_id",
                table: "visits",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventoryresults");

            migrationBuilder.DropTable(
                name: "medicationprescription");

            migrationBuilder.DropTable(
                name: "patientfeatures");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "visits");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "medicationcatalog");

            migrationBuilder.DropTable(
                name: "treatment");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "doctorvisit");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "position");

            migrationBuilder.DropTable(
                name: "structure");
        }
    }
}
