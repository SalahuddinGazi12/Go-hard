using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundspwan : MonoBehaviour
{
    public static groundspwan instance;
    public GameObject ground;
    Vector3 lastpos;
    float size;
    public bool gameover;
    public GameObject diamond;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        lastpos = ground.transform.position;
        size = ground.transform.localScale.x;
        for (int i = 0; i < 20; i++)
        {
            spwanground();

        }
    }
    public void spwngroundobj()
    {

        InvokeRepeating("spwanground", 2f, 0.2f);
    }


    // Update is called once per frame
    void Update()
    {
 
        if (Uimanager.instance.gameoveru == true)
        {
            CancelInvoke("spwanground");
        }
    }

    void spwanground(){

        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }
    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(ground, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(ground, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
        }
    }
}
