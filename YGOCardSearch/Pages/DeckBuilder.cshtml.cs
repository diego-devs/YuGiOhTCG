using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using YGOCardSearch.Models;
using YGOCardSearch.DataProviders;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using YGOCardSearch.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace YGOCardSearch.Pages
{
    public class DeckBuilder : PageModel
    {
        // Esto tambi�n deber�a cambiar por db:
        public List<DeckModel> LoadedDecks;
        // Deck a visualizar
        public DeckModel Deck { get; set; }
        // Repo de todas las cartas (migrar a db) - sera obsoleto 
        public List<CardModel> AllCards { get; set; }
        // Database
        public readonly YgoContext Context;


        public DeckBuilder(YgoContext db)
        {
            // Good place to initialize data
            this.Context = db;
            AllCards = new List<CardModel>(Context.Cards) ;
            LoadedDecks = new List<DeckModel>();

            // LoadAllDecks();
            Deck = new DeckModel();
            //  Load a local deck file
            string path = @"C:\Users\d_dia\source\repos\YuGiOhTCG\YGOCardSearch\Data\Decks\deck2.ydk";
            LoadedDecks.Add(LoadDeck(path));
            Deck = LoadedDecks.First();

            //db.AddRange(AllCards);
            //db.SaveChanges();
        }

        
        
        public async Task<IActionResult> OnGet()
        {
            
            return Page();

        }
        public List<CardModel> LoadAllCardsFromJSON() 
        {
           
            // Carga todas las cartas de un json
            var allCardsPath = @"C:\Users\d_dia\source\repos\YuGiOhTCG\YGOCardSearch\Data\allCards.txt";
            var jsonCards = System.IO.File.ReadAllText(allCardsPath);
            var AllCards = JsonSerializer.Deserialize<List<CardModel>>(jsonCards);
            return AllCards;
        }
        /// <summary>
        /// Revisa si el deck no tiene ning�n error, de lo contrario lo corrige y regresa el deck.
        /// </summary>
        /// <param name="deckList"></param>
        public static List<string> CleanDeck(List<string> deckList) 
        {
            var returnedDeckList = new List<string>(deckList);

            foreach (var cardId in deckList)
            {
                var cardChars = cardId.ToCharArray();
                bool allClean = cardChars.All(c => char.IsDigit(c));
                if (allClean) 
                {
                    continue;
                }
                else 
                {
                    var onlyDigitsIds = cardChars.Where(c => char.IsDigit(c));
                    var stringId = new string(onlyDigitsIds.ToArray());
                    
                    returnedDeckList.Add(stringId);
                    returnedDeckList.Remove(cardId);
                    continue;
                }
               
            }
            
            return returnedDeckList;
        } 
        ///<summary>
        ///<para>Regresa un DeckModel tomando un archivo .ydk como par�metro</para>
        ///<para>archivos .ydk</para>
        ///</summary>
        public DeckModel LoadDeck(string path)
        {
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\d_dia\source\repos\YuGiOhTCG\YGOCardSearch\Data\Decks", " *.ydk"))
            {
                string contents = System.IO.File.ReadAllText(file);
            }
            // Asegurarnos que la extensi�n sea .ydk (?)...
            string[] ydkDeck = System.IO.File.ReadAllLines(path); // De donde sea se encuentren los decks? 
            var deckIds = new List<string>(ydkDeck);

            int mainIndex = deckIds.FindIndex(c => c.Contains("#main"));
            int extraIndex = deckIds.FindIndex(r => r.Contains("#extra"));
            int sideIndex = deckIds.FindIndex(c => c.Contains("!side"));
            
            var mainDeckResult = deckIds.Skip(mainIndex + 1).Take(extraIndex - (mainIndex + 1)).ToList();
            var extraDeckResult = deckIds.Skip(extraIndex + 1).Take(sideIndex - (extraIndex + 1)).ToList();
            var sideDeckResult = deckIds.Skip(sideIndex + 1).Take(sideIndex - (extraIndex + 1)).ToList();

            // Limpiar las listas de IDS, algunos decks podr�an tener errores como: "112345f" 
            var cleanedMain = CleanDeck(mainDeckResult);
            var cleanedExtra = CleanDeck(extraDeckResult);
            var cleanedSide = CleanDeck(sideDeckResult);
            
            // Obtener todas las cartas de las listas de Ids a listas de cartas
            var mainDeck = new List<CardModel>(getCards(cleanedMain));
            var extraDeck = new List<CardModel>(getCards(cleanedExtra));
            var sideDeck = new List<CardModel>(getCards(cleanedSide));

            // Finalmente crear el deck retornado
            var newDeck = new DeckModel();
            newDeck.MainDeck = mainDeck;
            newDeck.ExtraDeck = extraDeck;
            newDeck.SideDeck = sideDeck;
            newDeck.DeckName = mainDeck[0].Name.ToLower();
            return newDeck;

        }
        
        /// <summary>
        /// Regresa lista de CardModel a partir de una lista de CardId, buscando en YgoDB.
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public List<CardModel> getCards(List<string> cardList) 
        {
                var cards = new List<CardModel>();
                foreach (var cardId in cardList)
                {
                    if (AllCards.Exists(c => c.Id == Convert.ToInt32(cardId)))
                    {
                        var card = AllCards.Single(c => c.Id == Convert.ToInt32(cardId));
                        cards.Add(card);
                    }

                }
 
            return cards;
        }
        
    }
}
