using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioncheck : MonoBehaviour {

	public AudioSource CollisionSound;
	private int counter =4;

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider && counter >0) {
			CollisionSound.Play ();
			counter--;
		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
