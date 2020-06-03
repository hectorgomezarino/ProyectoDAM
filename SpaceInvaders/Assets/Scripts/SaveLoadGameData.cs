using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI; //for input text
using System.Runtime.Serialization.Formatters.Binary;


public class SaveLoadGameData : MonoBehaviour
{
    public InputField userNameInputField;
    public CharacterData characterDataNew;


    void Start()
    {
        //TO DO: set the name of the player if exists at load
        characterDataNew = PlayerPrefsCharacterSaver.Instance.CustomAction('L', null); //save it
        if (GameObject.Find("PlayerName") != null) //validate if object exists
        {
            userNameInputField.text = characterDataNew.characterName.ToString(); //set the saved value if exists. //TO DO: this has a bug, solve id pending...
        }
    }


    public void SaveOptions()
    {
        var textUIComp = GameObject.Find("InfoText").GetComponent<Text>();
        textUIComp.text = ""; //clear the text
        string userName = userNameInputField.text;
        characterDataNew.characterName = userName; //set the new userName with the writed into field
        PlayerPrefsCharacterSaver.Instance.CustomAction('S', characterDataNew); //save it
        // TO DO: delay this
        textUIComp.text = "Info Saved.";
    }
}