using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Models;

public partial class ClubAppsContext : IdentityDbContext<ClubUserApp>
{
    public ClubAppsContext()
    {
    }

    public ClubAppsContext(DbContextOptions<ClubAppsContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__budget__3213E83F8E13C09C");

            entity.ToTable("budget");

            entity.HasIndex(e => e.UserId, "UQ__budget__B9BE370E55828646").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClauseBudget).HasColumnName("clause_budget");
            entity.Property(e => e.MainBudget).HasColumnName("main_budget");
            entity.Property(e => e.UpdatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Budget)
                .HasForeignKey<Budget>(d => d.UserId)
                .HasConstraintName("FK__budget__user_id__5629CD9C");
        });

        modelBuilder.Entity<Cup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cups__3213E83FE8CC537F");

            entity.ToTable("cups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.Finished).HasColumnName("finished");
            entity.Property(e => e.NameCup)
                .HasMaxLength(255)
                .HasColumnName("name_cup");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Cups)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__cups__created_by__4F7CD00D");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__games__3213E83F0DD01ED4");

            entity.ToTable("games");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CupId).HasColumnName("cup_id");
            entity.Property(e => e.FinishedByUserId).HasColumnName("finished_by_user_id");
            entity.Property(e => e.IsFinished).HasColumnName("is_finished");
            entity.Property(e => e.ScoreTeamA).HasColumnName("score_team_a");
            entity.Property(e => e.ScoreTeamB).HasColumnName("score_team_b");
            entity.Property(e => e.TeamAId).HasColumnName("team_a_id");
            entity.Property(e => e.TeamBId).HasColumnName("team_b_id");

            entity.HasOne(d => d.Cup).WithMany(p => p.Games)
                .HasForeignKey(d => d.CupId)
                .HasConstraintName("FK__games__cup_id__5070F446");

            entity.HasOne(d => d.FinishedByUser).WithMany(p => p.Games)
                .HasForeignKey(d => d.FinishedByUserId)
                .HasConstraintName("FK__games__finished___534D60F1");

            entity.HasOne(d => d.TeamA).WithMany(p => p.GameTeamAs)
                .HasForeignKey(d => d.TeamAId)
                .HasConstraintName("FK__games__team_a_id__5165187F");

            entity.HasOne(d => d.TeamB).WithMany(p => p.GameTeamBs)
                .HasForeignKey(d => d.TeamBId)
                .HasConstraintName("FK__games__team_b_id__52593CB8");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__offers__3213E83F30A2986E");

            entity.ToTable("offers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.FromTeamId).HasColumnName("from_team_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.ToPlayerId).HasColumnName("to_player_id");
            entity.Property(e => e.ToTeamId).HasColumnName("to_team_id");

            entity.HasOne(d => d.FromTeam).WithMany(p => p.OfferFromTeams)
                .HasForeignKey(d => d.FromTeamId)
                .HasConstraintName("FK__offers__from_tea__4BAC3F29");

            entity.HasOne(d => d.Status).WithMany(p => p.Offers)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__offers__status_i__4E88ABD4");

            entity.HasOne(d => d.ToPlayer).WithMany(p => p.Offers)
                .HasForeignKey(d => d.ToPlayerId)
                .HasConstraintName("FK__offers__to_playe__4D94879B");

            entity.HasOne(d => d.ToTeam).WithMany(p => p.OfferToTeams)
                .HasForeignKey(d => d.ToTeamId)
                .HasConstraintName("FK__offers__to_team___4CA06362");
        });

        modelBuilder.Entity<OffersStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__offers_s__3213E83FD87AD087");

            entity.ToTable("offers_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__players__3213E83F31150BE6");

            entity.ToTable("players");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DefensiveAwareness).HasColumnName("defensive_awareness");
            entity.Property(e => e.Dribling).HasColumnName("dribling");
            entity.Property(e => e.Interceptions).HasColumnName("interceptions");
            entity.Property(e => e.IsStarting).HasColumnName("is_starting");
            entity.Property(e => e.MarketValue).HasColumnName("market_value");
            entity.Property(e => e.OriginalTeam)
                .HasMaxLength(255)
                .HasColumnName("original_team");
            entity.Property(e => e.OverallRating).HasColumnName("overall_rating");
            entity.Property(e => e.Pace).HasColumnName("pace");
            entity.Property(e => e.PhotoSrc)
                .HasMaxLength(255)
                .HasColumnName("photo_src");
            entity.Property(e => e.Playername)
                .HasMaxLength(255)
                .HasColumnName("playername");
            entity.Property(e => e.PositionX).HasColumnName("position_x");
            entity.Property(e => e.PositionY).HasColumnName("position_y");
            entity.Property(e => e.Potential).HasColumnName("potential");
            entity.Property(e => e.Reflects).HasColumnName("reflects");
            entity.Property(e => e.ReleaseClause).HasColumnName("release_clause");
            entity.Property(e => e.Shooting).HasColumnName("shooting");
            entity.Property(e => e.Strenght).HasColumnName("strenght");
            entity.Property(e => e.TeamId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("team_id");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__players__team_id__4AB81AF0");
        });

        modelBuilder.Entity<Standing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__standing__3213E83FA9BAAFBC");

            entity.ToTable("standings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CupId).HasColumnName("cup_id");
            entity.Property(e => e.Draws).HasColumnName("draws");
            entity.Property(e => e.GoalsAgainst).HasColumnName("goals_against");
            entity.Property(e => e.GoalsFor).HasColumnName("goals_for");
            entity.Property(e => e.Losses).HasColumnName("losses");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.Wins).HasColumnName("wins");

            entity.HasOne(d => d.Cup).WithMany(p => p.Standings)
                .HasForeignKey(d => d.CupId)
                .HasConstraintName("FK__standings__cup_i__5441852A");

            entity.HasOne(d => d.Team).WithMany(p => p.Standings)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__standings__team___5535A963");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teams__3213E83F7A1092A7");

            entity.ToTable("teams");

            entity.HasIndex(e => e.OwneruserId, "UQ__teams__85C39ECD42F9721D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.OwneruserId).HasColumnName("owneruser_id");
            entity.Property(e => e.Teamname)
                .HasMaxLength(255)
                .HasColumnName("teamname");

            entity.HasOne(d => d.Owneruser).WithOne(p => p.Team)
                .HasForeignKey<Team>(d => d.OwneruserId)
                .HasConstraintName("FK__teams__owneruser__49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F62C1819B");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GoogleId)
                .HasMaxLength(255)
                .HasColumnName("google_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Cup> Cups { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<OffersStatus> OffersStatuses { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Standing> Standings { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ClubUserApp> ClubUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SQL1002.site4now.net;Database=db_ab9293_clubapp;User Id=db_ab9293_clubapp_admin;Password=minitoy57;");

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
