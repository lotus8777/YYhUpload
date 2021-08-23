using System.Data.Entity;
using Fy3y.Model.YYH;
using YYhUpload.Model;

namespace YYhUpload
{
    public class YYhContext : DbContext
    {
        public YYhContext()
            : base("name=yyh")
        {
        }

        //public virtual DbSet<Mjz_Jybg> MjzJybgset { get; set; }
        //public virtual DbSet<Mjz_Jycgbg> MjzJycgbgset { get; set; }
        //public virtual DbSet<Mjz_Jysqd> MjzJysqdset { get; set; }
        //public virtual DbSet<Zy_Jybg> ZyJybgset { get; set; }
        //public virtual DbSet<Zy_Jycgbg> ZyJycgbgset { get; set; }
        //public virtual DbSet<Zy_Jysqd> ZyJysqdset { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
