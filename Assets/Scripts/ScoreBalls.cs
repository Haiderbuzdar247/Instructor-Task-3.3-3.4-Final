using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreBalls : MonoBehaviour
{
    
    
    public GameObject gameBalls;
    public GameObject healthball;

    public int startdelay ;
    public int gapdelay;

    void Start()
    {
        
        InvokeRepeating("spawnballs" , startdelay, gapdelay);
        InvokeRepeating("healthballs", 2, 4);

    }

    
    void spawnballs()
    {
        
       
            GameObject go = Instantiate(gameBalls, new Vector2(Random.Range(-9, 9), 5), transform.rotation);
            int scaleFactor = Random.Range(2, 5);
            go.transform.localScale = new Vector2(scaleFactor, scaleFactor);
        

    }
    void healthballs()
    {
        Instantiate(healthball, new Vector2(Random.Range(-9, 9), 5), transform.rotation);
    }


    



}
