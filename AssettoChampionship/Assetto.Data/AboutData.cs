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
                Title = "Thank you for trying out the app",
                Text = "It's been made by József Halmi. You can contact me any time via email: halmi.jozsef.90@hotmail.hu."
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
            },
              new AboutSection()
            {
                Title = "Paul Ricard & Hungaroring",
                Text = "As for the tracks Paul Ricard and Hungaroring, I did not get explicit permission, but I hope, the creators won't mind using it. Strarck3D, the author of the Paul Ricard AC track has been messaged without response. The author of the Hungaroring is unkown, I could not find a contact."
            }
        };
    }
}
