using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    public static scoremanager instance;
    public int score;
    public int highscore;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        score = 0;
    }

    public void incrementscore()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
