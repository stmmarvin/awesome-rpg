using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    [SerializeField] private ProgressionCharacterClass[] characterClasses;
    Dictionary<CharacterClass, Dictionary<Stats, float[]>> lookupTable = null;

    [System.Serializable]
    class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public ProgressionStat[] stats;
    }

    [System.Serializable]
    class ProgressionStat
    {
        public Stats stat;
        public float[] levels;
    }

    public float GetStat(Stats stat, CharacterClass characterClass, int level)
    {
        foreach (ProgressionCharacterClass progressionClass in characterClasses)
        {
            if (progressionClass.characterClass == characterClass)
            {
                foreach (ProgressionStat progressionStat in progressionClass.stats)
                {
                    if (progressionStat.stat != stat) continue;

                    return progressionStat.levels[level - 1];
                }
            }
        }
        return 0;
    }

    public void Buildlookup()
    {
        if (lookupTable != null) return;

        lookupTable = new Dictionary<CharacterClass, Dictionary<Stats, float[]>>();

        foreach (ProgressionCharacterClass progressionClass in characterClasses)
        {
            var statLookup = new Dictionary<Stats, float[]>();
            foreach (ProgressionStat progressionStat in progressionClass.stats)
            {
                statLookup[progressionStat.stat] = progressionStat.levels;
            }
            lookupTable[progressionClass.characterClass] = statLookup;
        }
    }
}

