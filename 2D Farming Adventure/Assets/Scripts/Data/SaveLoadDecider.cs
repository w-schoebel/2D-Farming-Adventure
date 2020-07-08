using Assets.Scripts.Character;
using Assets.Services;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class SaveLoadDecider : MonoBehaviour
    {
        public void SaveCurrentCharacter()
        {
            if (CharacterDecider.instance != null)
            {
                CharacterDecider.instance.GetCurrentCharacterPlayerStats().SavePlayer();
            }
        }

        public void LoadCurrentCharacter()
        {
            if (CharacterDecider.instance != null)
            {
                CharacterDecider.instance.GetCurrentCharacterPlayerStats().LoadPlayer();
            }
        }
    }
}
