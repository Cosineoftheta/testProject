using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (GameObject.Find ("Player").transform.position.x,
		                                  GameObject.Find ("Player").transform.position.y,/*-1.3f*/
		                                 transform.position.z);
	}
}
