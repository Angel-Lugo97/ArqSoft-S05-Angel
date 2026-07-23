using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    [ApiController]
    [Route("api/calculadora")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("sumar")]
        public IActionResult Sumar(double a, double b)
        {
            return Ok(new
            {
                operacion = "suma",
                a,
                b,
                resultado = a + b
            });
        }

        [HttpGet("restar")]
        public IActionResult Restar(double a, double b)
        {
            return Ok(new
            {
                operacion = "resta",
                a,
                b,
                resultado = a - b
            });
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar(double a, double b)
        {
            return Ok(new
            {
                operacion = "multiplicacion",
                a,
                b,
                resultado = a * b
            });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir(double a, double b)
        {
            if (b == 0)
            {
                return BadRequest(new
                {
                    mensaje = "No se puede dividir entre cero"
                });
            }

            return Ok(new
            {
                operacion = "division",
                a,
                b,
                resultado = a / b
            });
        }
    }
}
