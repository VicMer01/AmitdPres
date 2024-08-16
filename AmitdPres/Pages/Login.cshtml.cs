using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using AmitdPres.Pages;
using Microsoft.EntityFrameworkCore;
namespace AmitdPres.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public IActionResult OnPost(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aquí deberías verificar el usuario y contraseña contra tu base de datos
            // Para este ejemplo, usaremos un usuario y contraseña ficticios
            if (Input.UserName == "" && Input.Password == "")
            {
                // Si la autenticación es exitosa, establecer una cookie de autenticación
                HttpContext.Response.Cookies.Append("AuthCookie", "authenticated");

                // Redirigir al returnUrl o a la página de inicio
                return LocalRedirect(returnUrl ?? "/Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }


    }
} 


