using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	//Player movement variables
	public float speed;
	public float teleCooldown =.5f;
	public float flightTime = 1f;
	private Rigidbody rb;
	private float cooldownTime=5f;
	int lane = 2;
	public Animator anim;
	public iTween.EaseType easeType;

	//UI Variables
	private int life=3;
    public Text lifeText;
    public Text winText;
	public Text score;
	private int sc=0;
    public Canvas WinScreen;
    
	//particle effects for coin interaction
	private ParticleSystem particleSilver;
    private ParticleSystem particleGold;
    public ParticleSystem collisionSilverParticlePrefab;
    public ParticleSystem collisionGoldParticlePrefab;

    void Start(){
        rb = GetComponent<Rigidbody>();
        DeclaredVariables.checkpoints = new Vector3(0, .8f, -4);

        WinScreen = WinScreen.GetComponent<Canvas>();

        WinScreen.enabled = false;
    }
		

	/// <summary>
	/// Handles controller input by player
	/// </summary>
	/// 
	void Update () {
        cooldownTime = cooldownTime + Time.deltaTime;
			if (cooldownTime < teleCooldown) {
			return;
			}	
			//S click go to front
			if (transform.position.y > -1) {
				if (Input.GetKey(KeyCode.S)) {
						if (lane ==3) {
							anim.SetBool ("Flying", true);
							lane = 2;
							transform.eulerAngles = new Vector3 (0, 180, 0);
							iTween.MoveTo (gameObject, iTween.Hash("z",-4f,"time", flightTime));
						} else if (lane==2) {
							anim.SetBool ("Flying", true);
							lane = 1;
							transform.eulerAngles = new Vector3 (0, 180, 0);
							iTween.MoveTo (gameObject, iTween.Hash("z",-7f,"time", flightTime));
						}
					StartCoroutine (EndFlight (.5f));
						cooldownTime = 0;
				//W go to back
				} else if (Input.GetKey(KeyCode.W)) {
						if (lane==1) {
							anim.SetBool ("Flying", true);
							lane = 2;
							transform.eulerAngles = new Vector3 (0, 0, 0);
							iTween.MoveTo (gameObject, iTween.Hash("z",-4f,"time", flightTime));
						} else if (lane ==2) {
							anim.SetBool ("Flying", true);
							lane = 3;
							transform.eulerAngles = new Vector3 (0, 0, 0);
							iTween.MoveTo (gameObject, iTween.Hash("z",0f,"time", flightTime));
						}
						StartCoroutine (EndFlight (.5f));
						cooldownTime = 0;
					} else {
						if (Input.GetKey(KeyCode.A)) {
							transform.eulerAngles = new Vector3(0, 270, 0);
							transform.Translate (new Vector3(0,0,1) * speed * Time.deltaTime); 
							anim.SetBool ("Moving", true);
						} else if (Input.GetKey (KeyCode.D)) {
							transform.eulerAngles = new Vector3(0, 90, 0);
							transform.Translate (new Vector3(0,0,1) * speed * Time.deltaTime); 
							anim.SetBool ("Moving", true);
						} else {
							anim.SetBool ("Moving", false);
						}
					}
		}

		//Case when you're falling
		if (transform.position.y < -13 && !(transform.position.x>=127.5f)) {
				if (life == 1) {
                life = 0;
                winText.text = "Try again?";
                WinScreen.enabled = true;
            }

                if (life > 1) {
					life--;
					rb.velocity = Vector3.zero;
                    transform.position = DeclaredVariables.checkpoints;
				lane = 2;
				}
				SetlifeText ();
		}

		//check win condiction
		if (transform.position.x>=127.5f && winText.text!="You Lost!") {
			winText.text = "You Win! Try Again?";
			WinScreen.enabled = true;
		}

	}
		

    void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup1")) {
			sc += 100;
            particleSilver = Instantiate(collisionSilverParticlePrefab, other.transform.position, Quaternion.identity) as ParticleSystem;
            particleSilver.Play();
            Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Pickup2")) {
			sc += 500;
            particleGold = Instantiate(collisionGoldParticlePrefab, other.transform.position, Quaternion.identity) as ParticleSystem;
            particleGold.Play();
            Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			life--;
			if (life < 1) {
				winText.text = "You Lost!";
				Destroy (gameObject);
				return;
			}
			SetlifeText ();
			transform.position = DeclaredVariables.checkpoints;
			lane = 2;

		}

		score.text = "Score: " + sc.ToString ();
	}

	void SetlifeText(){
		lifeText.text = "Lives: " + life.ToString ();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Detected");
            life--;
            SetlifeText();
            iTween.Stop(this.gameObject);
            iTween.Resume(this.gameObject);
            anim.SetBool("Flying", false);
			lane = 2;
            transform.position = DeclaredVariables.checkpoints;
        }
    }

    /// <summary>
    /// Coroutine to pause and then end flight animation
    /// </summary>
    IEnumerator EndFlight(float seconds){
		yield return new WaitForSeconds (seconds);
		anim.SetBool ("Moving", false);
		anim.SetBool ("Flying", false);
	}

    
}
