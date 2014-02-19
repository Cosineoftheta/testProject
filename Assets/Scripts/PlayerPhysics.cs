using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	void Awake()
	{
		Physics.gravity = new Vector3 (0f, 0f, 9.81f);
	}
	public void Move(Vector3 vMove)
	{
		transform.Translate (vMove);
	}
	void Update()
	{
		if (transform.position.z >  10f) 
		{
			rigidbody.position = new Vector3(0f,-3f,-.5f);
		}
	}


}
