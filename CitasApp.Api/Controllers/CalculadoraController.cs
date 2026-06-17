using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("sumar")]
        public IActionResult Sumar(double a, double b)
        {
            var resultado = a + b;

            return Ok(new
            {
                operacion = "suma",
                a = a,
                b = b,
                resultado = resultado
            });
        }

        [HttpGet("restar")]
        public IActionResult Restar(double a, double b)
        {
            var resultado = a - b;

            return Ok(new
            {
                operacion = "resta",
                a = a,
                b = b,
                resultado = resultado
            });
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar(double a, double b)
        {
            var resultado = a * b;

            return Ok(new
            {
                operacion = "multiplicacion",
                a = a,
                b = b,
                resultado = resultado
            });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir(double a, double b)
        {
            if (b == 0)
            {
                return BadRequest(new
                {
                    error = "No se puede dividir entre cero"
                });
            }

            var resultado = a / b;

            return Ok(new
            {
                operacion = "division",
                a = a,
                b = b,
                resultado = resultado
            });
        }
    }
}
