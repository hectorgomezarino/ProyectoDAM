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

    // Update is called once per frame
    void Update()
    {
        /*characterDataVal = PlayerPrefsCharacterSaver.Instance.CustomAction('L', characterDataVal); //load it
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space) 
                ||  (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter")) 
            ) {
            SaveOptions();
        }*/
    }

    public void SaveOptions()
    {
        var textUIComp = GameObject.Find("InfoText").GetComponent<Text>();
        textUIComp.text = ""; //clear the text
        Text textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
        textNombreJugador.text = ""; //clear the text
        string newUserName = userNameInputField.text;
        if ((characterDataVal.characterName != null) && (characterDataVal != null)) {
            characterDataVal.characterName = newUserName; //set the new userName with the writed into field
            PlayerPrefsCharacterSaver.Instance.CustomAction('S', characterDataVal); //save it

            //delay coroutine ->
            StartCoroutine(ExecuteAfterTime(0.5f, () =>
            {
                textUIComp.text = "Info Saved.";
                textNombreJugador.text = newUserName;
            }));
        }
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
