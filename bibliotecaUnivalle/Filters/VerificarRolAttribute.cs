using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bibliotecaUnivalle.Filters
{
    // Verifica que el usuario tenga uno de los roles permitidos
    public class VerificarRolAttribute : ActionFilterAttribute
    {
        private readonly string[] _rolesPermitidos;

        public VerificarRolAttribute(params string[] roles)
        {
            _rolesPermitidos = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("UsuarioRol");

            // Si no hay sesión, redirige al login
            if (string.IsNullOrEmpty(rol))
            {
                context.Result = new RedirectToActionResult("Login", "Acceso", null);
                return;
            }

            // Si el rol no está entre los permitidos, redirige al Home con acceso denegado
            if (!_rolesPermitidos.Contains(rol))
            {
                context.Result = new RedirectToActionResult("AccesoDenegado", "Acceso", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
