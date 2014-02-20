using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	public float fSpeed = .5f;
	public float fAcc = 5;
	private float fCurrentSpeed_X;
	private float fTargetSpeed_X;
	private float fCurrentSpeed_Y;
	private float fTargetSpeed_Y;
	private float fCurrentSpeed_Z;
	private float fTargetSpeed_Z;
	private Vector3 vMove;
	private bool bPlayerRotateFlag = false;
	private float fMouseX_Start = 0;
	private float fMouseY_Start = 0;
	private PlayerPhysics PlayerPhysics;
	// Use this for initialization
	void Start () {
		PlayerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void Update () {
		fTargetSpeed_X = Input.GetAxisRaw ("Horizontal") * fSpeed;
		fCurrentSpeed_X = IncrementTowards (fCurrentSpeed_X, fTargetSpeed_X, fAcc);
		fTargetSpeed_Y = Input.GetAxisRaw ("Vertical") * fSpeed;
		fCurrentSpeed_Y = IncrementTowards (fCurrentSpeed_Y, fTargetSpeed_Y, fAcc);

		if(Input.GetButtonDown("Jump"))
		{
			fTargetSpeed_Z = Input.GetAxisRaw ("Jump") * -0.1f;
			Invoke("StopJump",.1f);
		}
		vMove = new Vector3 (fCurrentSpeed_X, fCurrentSpeed_Y, fTargetSpeed_Z);
		PlayerPhysics.Move (vMove);

		Vector3 v3MousePos = Input.mousePosition;
		v3MousePos.x -= (Screen.width 	* 0.5f);
		v3MousePos.y -= (Screen.height 	* 0.5f);
		float fMouseAngle = Mathf.Abs(Mathf.Abs(((Mathf.Atan(v3MousePos.y/v3MousePos.x)*180f)/Mathf.PI))-90f);
		float fCurrentAngle = transform.GetChild (1).localEulerAngles.z;
		if (v3MousePos.x >= 0 & v3MousePos.y >= 0 ) 
		{
			fMouseAngle = 360f - fMouseAngle;
		}
		else if(v3MousePos.x <= 0 & v3MousePos.y >= 0 )
		{
			fMouseAngle = 360f + fMouseAngle;
		}
		else if(v3MousePos.x <= 0 & v3MousePos.y <= 0 )
		{
			fMouseAngle = 360f + ((90f-fMouseAngle)+90f);
		}
		else
		{
			fMouseAngle = 360f - (90f-fMouseAngle)-90f;
		}
		transform.GetChild(1).Rotate(0,0,fMouseAngle-fCurrentAngle, Space.World);

			
	}
	
	private void StopJump()
	{	
				fTargetSpeed_Z = 0;
	}
	private float IncrementTowards(float n, float target, float a){
		if (n == target) {
			return n;
		} 
		else {
			float dir = Mathf.Sign (target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target-n))?n:target;
		}
	}
}
