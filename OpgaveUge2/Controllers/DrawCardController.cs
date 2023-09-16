using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace OpgaveUge2.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class DrawCardController : ControllerBase
    {
        IList<Card> Cards = new List<Card>();
        String[] colors = new String[] {"Diamonds", "Clubs", "Spades", "Hearts"};


        [HttpGet(Name = "FindCard")]
        public Card Get()
        {
            for (var i = 0; i < colors.Length; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Suits card = new()
                    {
                        Color = colors[i],
                        Number = j
                    };
                    Cards.Add(card);
                }
            }
            for (int i = 1; i < 4; i++)
            {
                Joker card = new()
                {
                    Name = $"Joker {i}"
                };
                Cards.Add(card);
            }

            Random rnd = new Random();
            int randomCard = rnd.Next(0, Cards.Count);

            return Cards[randomCard];
        }
    }
}
