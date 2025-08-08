using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SistemaReservasRestaurante.Models;

[assembly: OwinStartupAttribute(typeof(SistemaReservasRestaurante.Startup))]
namespace SistemaReservasRestaurante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesYUsuarios();
        }

        private void CrearRolesYUsuarios()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Crear rol Admin si no existe
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Crear un usuario Admin por defecto (puedes cambiar email y contraseña)
                var user = userManager.FindByEmail("admin@tudominio.com");
                if (user == null)
                {
                    user = new ApplicationUser { UserName = "admin@tudominio.com", Email = "admin@tudominio.com" };
                    string userPassword = "Admin123!"; // Cambia la contraseña por algo seguro
                    var result = userManager.Create(user, userPassword);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }
                else
                {
                    // Si usuario existe pero no tiene rol admin, se lo asignamos
                    if (!userManager.IsInRole(user.Id, "Admin"))
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }
            }
        }
    }
}
