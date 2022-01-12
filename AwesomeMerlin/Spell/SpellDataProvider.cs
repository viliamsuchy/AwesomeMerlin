using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class SpellDataProvider : ISpellDataProvider
    {
        private SpellDataProvider()
        {
        }

        private Dictionary<string, SpellInfo> spellInfos;
        private Dictionary<string, int> spellEffects;
        public Dictionary<string, int> GetSpellEffects()
        {
            if (spellEffects == null)
            {
                LoadSpellEffects();
            }
            return spellEffects;
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (spellInfos == null)
            {
                LoadSpellInfo();
            }
            return spellInfos;
        }
        private void LoadSpellEffects()
        {
            spellEffects = new Dictionary<string, int>();
            string js = File.ReadAllText("resources/effects.json");
            List<SpellEffectInfo> effects = JsonConvert.DeserializeObject<List<SpellEffectInfo>>(js);
            foreach (SpellEffectInfo info in effects)
            {
                spellEffects.Add(info.Name, info.Cost);
            }

        }

        private void LoadSpellInfo()
        {
            spellInfos = new Dictionary<string, SpellInfo>();
            string[] lines = File.ReadAllLines("resources/spells.csv");
            
            for(int i = 1; i < lines.Length; i++)
            {
                SpellInfo spellInfo = (SpellInfo)lines[i];
                spellInfos.Add(spellInfo.Name, spellInfo);
            }

        }
        private class SpellEffectInfo
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("cost")]
            public int Cost { get; set; }
        }

        public static SpellDataProvider GetInstance()
        {
            return new SpellDataProvider();
        }
    }
}
