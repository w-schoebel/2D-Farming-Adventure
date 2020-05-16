using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character 
{
    public int id;
    public string name;
    public int life;
    public int armor;
    public int endurance;
    //Sprite als string einsetzen
    public string look;
    public string home;

    public Character(int id, string name, int life, int armor, int endurance, string look, string home)
    {

    }
}
