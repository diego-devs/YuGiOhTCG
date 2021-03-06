using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using YugiohDB.Models;

namespace YugiohDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // path to .txt
            var path = @"C:\Users\d_dia\source\repos\YuGiOhTCG\YugiohDB\data\allCards.txt";
            // to string
            var r = File.ReadAllText(path);
            // Optiond fot serialization, hope to avoid [data] and other null values
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            
            var readedCards = JsonSerializer.Deserialize<ICollection<CardModel>>(r, options);
            

            

            

            // Connect to database in Artemis
            using (var context = new YugiohContext())
            //using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [YgoDB].[dbo].[Cards] ON");
                    //context.Cards.AddRange(readedCards);
                    
                    //context.SaveChanges();
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [YgoDB].[dbo].[Cards] OFF");
                    
                    
                    //transaction.Commit();


                }
                catch (Exception e)
                {
                    Console.WriteLine("Los cambios no pudieron hacerse");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.InnerException.Message);
                }
                finally
                {
                    Console.WriteLine($"{readedCards.Count} cards saved in {context.Database.ProviderName}");
                }
                
            }
        }

    }
    
}
