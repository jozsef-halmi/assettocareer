using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Data
{
    public static class AboutData
    {
        public static List<AboutSection> AboutSections = new List<AboutSection>()
        {
            new AboutSection()
            {
                Title = "Assetto corsa 3rd party career",
                Text = "Made by József Halmi. You can contact me any time via email: halmi.jozsef.90@hotmail.hu"
            }
        };
          

        public static List<AboutSection> CreditSections = new List<AboutSection>()
        {
            new AboutSection()
            {
                Title = "Formula 3 car",
                Text = "I have been granted a permission by Andrea Lojelo to use this fantastic car. Thank you very much for that!"
            },
            new AboutSection()
            {
                Title = "Tor Poznań track",
                Text = "I have been granted a permission by Szymik to use this high-quality virtual recreation of the polish track called Tor Poznań. I'm very pleased for that!"
            }
        };
    }
}
