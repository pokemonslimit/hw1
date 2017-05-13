using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resetter : MonoBehaviour {

	public Rigidbody2D GameObj;
	public float resetSpeed = 0.05f;
	public SpringJoint2D spring;
	public GameObject Gameover;
	public Rigidbody2D Target;
	public static int counter=2;

	// Use this for initialization
	void Start () {
		spring = GameObj.GetComponent<SpringJoint2D> ();
		Target = GetComponent<Rigidbody2D> (); 
		Gameover.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (spring == null && GameObj.velocity.sqrMagnitude < 0.025) {
			StartCoroutine (WaitAndReset ());
		}

		if (Input.GetKey (KeyCode.A)) {
			counter = 2;
			Application.LoadLevel (0);
		}


	}

	void OnTriggerExit2D (Collider2D other){
		if (other.GetComponent<Rigidbody2D> () == GameObj) {
		
			StartCoroutine (WaitAndReset ());
		}
		else{
			//yield return new WaitForSeconds (3);
				Application.LoadLevel (1);
				counter = 2;
		}
	
	}

	IEnumerator WaitAndReset ()
	{
		//counter--;
		if (counter <= 0) {
			print ("game over !!");
			//yield return new WaitForSeconds (999);
			Application.LoadLevel (2);
		}
		yield return new WaitForSeconds (1);
		Application.LoadLevel (Application.loadedLevel);
		counter--;
	}


}
