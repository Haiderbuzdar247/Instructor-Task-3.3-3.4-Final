using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public TMP_Text points;
    public int score = 1;
    public TMP_Text health;
    public int life = 100;
    public AudioSource gamesound;
    public AudioClip firesound;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        points.text = score.ToString();
        health.text = life.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void audiostart()
    {
        gamesound.PlayOneShot(firesound);
    }
    public void scoreAdd()
    {
        score++;
        points.text = score.ToString();


    }
    public void healthplayer()
    {
        life -=20;
        health.text = life.ToString();
        if (life <= 0)
        {
            health.text = "GAME OVER";
        }


    }
    public void Gainhealth()
    {
        life += 20;
        health.text = life.ToString();
    }


}
