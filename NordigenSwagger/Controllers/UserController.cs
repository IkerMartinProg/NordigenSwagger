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


        // GET
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

          
        // POST
        [HttpPost(Name = "PostUser")]
        public string AddUser(string nombre, int telf, double salario, 
            double comision)
        {
            // Si el campo "nombre" no está vacío.
            if (nombre is not null)
            {
                // Si el campo "teléfono" tiene 9 dígitos.
                if (telf > 100000000 && telf < 999999999)
                {
                    // Si el salario es mayor a 0.
                    if (salario > 0)
                    {
                        // Si el salario es mayor que la comisión.
                        if (salario > comision)
                        {
                            // Calculamos el porcentaje de la comisión con respecto al salario.
                            // Math.Round(variable, 2) --> Redondea el valor introducido y limita el número de decimales mostrados.
                            double comision_p = Math.Round(((comision * 100) / salario), 2);
                            string resultado = "Nombre: " + nombre + " | " + "Teléfono: +34 " + telf + " | " + "Salario: " 
                                + salario + "€" + " | " + "Comisión: " + comision_p + "%";

                            // Finalmente, se muestra el resultado.
                            return (resultado);
                        }
                        else
                        {
                            return "ERROR: el salario debe ser mayor que la comisión.";
                        }
                    }
                    else
                    {
                        return "ERROR: el salario debe ser mayor que 0.";
                    }
                }
                else
                {
                    return "ERROR: el teléfono debe tener 9 dígitos.";
                }
            }
            else
            {
                return "ERROR: el campo 'nombre' debe tener algún valor.";
            }
        }
    }
}
