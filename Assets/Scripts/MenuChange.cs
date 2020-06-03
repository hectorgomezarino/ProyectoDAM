using UnityEngine;
using UnityEngine.UI; //para cargar el input text and labels
using UnityEngine.SceneManagement; //para poder cambiar entre escenas

public class MenuChange : MonoBehaviour
{
    public CharacterData characterDataVal;

    // Use this for initialization
    // Start is called before the first frame update
    void Start () {
        if (GameObject.Find("NombreJugadorText") != null) //validate if object label text exists
        {
            Text textNombreJugador = GameObject.Find("NombreJugadorText").GetComponent<Text>();
            textNombreJugador.text = ""; //clear the text
            //characterDataVal = PlayerPrefsCharacterSaver.Instance.CustomAction('L', null); //load it
            //TODO: usar el método de arriba para recoger el nombre del jugador, es mucho más elegante.
            var characterName = PlayerPrefs.GetString("characterName_CharacterSlot" + 0);
            textNombreJugador.text = characterDataVal.characterName;
        }
    }

	// Update is called once per framefile:///home/hgomez/2DTestTutorialNewVersion/Assets/MenuChange.cs
	void Update () {
        if (Input.GetKey("escape"))
        {
            ExitGame();
        }
    }


    /*
     * Para cambiar entre escenas.
     * @int, el nº de escena al que cambiar.   
     */
    public void ChangeToScene(int sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void ExitGame() {
        Application.Quit(); //The code will not work if you're testing it from the scene editor. 
    }

}
