using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para poder cambiar entre escenas

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartLevel1()
    {
        Debug.Log("starting game level");

        SceneManager.LoadScene(1);
    }
}
