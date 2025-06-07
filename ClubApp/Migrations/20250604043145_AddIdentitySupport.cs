using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentitySupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "offers_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__offers_s__3213E83FD87AD087", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "budget",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    main_budget = table.Column<double>(type: "float", nullable: true),
                    clause_budget = table.Column<double>(type: "float", nullable: true),
                    updated_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__budget__3213E83F8E13C09C", x => x.id);
                    table.ForeignKey(
                        name: "FK__budget__user_id__5629CD9C",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teamname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    owneruser_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__teams__3213E83F7A1092A7", x => x.id);
                    table.ForeignKey(
                        name: "FK__teams__owneruser__49C3F6B7",
                        column: x => x.owneruser_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)"),
                    photo_src = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    playername = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    original_team = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    overall_rating = table.Column<int>(type: "int", nullable: true),
                    potential = table.Column<int>(type: "int", nullable: true),
                    market_value = table.Column<double>(type: "float", nullable: true),
                    shooting = table.Column<int>(type: "int", nullable: true),
                    dribling = table.Column<int>(type: "int", nullable: true),
                    pace = table.Column<int>(type: "int", nullable: true),
                    strenght = table.Column<int>(type: "int", nullable: true),
                    interceptions = table.Column<int>(type: "int", nullable: true),
                    defensive_awareness = table.Column<int>(type: "int", nullable: true),
                    reflects = table.Column<int>(type: "int", nullable: true),
                    release_clause = table.Column<double>(type: "float", nullable: true),
                    position_x = table.Column<double>(type: "float", nullable: true),
                    position_y = table.Column<double>(type: "float", nullable: true),
                    is_starting = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__players__3213E83F31150BE6", x => x.id);
                    table.ForeignKey(
                        name: "FK__players__team_id__4AB81AF0",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    google_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BudgetId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F62C1819B", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "budget",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_team_id = table.Column<int>(type: "int", nullable: true),
                    to_team_id = table.Column<int>(type: "int", nullable: true),
                    to_player_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__offers__3213E83F30A2986E", x => x.id);
                    table.ForeignKey(
                        name: "FK__offers__from_tea__4BAC3F29",
                        column: x => x.from_team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__offers__status_i__4E88ABD4",
                        column: x => x.status_id,
                        principalTable: "offers_status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__offers__to_playe__4D94879B",
                        column: x => x.to_player_id,
                        principalTable: "players",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__offers__to_team___4CA06362",
                        column: x => x.to_team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_cup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by_user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    created_at = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    finished = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cups__3213E83FE8CC537F", x => x.id);
                    table.ForeignKey(
                        name: "FK__cups__created_by__4F7CD00D",
                        column: x => x.created_by_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cups_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cup_id = table.Column<int>(type: "int", nullable: true),
                    team_a_id = table.Column<int>(type: "int", nullable: true),
                    team_b_id = table.Column<int>(type: "int", nullable: true),
                    score_team_a = table.Column<int>(type: "int", nullable: true),
                    score_team_b = table.Column<int>(type: "int", nullable: true),
                    is_finished = table.Column<bool>(type: "bit", nullable: true),
                    finished_by_user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__games__3213E83F0DD01ED4", x => x.id);
                    table.ForeignKey(
                        name: "FK__games__cup_id__5070F446",
                        column: x => x.cup_id,
                        principalTable: "cups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__games__finished___534D60F1",
                        column: x => x.finished_by_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__games__team_a_id__5165187F",
                        column: x => x.team_a_id,
                        principalTable: "teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__games__team_b_id__52593CB8",
                        column: x => x.team_b_id,
                        principalTable: "teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_games_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "standings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cup_id = table.Column<int>(type: "int", nullable: true),
                    team_id = table.Column<int>(type: "int", nullable: true),
                    points = table.Column<int>(type: "int", nullable: true),
                    wins = table.Column<int>(type: "int", nullable: true),
                    draws = table.Column<int>(type: "int", nullable: true),
                    losses = table.Column<int>(type: "int", nullable: true),
                    goals_for = table.Column<int>(type: "int", nullable: true),
                    goals_against = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__standing__3213E83FA9BAAFBC", x => x.id);
                    table.ForeignKey(
                        name: "FK__standings__cup_i__5441852A",
                        column: x => x.cup_id,
                        principalTable: "cups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__standings__team___5535A963",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__budget__B9BE370E55828646",
                table: "budget",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cups_created_by_user_id",
                table: "cups",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_cups_UserId",
                table: "cups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_games_cup_id",
                table: "games",
                column: "cup_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_finished_by_user_id",
                table: "games",
                column: "finished_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_team_a_id",
                table: "games",
                column: "team_a_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_team_b_id",
                table: "games",
                column: "team_b_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_UserId",
                table: "games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_offers_from_team_id",
                table: "offers",
                column: "from_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_offers_status_id",
                table: "offers",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_offers_to_player_id",
                table: "offers",
                column: "to_player_id");

            migrationBuilder.CreateIndex(
                name: "IX_offers_to_team_id",
                table: "offers",
                column: "to_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_players_team_id",
                table: "players",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_standings_cup_id",
                table: "standings",
                column: "cup_id");

            migrationBuilder.CreateIndex(
                name: "IX_standings_team_id",
                table: "standings",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "UQ__teams__85C39ECD42F9721D",
                table: "teams",
                column: "owneruser_id",
                unique: true,
                filter: "[owneruser_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_users_BudgetId",
                table: "users",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_users_TeamId",
                table: "users",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "standings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "offers_status");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "cups");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "budget");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
