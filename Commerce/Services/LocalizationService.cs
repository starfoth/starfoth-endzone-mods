using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatBuffers;
using PatchZone.Hatch;
using PatchZone.Hatch.Annotations;
using Service.Localization;
using TMPro;

namespace Commerce.Services
{
    public class LocalizationService : ProxyService<LocalizationService, ILocalizationService>
    {
        private const string ADDITIONAL_TEXT = "\n\\u2022 Check out <u><link=”https://github.com/Starfoth/Starfoth-Endzone-Mods</link></u>\nCommerce++ is a mod dedicated to improving supply chains and market logistics, it expands the usefullness of logisticians by adding industrial supply chain buildings, more market stalls with specialized usages, global limit exceptions to local production (to ensure consistent supply), and a few commercial decorations to create thriving and beautiful marketplaces!";

        [LogicProxy]
        public void Localize(Keys locaKey, TextMeshProUGUI textOutput, Dictionary<string, string> replacements, ReplacementStyle replacementStyle)
        {
            this.Vanilla.Localize(locaKey, textOutput, replacements, replacementStyle);

            if (locaKey == Keys.Common_EarlyAccessDisclaimer)
            {
                var text = textOutput.text;
                text += ADDITIONAL_TEXT;
                textOutput.text = text;
            }
        }

        [LogicProxy]
        public string GetLocalization(Keys locaKey, Dictionary<string, string> replacements, ReplacementStyle replacementStyle)
        {
            var text = this.Vanilla.GetLocalization(locaKey, replacements);
            
            if (locaKey == Keys.Common_EarlyAccessDisclaimer)
            {
                text += ADDITIONAL_TEXT;
            }

            return text;
        }
    }
}
