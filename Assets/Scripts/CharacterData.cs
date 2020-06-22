using System;

[Serializable]

public class CharacterData
{
    public string characterName; //Player Name
    public float power;
    public int Ammo = 200;
    public int totalShields = 100;

    public int score = 0;

    public string dificulty;
    public float timePlayed;
}