using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondrotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.one * 20 * Time.deltaTime);

    }
}
