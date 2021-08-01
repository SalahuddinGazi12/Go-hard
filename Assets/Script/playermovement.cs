using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovement : MonoBehaviour
{
    [SerializeField]
    private float speed ;
    Rigidbody rb;
    bool started;
    bool gameover;
    public GameObject particlesystem;
    int score;
    int highscore;
   public Text mainscoretext;
    public Text highscore1;
    

    public GameObject mainscore;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
      
        score = 0;
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                Uimanager.instance.gamestart();
                mainscore.GetComponent<Animator>().Play("mainscorepanel");
                
            }
            
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<camerafollow>().gameOver = true;
            Uimanager.instance.Gameover();
            mainscore.GetComponent<Animator>().Play("gouppanel");
         
        }

        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            switchdirection();
        }


        Uimanager.instance.score.text = "" + score;
        mainscoretext.text = "Score: " + score;
        highscore1.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");

    }

    void switchdirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);

        }else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Diamond")
        {
            score += 1;
           GameObject part =  Instantiate(particlesystem, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(part, 1f);
            score += 1;

            if (score> PlayerPrefs.GetInt("HighScore")){
              PlayerPrefs.SetInt("HighScore",score);
            }

        }
    }
}
