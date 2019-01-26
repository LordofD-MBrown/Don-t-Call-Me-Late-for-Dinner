using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public int dadHealth = 3;
    public int sonHealth = 1;
    public int momHealth = 2;

    private bool dadIsHome;
    private bool momIsHome;
    private bool sonIsHome;

    public float time = 300;

    //Getters
    //===========================================
    public int GetDadHealth()
    {
        return dadHealth;
    }
    public int GetMomHealth()
    {
        return momHealth;
    }
    public int GetSonHealth()
    {
        return sonHealth;
    }
    public bool GetDadisHome()
    {
        return dadIsHome;
    }
    public bool GetMomisHome()
    {
        return momIsHome;
    }
    public bool GetSonisHome()
    {
        return sonIsHome;
    }
    public float GetTime()
    {
        return time;
    }

    //Setters
    //===========================================
    public void SetDadHealth(int health)
    {
        dadHealth = health;
    }
    public void SetMomHealth(int health)
    {
        momHealth = health;
    }
    public void SetSonHealth(int health)
    {
        sonHealth = health;
    }
    public void SetDadIsHome(bool isHome)
    {
        dadIsHome = isHome;
    }
    public void SetMomIsHome(bool isHome)
    {
        momIsHome = isHome;
    }
    public void SetSonIsHome(bool isHome)
    {
        sonIsHome = isHome;
    }
    public void SetTime(float t_time)
    {
        time = t_time;
    }

    public void TimeTick()
    {
        time--;
    }
}
