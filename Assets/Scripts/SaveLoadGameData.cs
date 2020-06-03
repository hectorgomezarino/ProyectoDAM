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
    string PlayerNameString;


    public void Start()
    {
        //TO DO: set the name of the player if exists at load
        //characterDataNew = PlayerPrefsCharacterSaver.Instance.CustomAction('L', null); //load??? it

        //Debug.Log(userNameInputField.text);
        //PlayerNameString = userNameInputField.text;
        ////Debug.Log(PlayerNameString);

        if (GameObject.Find("PlayerName") != null) //validate if object exists
        {
            //Debug.Log(GameObject.Find("PlayerName"));
            //userNameInputField.text = "Pepito"; //TO DO: this has a bug, solve id pending...

            //userNameInputField.text = characterDataNew.characterName.ToString(); //set the saved value if exists. //TO DO: this has a bug, solve id pending...
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
