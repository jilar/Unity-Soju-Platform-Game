using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundonCollision : MonoBehaviour
{

    public AudioClip bump, coin, checkPoint;
    private AudioSource source;


    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "object")
        {
            source.PlayOneShot(bump);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pickup1" || col.gameObject.tag == "Pickup2")
        {
            source.PlayOneShot(coin);
        }

        if (col.gameObject.tag == "Checkpoint")
        {
            source.PlayOneShot(checkPoint);
        }

    }
}
