using Microsoft.EntityFrameworkCore;
using Cizon.Domain.Entities;


namespace Cizon.EntityFrameworkCore
{
   

    public class CizonDbContext:DbContext
    {
        public CizonDbContext()
        {

        }
        public CizonDbContext(DbContextOptions<CizonDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 属性名称必须和数据库名称一样（包含大小写）
        /// </summary>
        public DbSet<DeptDto> dept { get; set; }
        public DbSet<MenuDto> s_menu { get; set; }
        public DbSet<RoleDto> s_role { get; set; }
        public DbSet<UserInfoDto> userinfo { get; set; }
        public DbSet<RightDto> s_right { get; set; }
        public DbSet<RoleAssignmentDto> s_roleassignment { get; set; }
        public DbSet<RoleSettingDto> s_rolesetting { get; set; }
        /// <summary>
        /// mysql连接字符串
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;port=3306;Database=cizoncms;Uid=root;Pwd=wsht2016");
        }

        /// <summary>
        /// 重写模型绑定的方法OnModelCreating，然后设置对应实体属性的规则，这种方式叫做Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
