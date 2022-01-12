using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class SpellInfo 
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }


        
        public static explicit operator SpellInfo(string lines)
        {
            string[] data = lines.Split(';');
            SpellInfo spellInfos = new SpellInfo
            {
                Name = data[0],
                SpellType = data[1] == "selfcast" ? SpellType.SelfCast : SpellType.Projectile,
                AnimationPath = data[2],
                AnimationWidth = int.Parse(data[3]),
                AnimationHeight = int.Parse(data[4]),
                EffectNames = data[5].Split(',')
            };
            return spellInfos;

            //string[] lines = data.Split(';');


            //string[] lines = File.ReadAllLines("resources/spells.csv");
            //for (int i = 1; i < lines.Length; i++)
            //{

            //    //}
            //    //foreach (string line in lines)
            //    //{
            //    SpellType type;
            //    string[] data = lines[i].Split(';');
            //    if (data[1] == "projectile")
            //    {
            //        type = SpellType.SelfCast;
            //    }
            //    else if (data[1] == "selfcast")
            //    {
            //        type = SpellType.Projectile;
            //    }
            //    else
            //    {
            //        throw new Exception("Spell type not valid");
            //    }
            //    spellInfos.Add(data[0], new SpellInfo
            //    {
            //        SpellType = type,
            //        Name = data[0],
            //        AnimationPath = data[2],
            //        AnimationWidth = int.Parse(data[3]),
            //        AnimationHeight = int.Parse(data[4]),
            //        EffectNames = data[5].Split(',')

            //    });
            //    //spellInfos.Add(line.Split(';')[0] new SpellInfo(line);


            //}
            //return spellInfos;

        }


    }
   
}
