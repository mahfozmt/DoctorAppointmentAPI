using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorAppointmentAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Speacializations",
                columns: table => new
                {
                    SpeacializationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeacializationDepartment = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speacializations", x => x.SpeacializationId);
                });

            migrationBuilder.CreateTable(
                name: "Pateints",
                columns: table => new
                {
                    PateintId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pateints", x => x.PateintId);
                    table.ForeignKey(
                        name: "FK_Pateints_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    tblUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.tblUserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    BMDCNumber = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    SpeacializationId = table.Column<int>(nullable: false),
                    AboutDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Speacializations_SpeacializationId",
                        column: x => x.SpeacializationId,
                        principalTable: "Speacializations",
                        principalColumn: "SpeacializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeasisHistories",
                columns: table => new
                {
                    DeasisHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PateintId = table.Column<int>(nullable: false),
                    DeasisHistories = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeasisHistories", x => x.DeasisHistoryId);
                    table.ForeignKey(
                        name: "FK_DeasisHistories_Pateints_PateintId",
                        column: x => x.PateintId,
                        principalTable: "Pateints",
                        principalColumn: "PateintId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chambers",
                columns: table => new
                {
                    ChamberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    RoomNumber = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambers", x => x.ChamberId);
                    table.ForeignKey(
                        name: "FK_Chambers_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoasterOfDoctors",
                columns: table => new
                {
                    RoasterOfDoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<TimeSpan>(nullable: false),
                    TimeEnd = table.Column<TimeSpan>(nullable: false),
                    EstimatedPateintNumber = table.Column<int>(nullable: false),
                    ChamberId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoasterOfDoctors", x => x.RoasterOfDoctorId);
                    table.ForeignKey(
                        name: "FK_RoasterOfDoctors_Chambers_ChamberId",
                        column: x => x.ChamberId,
                        principalTable: "Chambers",
                        principalColumn: "ChamberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoasterOfDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Serials",
                columns: table => new
                {
                    SerialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoasterOfDoctorId = table.Column<int>(nullable: false),
                    PateintId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serials", x => x.SerialId);
                    table.ForeignKey(
                        name: "FK_Serials_Pateints_PateintId",
                        column: x => x.PateintId,
                        principalTable: "Pateints",
                        principalColumn: "PateintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serials_RoasterOfDoctors_RoasterOfDoctorId",
                        column: x => x.RoasterOfDoctorId,
                        principalTable: "RoasterOfDoctors",
                        principalColumn: "RoasterOfDoctorId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Speacializations",
                columns: new[] { "SpeacializationId", "SpeacializationDepartment" },
                values: new object[,]
                {
                    { 26, "Nephrology " },
                    { 27, "Neuro Modulation " },
                    { 28, "Nutrition & Dietetics " },
                    { 29, "Neurology " },
                    { 30, "Neurosurgery " },
                    { 31, "Obstetrics And Gynecology " },
                    { 32, "Ophthalmology " },
                    { 33, "Orthopedics & Joint Replacement " },
                    { 34, "Pain Management " },
                    { 35, "Pediatric Surgery " },
                    { 36, "Physiotherapy " },
                    { 37, "Plastic Surgery " },
                    { 38, "Psychiatry " },
                    { 39, "Pulmonology " },
                    { 40, "Renal Transplant " },
                    { 41, "Reproductive Medicine & IVF " },
                    { 42, "Rheumatology " },
                    { 43, "Robotic Surgery " },
                    { 44, "Surgical Gastroenterology " },
                    { 45, "Surgical Oncology " },
                    { 46, "Urology " },
                    { 25, "Neonatology " },
                    { 24, "Minimally Invasive Gynecology " },
                    { 23, "Medical Oncology " },
                    { 22, "Medical Oncology & Clinical Hematology " },
                    { 1, "Aerospace Medicine" },
                    { 2, "Bariatric Surgery " },
                    { 3, "Cardiology - Interventional " },
                    { 4, "Cardiology - Non Interventional " },
                    { 5, "Cardiothoracic And Vascular Surgery " },
                    { 6, "Centre For Spinal Diseases " },
                    { 7, "Clinical Haematology And BMT " },
                    { 8, "Corneal Transplant " },
                    { 9, "Critical Care Medicine " },
                    { 10, "Dermatology And Cosmetology " },
                    { 11, "Ear Nose Throat Head And Neck Surgery " },
                    { 12, "Emergency Medicine " },
                    { 13, "Endocrinology " },
                    { 14, "General Surgery " },
                    { 15, "Infectious Diseases " },
                    { 16, "Internal Medicine " },
                    { 17, "In-Vitro Fertilisation (IVF) " },
                    { 18, "Laboratory Medicine " },
                    { 19, "Liver Transplant & Hepatic Surgery " },
                    { 20, "Maxillofacial Surgery " },
                    { 21, "Medical Gastroenterology " },
                    { 47, "Vascular and endovascular surgery " },
                    { 48, "Anaesthesia" }
                });

            migrationBuilder.InsertData(
                table: "Pateints",
                columns: new[] { "PateintId", "Age", "GenderId", "MobileNumber", "Name" },
                values: new object[,]
                {
                    { 1, 25, 1, "01758091506", "Mahfozur Rahman" },
                    { 2, 42, 1, "01745632145", "Wahidur Rahman" },
                    { 3, 27, 1, "01652147896", "Masum Billah" },
                    { 6, 23, 1, "464864864685", "Wali Ullah" },
                    { 7, 22, 1, "5664666155", "Sadik Rahman" },
                    { 10, 30, 1, "019215666245", "Selim Sheikh" },
                    { 4, 25, 2, "01758091506", "Shanta Jahan" },
                    { 5, 21, 2, "05616515651", "Moushumi Akter" },
                    { 8, 24, 2, "011565668466", "Happy Rose" },
                    { 9, 35, 2, "01475656526", "Rita Sheikh" },
                    { 11, 25, 2, "01754152632", "Aleya Ferdaus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chambers_DoctorId",
                table: "Chambers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeasisHistories_PateintId",
                table: "DeasisHistories",
                column: "PateintId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_GenderId",
                table: "Doctors",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpeacializationId",
                table: "Doctors",
                column: "SpeacializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pateints_GenderId",
                table: "Pateints",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoasterOfDoctors_ChamberId",
                table: "RoasterOfDoctors",
                column: "ChamberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoasterOfDoctors_DoctorId",
                table: "RoasterOfDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Serials_PateintId",
                table: "Serials",
                column: "PateintId");

            migrationBuilder.CreateIndex(
                name: "IX_Serials_RoasterOfDoctorId",
                table: "Serials",
                column: "RoasterOfDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeasisHistories");

            migrationBuilder.DropTable(
                name: "Serials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pateints");

            migrationBuilder.DropTable(
                name: "RoasterOfDoctors");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Chambers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Speacializations");
        }
    }
}
