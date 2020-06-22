using UnityEngine;
using UnityEngine.UI; //for input text
using System;


public class SaveLoadGameData : MonoBehaviour
{
    public InputField userNameInputField;
    public CharacterData characterDataVal;
    private bool isCoroutineExecuting = false;

    //Use this for initialization
    public void Start()
    {
        characterDataVal = PlayerPrefsCharacterSaver.Instance.CustomAction('L', characterDataVal); //load it
        if (characterDataVal.characterName != "")
        {
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
        StartCoroutine(ExecuteAfterTime(0.5f, () =>
        {
            //Add somwthing here
            textUIComp = GameObject.Find("InfoText").GetComponent<Text>();
            textUIComp.text = "Info Saved.";
            textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
            textNombreJugador.text = userName;
        }));
    }

    private System.Collections.IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
}
