using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Uimanager : MonoBehaviour
{
    public static Uimanager instance;
    public GameObject gopanel;
    public GameObject hardpanel;
    public GameObject Highscorepanel;
    public GameObject gameover;
    public GameObject playtap;
    
    public Text score;
   
    public bool gameoveru;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    public void gamestart()
    {
        playtap.SetActive(false);
        gopanel.GetComponent<Animator>().Play("go");
        hardpanel.GetComponent<Animator>().Play("harrd");
        Highscorepanel.GetComponent<Animator>().Play("highscore");
        groundspwan.instance.spwngroundobj();
    }

        public void Gameover()
    {
        gameover.SetActive(true);
        gameoveru = true;
    }
    public void reset()
    {
        SceneManager.LoadScene(0);
  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
