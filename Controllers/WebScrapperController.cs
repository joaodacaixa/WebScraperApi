﻿using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System;

namespace WebScraperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        public  IActionResult ScrapeData()
        {

            // URL do site que será raspado
            string url = "http://globo.com"; //"http://resultado.caixa/2024/#/resultado/202403/1623";

            // Realiza a requisição GET para obter o conteúdo da página
            var web = new HtmlWeb();
            var doc =  web.Load(url);
            var alltext =  doc.DocumentNode.InnerText;
            // string caminho = @"C:\temp";
            //string filePath = "scrap.txt";
            //System.IO.File.WriteAllText(filePath, alltext);
            return Ok(alltext);

            // Encontra a tabela desejada no HTML da página (substitua "minhaTabela" pelo ID ou classe da tabela)
            //var alltext = doc.DocumentNode.InnerText;
            //var table = doc.DocumentNode.SelectSingleNode("//table[@id='tabResult2']");
            //var stringbuilder = new StringBuilder();
            /*if (table != null)
            {
                //var stringbuilder = new StringBuilder();
                // Extrai os dados da tabela
                foreach (var item in table.SelectNodes("//tr"))
                {
                    stringbuilder.AppendLine(item.InnerText.Trim());
                }
                stringbuilder.AppendLine("fim do arquivo");
                string caminho = @"C:\temp";
                string filePath =Path.Combine(caminho, "dados_lista.txt");
                System.IO.File.WriteAllText(filePath, stringbuilder.ToString());
               // var listeditem = orderedlist.SelectNodes(".//li");
                //var scrapedData = listeditem.Select(item => item.InnerText.Trim());

                return Ok("dados salvos "+ filePath);
            }
            else
            {
                stringbuilder.AppendLine("fim do arquivo -sem registros");
                return NotFound("Tabela não encontrada");
            }*/
          
            //return Ok("texto raspado salvo em " + filePath);

        }


    }
}
