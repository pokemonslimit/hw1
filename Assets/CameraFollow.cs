using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform follow;
	public Transform left;
	public Transform right;
	//public Transform top;
	//public Transform bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = follow.position.x;
		//newPosition.y = follow.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, left.position.x, right.position.x);
		//newPosition.y = Mathf.Clamp (newPosition.y, bottom.position.y, top.position.y);
		transform.position = newPosition;
	}
}
