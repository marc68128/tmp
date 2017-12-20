using Microsoft.EntityFrameworkCore;
using MusicTools.Domain;

namespace MusicTools.Data
{
    public class MusicToolsContext : DbContext
    {
        public MusicToolsContext(DbContextOptions<MusicToolsContext> options)
            : base(options)
        { }

        public DbSet<Interval> Intervals { get; set; }
        public DbSet<ChordQuality> ChordQualities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChordQualityInterval>()
                .HasKey(bc => new { bc.ChordQualityName, bc.IntervalId });


            modelBuilder.Entity<ChordQuality>()
                .HasKey(bc => new { bc.Name });

            modelBuilder.Entity<ChordQualityInterval>()
                .HasOne(bc => bc.Interval)
                .WithMany(b => b.ChordQualityIntervals)
                .HasForeignKey(bc => bc.IntervalId);

            modelBuilder.Entity<ChordQualityInterval>()
                .HasOne(bc => bc.ChordQuality)
                .WithMany(c => c.ChordQualityIntervals)
                .HasForeignKey(bc => bc.ChordQualityName);

            base.OnModelCreating(modelBuilder);
        }
    }
}