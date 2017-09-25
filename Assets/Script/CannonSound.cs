using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonSound : MonoBehaviour
{

    public AudioClip hit;
    private AudioSource source;


    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            source.PlayOneShot(hit);
        }

    }

}
