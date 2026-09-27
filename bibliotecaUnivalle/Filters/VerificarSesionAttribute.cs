using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bibliotecaUnivalle.Filters
{
    // Verifica que haya una sesión activa, si no redirige al login
    public class VerificarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sesion = context.HttpContext.Session.GetString("UsuarioEmail");

            if (string.IsNullOrEmpty(sesion))
            {
                context.Result = new RedirectToActionResult("Login", "Acceso", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
