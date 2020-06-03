using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVariableClass : MonoBehaviour
{
    public int score;
    public string playerName;
    public string dificulty;
    public float timePlayed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public CustomVariableClass(int scoreInt, string nameStr, float timePlayedF)
    {
        score = scoreInt;
        name = nameStr;
        timePlayed = timePlayedF;
    }
}
