using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    //para mudar a url ao abrir e não mostrar WeattherForecats va em properties"LaunchSettings.json" e alteres os "launchUrl", altere tambem o "sslPort" de 44396 para 44300
    
    //==========================================================

    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        //Mude o nome do controllers
        //apague a ultima classe criada que é o WeattherForecats
        //apague tudo isso
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //==========================================================

        private readonly ILogger<CalculatorController> _logger;


        //==========================================================


        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        //calculadora pelo get
        //==========================================================
        //aqui sera a adição

        //quando passar a requisição para o "firstNumber" e "secondNumber" ele verifica se é numerico(se for string da erro)
        //esse codio abaixo é o "endPoint"
        [HttpGet("sum/{firstNumber}/{secondNumber}")] // antes aqui estava assim [HttpGet]

        // dentro do Get abaixo coloque o string firstNunber e string secondNunber (poderia ao inves de string ser INT)
        public IActionResult Get(string firstNumber, string secondNumber) //antes aqui estava assim public IEnumerable<WeatherForecast> Get()
        {            
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber); //aqui vai calcular os numeros que eu colocar no "sum"
                //precisa ser convertido pois esta como string

                return Ok(sum.ToString());

                //apague essa implementação abaixo
                //var rng = new Random();
                //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = DateTime.Now.AddDays(index),
                //    TemperatureC = rng.Next(-20, 55),
                //    Summary = Summaries[rng.Next(Summaries.Length)]
                //})
                //.ToArray();



            }
            return BadRequest("Invalid Input"); //retornar quand o input vier errado (vier como string e não numerico)


        }

        //==========================================================
        //realizando outras contas matematicas

        //aqui sera a raiz quadrada
        [HttpGet("square-root/{firstNumber}")] 
        
        public IActionResult Squareroot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareroot = Math.Sqrt((double)ConvertToDecimal(firstNumber)); 

                return Ok(squareroot.ToString());
            }
            return BadRequest("Invalid Input"); 


        }


        //==========================================================

        [HttpGet("Division/{firstNumber}/{secondNumber}")] 

        //aqui sera a divisao
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber); 

                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");

        }

        //==========================================================

        [HttpGet("Subtratcion/{firstNumber}/{secondNumber}")] 

        // aqui sera a subtração
        public IActionResult Subtratcion(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var Subtratcion = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber); 

                return Ok(Subtratcion.ToString());
            }
            return BadRequest("Invalid Input"); 

        }

        //==========================================================


        [HttpGet("Multiplication/{firstNumber}/{secondNumber}")] 
        
        //aqui sera a multiplicação
        public IActionResult Multiplication(string firstNumber, string secondNumber) 
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var Multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(Multiplication.ToString());
            }
            return BadRequest("Invalid Input"); 


        }

        //==========================================================

        private bool IsNumeric(string strtNumber) //renomeei para strNumber
        {
            //a hora que eu criei o if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //ele deu um erro, cliquei na lampada e pedir para ele gerar o metodo IsNumeric
            //e ele gerou e esta aqui.
            

            //aqui vai ver se é numerico, se não for vai dar false e vai retornar
            double number;
            bool isNumber = double.TryParse(strtNumber, System.Globalization.NumberStyles.Any,
                                                        System.Globalization.NumberFormatInfo.InvariantInfo,
                                                        out number);
            
            return isNumber;


            throw new NotImplementedException();
        }
        //==========================================================

        private decimal ConvertToDecimal(string strtNumber) //renomeei para strNumber e mudei para decimal
        {
            decimal decimalValue;
            if(decimal.TryParse(strtNumber, out decimalValue))
            {
                return decimalValue;
            }




            return 0;

            //a hora que eu criei var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //ele deu um erro, cliquei na lampada e pedir para ele gerar o metodo ConvertToDecimal
            //e ele gerou e esta aqui.
            throw new NotImplementedException();
        }



    }
}
