using DiarioDelGelato.Application.Extensions;
using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("Team");

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(50);

            SeedTeam(builder);
        }

        private void SeedTeam(EntityTypeBuilder<TeamMember> builder)
        {
            long startBreakA = new DateTime().TimeToUnixTimestampUtc(15, 30);
            long stopBreakA = new DateTime().TimeToUnixTimestampUtc(15, 45);

            long startBreakB = new DateTime().TimeToUnixTimestampUtc(20, 15);
            long stopBreakB = new DateTime().TimeToUnixTimestampUtc(20, 30);

            long startWorkTurnoSemanaTarde = new DateTime().TimeToUnixTimestampUtc(12, 40);
            long stopWorkTurnoSemanaTarde = new DateTime().TimeToUnixTimestampUtc(18, 30);

            long startWorkTurnoSemanaNoite = new DateTime().TimeToUnixTimestampUtc(18, 30);
            long stopWorkTurnoSemanaNoite = new DateTime().TimeToUnixTimestampUtc(22, 30);

            long startWorkTurnoFindiTarde = new DateTime().TimeToUnixTimestampUtc(11, 30);
            long stopWorkTurnoFindiTarde = new DateTime().TimeToUnixTimestampUtc(17, 30);

            long startWorkTurnoFindiNoite = new DateTime().TimeToUnixTimestampUtc(16, 30);
            long stopWorkTurnoFindiNoite = new DateTime().TimeToUnixTimestampUtc(22, 30);

            long startWorkProducao = new DateTime().TimeToUnixTimestampUtc(08, 00);
            long stopWorkProducao= new DateTime().TimeToUnixTimestampUtc(12, 00);

            builder.HasData(
                new TeamMember { 
                    Id=1,
                    FullName="Cid Zanella", 
                    BreakStartHour=startBreakA, 
                    BreakStopHour=stopBreakA, 
                    HasCredential=false, 
                    WorkStartHour=startWorkTurnoSemanaTarde,
                    WorkStopHour=stopWorkTurnoSemanaTarde,
                    Photo = string.Empty
                },
                new TeamMember
                {
                    Id=2,
                    FullName = "Suélen Maino Zanella",
                    BreakStartHour = startBreakB,
                    BreakStopHour = stopBreakB,
                    HasCredential = false,
                    WorkStartHour = startWorkTurnoSemanaNoite,
                    WorkStopHour = stopWorkTurnoSemanaNoite,
                    Photo = string.Empty
                }
            );
        }
    }
}
