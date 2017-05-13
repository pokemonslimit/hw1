using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetDamage : MonoBehaviour {

	public int hp=1;
	public Sprite damagePicture;
	public float damageMinSpeed;
	public AudioSource KillSound;

	private int currenthp;
	private float damageMinSpeedsqr;
	private SpriteRenderer spriteRenderer01;

	void Start()
	{
		spriteRenderer01 = GetComponent<SpriteRenderer> ();
		currenthp = hp;
		damageMinSpeedsqr = damageMinSpeed * damageMinSpeed;
	}

	void Update(){
	}

	void OnCollisionEnter2D(Collision2D collision){
	
		if (collision.collider.tag != "Damager") {
			return;
		}
		if (collision.relativeVelocity.sqrMagnitude < damageMinSpeedsqr) {
			return;
		}

		spriteRenderer01.sprite = damagePicture;
		currenthp=currenthp-1;

		if (currenthp <= 0) {
			Kill ();
			KillSound.Play ();
		}

	}

	void Kill()
	{
		spriteRenderer01.enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<ParticleSystem> ().Play();

	}


}
