using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace YugiohDB.Models
{ 
        public partial class CardModel
        {
            [Key]
            [JsonPropertyName("InternalID")]
            public int InternalID {get;set;}


            [JsonPropertyName("id")]
            public int CardID { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("desc")]
            public string Desc { get; set; }

            [JsonPropertyName("atk")]
            public long Atk { get; set; }

            [JsonPropertyName("def")]
            public long Def { get; set; }

            [JsonPropertyName("level")]
            public long Level { get; set; }

            [JsonPropertyName("race")]
            public string Race { get; set; }

            [JsonPropertyName("attribute")]
            public string Attribute { get; set; }

            [JsonPropertyName("card_sets")]
            public List<SetModel> CardSets { get; set; }

            [JsonPropertyName("card_images")]
            public List<CardImage> CardImages { get; set; }

            [JsonPropertyName("card_prices")]
            public List<PriceModel> CardPrices { get; set; }

            [JsonPropertyName("data")]
            public List<CardModel> Data { get; set; }
    }


    
    
}
