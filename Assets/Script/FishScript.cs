using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    public float height = 100;
    private float spinspeed = 5;
    public GameObject fish;
    public int strength = 10;
    Rigidbody ridigbody;


    void Start()
    {
        StartCoroutine(jump());
        StartCoroutine(forward());
    }

    IEnumerator jump()
    {
        while(true)
        {
            Rigidbody rigidbody = fish.GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(0, 2 * height, 0);
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator forward()
    {
        while (true)
        {
            Rigidbody rigidbody = fish.GetComponent<Rigidbody>();
            rigidbody.velocity = fish.transform.forward * strength;
            yield return new WaitForSeconds(3);
        }
    }
    void Update()
    {
        //Jumping
        Rigidbody rigidbody = fish.GetComponent<Rigidbody>();
        transform.Rotate(Vector3.up * (Time.deltaTime*5*strength));
    }
}
