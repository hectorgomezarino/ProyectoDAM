using UnityEngine;
using UnityEngine.UI; //for input text


public class SaveLoadGameData : MonoBehaviour
{
    public InputField userNameInputField;
    public CharacterData characterDataVal;

    //Use this for initialization
    public void Start()
    {
        characterDataVal = PlayerPrefsCharacterSaver.Instance.CustomAction('L', characterDataVal); //load it
        if (characterDataVal.characterName != "") {
            var textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
            textNombreJugador.text = ""; //clear the text

            if (GameObject.Find("NombreJugadorText") != null) //validate if object label text exists
                textNombreJugador.text = characterDataVal.characterName;
            if (userNameInputField != null) //only if isset name input field, set it
                userNameInputField.text = characterDataVal.characterName;
        }
    }


    public void SaveOptions()
    {
        var textUIComp = GameObject.Find("InfoText").GetComponent<Text>();
        textUIComp.text = ""; //clear the text
        var textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
        textNombreJugador.text = ""; //clear the text
        string userName = userNameInputField.text;
        characterDataVal.characterName = userName; //set the new userName with the writed into field
        PlayerPrefsCharacterSaver.Instance.CustomAction('S', characterDataVal); //save it
        // TO DO: delay this
        textUIComp.text = "Info Saved.";
        textNombreJugador.text = userName;
    }
}
