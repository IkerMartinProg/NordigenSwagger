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
                Email = "correo@gmail.com",
                TarjetaCredito = "5555555555554444",
                RangoEx = Random.Shared.Next(0, 11),
                RangoIn = Random.Shared.Next(1, 10),
                Precio = 13.54m 
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
                    "Email: " + dato.Email + " | " + "Tarjeta de Crédito: " + dato.TarjetaCredito + "\n" +
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
            RuleFor(x => x.MenorQue).LessThan(10).WithMessage("El campo 'MenorQue' solo puede tener un valor menor que 10.");
            RuleFor(x => x.MenorOIgual).LessThanOrEqualTo(10).WithMessage("El campo 'MenorOIgual solo puede tener un valor menor o igual que 10.'");
            RuleFor(x => x.MayorQue).GreaterThan(0).WithMessage("El campo 'MayorQue' solo puede tener un valor mayor que 0.");
            RuleFor(x => x.MayorOIgual).GreaterThanOrEqualTo(0).WithMessage("El campo 'MayorOIgual' solo puede tener un valor mayor o igual que 0.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("El campo 'Email' debe contener un correo electrónico válido.");
            RuleFor(x => x.TarjetaCredito).CreditCard().WithMessage("El campo 'Tarjeta de crédito' debe contener una tarjeta de crédito válida.");
            RuleFor(x => x.RangoEx).ExclusiveBetween(1, 10).WithMessage("El campo 'RangoEx' solo puede tener un valor entre 1 y 10, sin incluirlos.");
            RuleFor(x => x.RangoIn).InclusiveBetween(1, 10).WithMessage("El campo 'RangoIn' solo puede tener un valor entre 1 y 10.");
            RuleFor(x => x.Precio).ScalePrecision(2, 4).WithMessage("El campo 'Precio' solo puede tener un número con 4 dígitos en total (2 de ellos, decimales).");

        }
    }
}   
