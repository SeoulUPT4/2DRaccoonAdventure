using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCreate : MonoBehaviour
{
    public GameObject bullet;
    float t = 0;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > 5.0f)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            t = 0;
        }
    }
}
