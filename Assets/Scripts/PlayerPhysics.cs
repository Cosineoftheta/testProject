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
	public void Rotate(Vector3 vRot)
	{
		transform.Rotate (vRot);
	}
	void Update()
	{
		if (transform.position.z >  1.4f) 
		{
			rigidbody.position = new Vector3(5f,.5f,-.66f);
		}
	}


}
