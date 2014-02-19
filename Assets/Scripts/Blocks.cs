using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z == 1f) {
				transform.Translate(new Vector3 (0f, 0f, 0f));
				} else {
				transform.Translate( new Vector3 (0f,0f,.5f));
				}
	}
}
