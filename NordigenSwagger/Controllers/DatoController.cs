using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace NordigenSwagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatoController : Controller
    {

        private static readonly string[] Nombres = new[]
        {
            "Antonio", "Luis", "Maria"
        };

        private static readonly string[] Apellidos1 = new[]
        {
            "Martin", "Gaztelu", "Iglesias"
        };

        private static readonly string[] Apellidos2 = new[]
        {
            "Txurdinaga", "Etxebarri", "Otxarkoaga"
        };

        /// <summary>
        /// Función para ver un dato
        /// </summary>
        /// <returns></returns>

        // GET
        [HttpGet(Name = "GetDato")]
        public IEnumerable<Dato> Get()
        {
            return Enumerable.Range(1, 3).Select(index => new Dato
            {
                Id = Random.Shared.Next(1, 5),
                Nombre = Nombres[Random.Shared.Next(Nombres.Length)],
                Apellido1 = Apellidos1[Random.Shared.Next(Apellidos1.Length)],
                Apellido2 = Apellidos2[Random.Shared.Next(Apellidos2.Length)],
                Respuesta = "SI",
                MenorQue = Random.Shared.Next(1, 9),
                MenorOIgual = Random.Shared.Next(1, 10),
                MayorQue = Random.Shared.Next(1, 5),
                MayorOIgual = Random.Shared.Next(0, 5),
                UnoACuatro = Random.Shared.Next(1, 4),
                Email = "correo@gmail.com",
                TarjetaCredito = "5555555555554444",
                Vacio = null,
                RangoEx = Random.Shared.Next(0, 11),
                RangoIn = Random.Shared.Next(1, 10),
                Precio = 3.54 
            })
            .ToArray();
        }

        /// <summary>
        /// Función para añadir un dato
        /// </summary>
        /// <param name="dato">Lista de datos</param>
        /// <returns>Resultado del alta</returns>
        // POST
        [HttpPost(Name = "PostDato")]
        public IActionResult AddDato([FromBody] Dato dato)
        {
            try
            {
                string resultado = "Id: " + dato.Id + " | " + "Nombre: " + dato.Nombre + "\n" +
                    "Apellido 1: " + dato.Apellido1 + " | " + "Apellido 2: " + dato.Apellido2 + "\n" +
                    "Respuesta: " + dato.Respuesta + "\n" +
                    "Menor Que: " + dato.MenorQue + " | " + "Menor O Igual: " + dato.MenorOIgual + "\n" +
                    "Mayor Que: " + dato.MayorQue + " | " + "Mayor O Igual: " + dato.MayorOIgual + "\n" +
                    "Uno A Cuatro: " + dato.UnoACuatro + "\n" +
                    "Email: " + dato.Email + " | " + "Tarjeta de Crédito: " + dato.TarjetaCredito + "\n" +
                    "Vacio: " + dato.Vacio + "\n" +
                    "RangoEx: " + dato.RangoEx + " | " + "RangoIn: " + dato.RangoIn + "\n" +
                    "Precio: " + dato.Precio;
                return Ok(resultado);
            }
            catch
            {
                return BadRequest("ERROR");
            }
        }
    }

    public class DatoValidator : AbstractValidator<Dato>
    {
        public DatoValidator()
        {

            RuleFor(x => x.Id).NotNull().WithMessage("El campo 'Id' debe tener algún valor.");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede estar vacio.");
            RuleFor(x => x.Nombre).NotEqual("SinNombre").WithMessage("El campo 'Nombre' no puede tener el valor 'SinNombre'.");
            RuleFor(x => x.Respuesta).Equal("SI").WithMessage("El campo 'Respuesta' debe tener el valor 'SI'.");
            RuleFor(x => x.Apellido1).Length(6, 7).WithMessage("El campo 'Apellido1' debe tener 6 o 7 caracteres.");
            RuleFor(x => x.Apellido2).MaximumLength(10).WithMessage("El campo 'Apellido2' solo puede tener 10 dígitos como máximo.");
            RuleFor(x => x).

            /*
            RuleFor(x => x.Nombre).NotNull().WithMessage("El campo 'nombre' debe tener algún valor.");
            RuleFor(x => x.Nombre).NotEmpty().When(x => x.Nombre is not null).WithMessage("El campo 'nombre' debe tener algún valor.");
            RuleFor(x => x.Telf).ExclusiveBetween(100000000, 999999999).WithMessage("El campo 'Teléfono' debe tener 9 dígitos.");
            RuleFor(x => x.Salario).GreaterThan(0).WithMessage("El campo 'Salario' debe ser mayor que 0.");
            RuleFor(x => x.Comision).Must((x, y) => x.Salario > x.Comision).WithMessage("El campo 'Comisión' debe ser menor que el salario.");
            */
        }
    }
}   
