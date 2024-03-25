using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net;
using System.Linq;
using System.Text;

namespace WebScraperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        public IActionResult ScrapeData()
        {
            // URL do site que será raspado
            string url = "https://resultado.caixa";

            // Realiza a requisição GET para obter o conteúdo da página
            var web = new HtmlWeb();
            var doc = web.Load(url);
           

           
            // Encontra a tabela desejada no HTML da página (substitua "minhaTabela" pelo ID ou classe da tabela)
            var table = doc.DocumentNode.SelectSingleNode("//table@[id='tabResult2']");

            if (table != null)
            {
                var stringbuilder = new StringBuilder();
                // Extrai os dados da tabela
                foreach (var item in table.SelectNodes("//tr"))
                {
                    stringbuilder.AppendLine(item.InnerText.Trim());
                }
                string caminho = @"C:\Users\";
                string filePath =Path.Combine(caminho, "dados_lista.txt");
                System.IO.File.WriteAllText(filePath, stringbuilder.ToString());
               // var listeditem = orderedlist.SelectNodes(".//li");
                //var scrapedData = listeditem.Select(item => item.InnerText.Trim());

                return Ok("dados salvos "+ filePath);
            }
            else
            {
                return NotFound("Tabela não encontrada");
            }
        }
    }
}
