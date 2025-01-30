using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HttpValidarCpf
{
    public static class FnValidaCpf
    {
        [FunctionName("fnvalidacpf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciando validação do CPF");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(requestBody);
            string cpf = data?.cpf;

            if (string.IsNullOrWhiteSpace(cpf))
                return new BadRequestObjectResult("Por favor, informe um CPF válido.");

            return ValidaCPF(cpf) 
                ? new OkObjectResult("CPF válido") 
                : new BadRequestObjectResult("CPF inválido");
        }

        private static bool ValidaCPF(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cpfBase = cpf.Substring(0, 9);
            int primeiroDigito = CalcularDigito(cpfBase, multiplicadores1);
            int segundoDigito = CalcularDigito(cpfBase + primeiroDigito, multiplicadores2);

            return cpf.EndsWith(primeiroDigito.ToString() + segundoDigito.ToString());
        }

        private static int CalcularDigito(string baseCpf, int[] multiplicadores)
        {
            int soma = baseCpf.Select((t, i) => (t - '0') * multiplicadores[i]).Sum();
            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
