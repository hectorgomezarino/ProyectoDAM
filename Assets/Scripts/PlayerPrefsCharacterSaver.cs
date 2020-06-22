using UnityEngine;

public class PlayerPrefsCharacterSaver : MonoBehaviour
{
    public static PlayerPrefsCharacterSaver Instance = null;
    public CharacterData characterData;


    //****************************************************************//
    // IMPORTANT: ever saving on 0 Slot, we save only 1 custom player.//
    //****************************************************************//

    //Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //when press S save data
            SaveCharacter(characterData, 0);
        if (Input.GetKeyDown(KeyCode.L)) //when press L load data
            characterData = LoadCharacter(0);
    }

    /*
     * @description: like update but taking parameters.
     * @param char Action, S to save, L to load.
     * @param CharacterData characterDataGived, not required
     * @return CharacterData object, depending the Action characterDataGived
     */
    public CharacterData CustomAction(char Action, CharacterData characterDataGived = null)
    {
        if (Action == 'S') //when press S save data
        {
            SaveCharacter(characterDataGived, 0);
            return characterDataGived;
        }

        if (Action == 'L') //when press L load data
        {
            characterData = LoadCharacter(0); //IMPORTANT: ever saving on 0 Slot, we save only 1 custom player.
            return characterData;
        }
        return characterDataGived;
    }


    static void SaveCharacter(CharacterData data, int characterSlot)
    {
        PlayerPrefs.SetString("characterName_CharacterSlot" + characterSlot, data.characterName);
        PlayerPrefs.SetFloat("power_CharacterSlot" + characterSlot, data.power);
        PlayerPrefs.SetInt("bullets_CharacterSlot" + characterSlot, data.Ammo);
        PlayerPrefs.Save();
    }

    static CharacterData LoadCharacter(int characterSlot)
    {
        CharacterData loadedCharacter = new CharacterData {
            characterName = PlayerPrefs.GetString("characterName_CharacterSlot" + characterSlot),
            power = PlayerPrefs.GetFloat("power_CharacterSlot" + characterSlot),
            Ammo = PlayerPrefs.GetInt("bullets_CharacterSlot" + characterSlot)
        };

        return loadedCharacter;
    }




    /*public CustomVariableClass(float timePlayedF)
    {
        timePlayed = timePlayedF;
    }*/

    /*test function, no es funcional ahora mismo TODO: todo.*/
    /*public void CustomVariableClass(int scoreInt, string nameStr, float timePlayedF)
    {
        CharacterData loadedCharacter = new CharacterData();
        loadedCharacter.score = scoreInt;
        loadedCharacter.playerName = nameStr;
        loadedCharacter.timePlayed = timePlayedF;
    }*/
}
