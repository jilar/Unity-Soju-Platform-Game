using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

    public float speed = 3;
    public float launchTime = 2;
    public int strength = 100;
    public int destroyCannonballSecond = 1;
    public GameObject prefab;
   // public int health = 0;
	// Use this for initialization
	void Start () {
        //Reload the cannonball for the game object to keep shooting
        //prefab = Resources.Load("CannonBall") as GameObject;
        InvokeRepeating("launchMyCannon", launchTime, speed);
	}
	
    //launches cannon
    void launchMyCannon()
    {
        //Keep generating the cannonball
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        //bullet.transform.position = transform.position + player.transform.forward;
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = this.transform.rotation;
        rigidbody.velocity = bullet.transform.forward * strength;
        rigidbody.AddForce(bullet.transform.forward * strength);
        Destroy(bullet, destroyCannonballSecond);
    }
}
