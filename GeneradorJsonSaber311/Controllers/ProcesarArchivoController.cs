using GeneradorJsonSaber311.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneradorJsonSaber311.Controllers
{
    public class ProcesarArchivoController
    {
        public ProcesarArchivoController()
        {
        }

        public void Crear(List<Item> items)
        {
            try
            {
                string folder = string.Empty;
                string grado = 11.ToString();
                if (items.Any())
                {
                    folder = @"" + grado + "/" + string.Join("-", items.First().TestName.Split(":"));
                    DirectoryInfo diprincipal = Directory.CreateDirectory(folder);
                    string pathPrincipal = folder + "/" + string.Join("-", items.First().TestName.Split(":")) + ".json";
                    System.IO.File.WriteAllText(pathPrincipal, System.Text.Json.JsonSerializer.Serialize(items));
                    foreach (var i in items)
                    {
                        folder = @"" + grado + "/" + string.Join("-", i.TestName.Split(":")) + "/" + i.ItemNumero;
                        DirectoryInfo diSecundario = Directory.CreateDirectory(folder);

                        i.Content = "<b style=color:orange;font-size:20px;>" + i.TestName + " - Cuadernillo 2 </b><br>" +
                                    "<b style=color:orange;font-size:20px;>Saber " + grado + ".°</b>" + i.Content;

                        i.Content = string.Join("tabindex='15'>\n        <p class=\"txt-jty\"><b>" + i.Order + ".</b> ", i.Content.Split("tabindex='15 '>\n        <p class=\"txt-jty\">"));

                        i.Content = string.Join("https://s3.amazonaws.com/pruelec2017/mediaContent/", i.Content.Split("{{rutaBase}}"));

                        int total = Regex.Matches(i.Content, "type=\"radio\"").Count;
                        i.Content = string.Join("type=\"hidden\"", i.Content.Split("type=\"radio\""));
                        i.Content = string.Join("type=\"hidden\" style=\"visibility:hidden;\"", i.Content.Split("type=\"button\""));
                        i.Content = string.Join("type=\"hidden\" style=\"visibility:hidden;\"", i.Content.Split("type='button'"));

                        i.Content = string.Join("<table style=\"border:1px solid black; border-collapse:collapse;\">", i.Content.Split("<table class=\"table table-sm table-bordered table-striped table-responsive\" >"));
                        i.Content = string.Join("<th style=\"border:1px solid black;\">", i.Content.Split("<th>"));
                        i.Content = string.Join("<th scope=\"row\" style=\"width:40%; border:1px solid black;\">", i.Content.Split("<th scope=\"row\" style=\"width:40%\">"));
                        i.Content = string.Join("<td style=\"border:1px solid black;\">", i.Content.Split("<td>"));                        

                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"A\"/><br><b>A.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"A\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"B\"/><br><b>B.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"B\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"C\"/><br><b>C.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"C\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"D\"/><br><b>D.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"D\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"E\"/><br><b>E.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"E\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"F\"/><br><b>F.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"F\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"G\"/><br><b>G.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"G\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"H\"/><br><b>H.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"H\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"I\"/><br><b>I.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"I\"/>"));

                        if (i.ItemNumero.Contains("P2_C_") || i.ItemNumero.Contains("P4_C_") || i.ItemNumero.Contains("P7_C_"))
                        {
                            i.Content = i.Content + "<br><b>" + i.ItemNumero.Remove(0, 5) + "</b>";                           
                        }
                        else if (i.ItemNumero.Contains("G_C_"))
                        {
                            i.Content = i.Content + "<br><b>" + i.ItemNumero.Remove(0, 4) + "</b>";
                        }
                        else
                        {
                            i.Content = i.Content + "<br><b>" + string.Join("", i.ItemNumero.Split("I_")) + "</b>";
                        }                        

                        string path = folder + "/" + i.ItemNumero + ".html";
                        System.IO.File.WriteAllText(path, i.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}