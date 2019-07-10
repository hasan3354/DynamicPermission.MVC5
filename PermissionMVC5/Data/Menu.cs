using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        public int? ParentId { get; set; }

        public Menu MenuSingle { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }

    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.HasOptional(x => x.MenuSingle).WithMany(x => x.Menus).HasForeignKey(x => x.ParentId);
        }
    }
}