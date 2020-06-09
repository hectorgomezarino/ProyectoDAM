using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CommonLibrary : MonoBehaviour
{

    public static CommonLibrary Instance = null;
    public CharacterData characterDataNew; //character data values
    private bool shieldsOngoing = true; //bool to see if there are any shields
    public int totalShields = 100;
    //GameObject.FindGameObjectsWithTag("totalShields").Length; //calculate the initial number of shields into the scene, TO DO: auto calculate
    private bool victory = false;

    // Exploded Ship Image
    public Sprite explodedShipImage;

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        totalShields = characterDataNew.totalShields;
        characterDataNew = PlayerPrefsCharacterSaver.Instance.CustomAction('L', null); //save it
        var textPlayerName = GameObject.Find("PlayerName").GetComponent<Text>();
        textPlayerName.text = characterDataNew.characterName.ToString(); //set the saved value if exists. //TO DO: this has a bug, solve id pending...

        var textAmmo = GameObject.Find("AmmoCount").GetComponent<Text>();
        textPlayerName.text = characterDataNew.Ammo.ToString(); //set the saved value if exists. //TO DO: this has a bug, solve id pending...
    }

    /*
     * @description: method called when game finish with defeat 
     * @param col: Colider 2D player object
     * 
     */
    public void GameDefeat(Collider2D col)
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion); // Play exploding ship sound
        col.GetComponent<SpriteRenderer>().sprite = explodedShipImage; // Change to exploded ship image
        CommonLibrary.Instance.ModifyTextUIScore(-100);//modify score
        CommonLibrary.Instance.ModifyFailStateText("You Lose.");
        var textUIComp = GameObject.Find("DefeatText").GetComponent<Text>();
        textUIComp.enabled = true; // enable DEFEAT text
        Destroy(col.gameObject, 0.5f); // Wait .5 seconds and then destroy Player
        Time.timeScale = 0; //Stop the play when player destroy
    }


    /*
     * @description: method to set all win parameters to 0 (nave nodriza?)
     * @param no params
     * 
     */
    public void GameWin()
    {
        var textUIComp = GameObject.Find("WinText").GetComponent<Text>();
        textUIComp.enabled = true; // enable DEFEAT text
        if (!victory) {
            CommonLibrary.Instance.ModifyWinStateText("All alliens Destroyed.");
            victory = true;
        }
        //CommonLibrary.Instance.ModifyTextUIScore(100);//modify score //TO DO: hacer solo una vez, no en bucle
    }
    /*
     * @description: count the aliens left & show it into AlienCount text.
     * 
     * 
     */
    public void ModifyTextAlienCountUIScore()
    {
        var aliens = GameObject.FindGameObjectsWithTag("Alien");
        var textAlienUIComp = GameObject.Find("AlienCount").GetComponent<Text>();
        if (aliens.Length == 0) //you win OR set the Nave Nodriza.
        {
            CommonLibrary.Instance.GameWin();
        }
        textAlienUIComp.text = aliens.Length.ToString();
    }

    /*
     * @description: set the score into score text
     * @param int toScore: int with modify number
     * 
     * 
     */
    public void ModifyTextUIScore(int toScore)
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score += toScore;
        textUIComp.text = score.ToString();
    }

    /*
     * @description: modify text FailState with the given text.
     * @param newtext String
     * 
     */
    public void ModifyFailStateText(string newText)
    {
        var textUIComp = GameObject.Find("FailStatesText").GetComponent<Text>();
        textUIComp.text = newText + "\n" + textUIComp.text; //concat the new text with existing text
    }

    /*
     * @description: modify text WinState with the given text.
     * @param newtext String
     * 
     */
    public void ModifyWinStateText(string newText)
    {
        var textUIComp = GameObject.Find("WinStatesText").GetComponent<Text>();
        textUIComp.text = newText + "\n" + textUIComp.text;
    }

    /*
     * @description: modify shields text & add a % char.
     * @param newtext String
     * 
     */
    public void ModifyShieldsPercent(string newText)
    {
        var textUIComp = GameObject.Find("ShieldsCount").GetComponent<Text>();
        textUIComp.text = newText + "%"; //TO DO: este texto se muestra demasiado grande.
    }

    /*
     * @description: some actions when shields are shoted: destroy it, show failState Text, Modify Score.
     * @param String newtext: to show into FailState Text.
     * @param int toScore: int with modify number
     * 
     */
    public void ShieldsDamaged(string newText, int toScore)
    {
        CommonLibrary.Instance.ModifyTextUIScore(toScore); //modify score
        CommonLibrary.Instance.ModifyFailStateText(newText); //modify text
    }


    /*
     * @description: count the shields remain & show it...
     */
    public void CountShields()
    {
        int currentShields = GameObject.FindGameObjectsWithTag("Shield").Length; //count shields
        int percentShields = 0;
        if (totalShields>0)
            percentShields = (currentShields * 100) / totalShields;

        if (currentShields == 0 && shieldsOngoing) //set the text: no shields
        {
            CommonLibrary.Instance.ModifyFailStateText("NO shields!"); //modify text
            CommonLibrary.Instance.ModifyShieldsPercent(percentShields.ToString()); //modify text
            shieldsOngoing = false; //hace que no se vuelva a entrar en este pedazo de código
        }
        else
        {
            if (shieldsOngoing) //mientras queden escudos siempre entrará aquí.
                CommonLibrary.Instance.ModifyShieldsPercent(percentShields.ToString()); //modify text
        }
    }

}
