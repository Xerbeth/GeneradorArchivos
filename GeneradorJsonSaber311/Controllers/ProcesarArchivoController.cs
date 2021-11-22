using GeneradorJsonSaber311.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                if (items.Any())
                {
                    foreach (var i in items)
                    {
                        string folder = @"" + i.TestName + "/" + i.ItemNumero;                        
                        DirectoryInfo di = Directory.CreateDirectory(folder);
                        i.Content = string.Join("https://s3.amazonaws.com/pruelec2017/mediaContent/", i.Content.Split("{{rutaBase}}"));

                        int total = Regex.Matches(i.Content, "type=\"radio\"").Count;
                        i.Content = string.Join("type=\"hidden\"", i.Content.Split("type=\"radio\""));
                        
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"A\"/><br><b>A.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"A\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"B\"/><br><b>B.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"B\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"C\"/><br><b>C.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"C\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"D\"/><br><b>D.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"D\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"E\"/><br><b>E.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"E\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"F\"/><br><b>F.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"F\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"G\"/><br><b>G.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"G\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"H\"/><br><b>H.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"H\"/>"));
                        i.Content = string.Join("type=\"hidden\" name=\"resp\" value=\"I\"/><br><b>I.</b>", i.Content.Split("type=\"hidden\" name=\"resp\" value=\"I\"/>"));
                       
                        string path = folder + "/"+i.ItemNumero + ".html";
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