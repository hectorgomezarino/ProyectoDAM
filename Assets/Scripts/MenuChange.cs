using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //para cargar el input text and labels
using UnityEngine.SceneManagement; //para poder cambiar entre escenas

public class MenuChange : MonoBehaviour
{
    public CharacterData characterDataNew;
    public InputField playername;

    // Use this for initialization
    // Start is called before the first frame update
    void Start () {

        if (GameObject.Find("NombreJugadorText") != null) //validate if object label text exists
        {
            var textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
            textNombreJugador.text = ""; //clear the text
            characterDataNew = PlayerPrefsCharacterSaver.Instance.CustomAction('L', null); //load it
            textNombreJugador.text = characterDataNew.characterName.ToString();
        }
    }

	// Update is called once per framefile:///home/hgomez/2DTestTutorialNewVersion/Assets/MenuChange.cs

	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    /*
     * Para cambiar entre escenas.
     */
    public void changeToScene (int sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void exitGame() {
        Application.Quit(); //The code will not work if you're testing it from the scene editor. 
    }


    /*test function*/
    void StartLevel1()
    {
        Debug.Log("starting game level");
        SceneManager.LoadScene(1);
    }
}
