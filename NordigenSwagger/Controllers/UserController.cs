using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace NordigenSwagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        // Posibles valores de la variable "nombre".
        // Dichos valores se guardan en el array "nombres".
        private static readonly string[] nombres = new[]
        {
            "Mateo", "Iker", "Ainhoa", "Eder", "Gustabo"
        };

        /// <summary>
        /// Función para ver un usuario
        /// </summary>
        /// <returns></returns>

        // MÉTODO: GET
        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            // Se mostrarán cinco resultados
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Id = Random.Shared.Next(1, 100),
                Fecha = DateTime.Now,
                Nombre = nombres[Random.Shared.Next(nombres.Length)],
                Telf = Random.Shared.Next(100000000, 999999999),
                Salario = Random.Shared.Next(900, 2000),
                Comision = Random.Shared.Next(0, 300)
            })
            .ToArray(); 
        }


        /// <summary>
        /// Función para añadir un usuario
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Resultado del alta</returns>
        [HttpPost(Name = "PostUser")]

        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                double comision_p = Math.Round(((user.Comision * 100) / user.Salario), 2);
                string resultado = "Nombre: " + user.Nombre + " | " + "Teléfono: +34 " + user.Telf + " | " + "Salario: "
                    + user.Salario + "€" + " | " + "Comisión: " + comision_p + "%";
                return Ok(resultado);
            }
            catch
            {
                return BadRequest("Error de cálculo");
            }            
        }

        /*
        
        public IActionResult AddUser([FromBody] UserPost user)
        {
            try
            {
                double comision_p = Math.Round(((user.Comision * 100) / user.Salario), 2);
                string resultado = "Nombre: " + user.Nombre + " | " + "Teléfono: +34 " + user.Telf + " | " + "Salario: "
                    + user.Salario + "€" + " | " + "Comisión: " + comision_p + "%";
            }
            catch
            {
            }
        }

        */

        /*
        public IActionResult AddBankAccount()
        {
            return Ok();
        }
        */
    }

    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("El campo 'nombre' debe tener algún valor.");
            RuleFor(x => x.Nombre).NotEmpty().When(x => x.Nombre is not null).WithMessage("El campo 'nombre' debe tener algún valor.");
            RuleFor(x => x.Telf).ExclusiveBetween(100000000, 999999999).WithMessage("El campo 'Teléfono' debe tener 9 dígitos.");
            RuleFor(x => x.Salario).GreaterThan(0).WithMessage("El campo 'Salario' debe ser mayor que 0.");
            RuleFor(x => x.Comision).Must((x, y) => x.Salario > x.Comision).WithMessage("El campo 'Comisión' debe ser menor que el salario.");

            // When(x => x.Nombre is not null) --> Después de comprobar que el campo no es nulo, se revisa el siguiente requisito.
        }
    }

    /*
    public class BankAccount
    {
        public UserPost User { get; set; }
        public decimal Amount { get; set; }
    }
    */


    /// <summary>
    /// Datos del usuario del post
    /// </summary>

    /*
    public class UserPost
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public double Salario { get; set; }
        public double  Comision { get; set; }        
    }

    public class UserPostValidator: AbstractValidator<UserPost>
    {
        
        public UserPostValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("el campo 'nombre' debe tener algún valor");
            RuleFor(x => x.Nombre).NotEmpty().When(x => x.Nombre is not null).WithName("el campo 'nombre' debe tener algún valor");
            RuleFor(x => x.Telefono).ExclusiveBetween(100000000, 999999999);
            RuleFor(x => x.Salario).GreaterThan(0);
            RuleFor(x => x.Comision).Must((x, y) => x.Salario > x.Comision);
        }
    }
    */

}
