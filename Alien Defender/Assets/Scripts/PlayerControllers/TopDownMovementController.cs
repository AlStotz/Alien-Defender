using UnityEngine;
using System.Collections;

public class TopDownMovementController : MonoBehaviour {
	
	public GameObject PlayerCamera;
	public GameObject CursorObject;
	
	public enum RotationType { None = 0, Strafe = 1}
	public RotationType rType = RotationType.None;
	
	public float PlayerWalkSpeed = 1;
	
	public bool RotationSpeedOn = true;
	public float PlayerRotationSpeed = 5f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckKeys();
		CheckMouse();
	}
	
	void CheckMouse()
	{
		Plane pPlane;
		Ray ray = PlayerCamera.camera.ScreenPointToRay(Input.mousePosition);
		float hitDistance = 0.0f;
		
		
		pPlane = new Plane(Vector3.up, transform.position);
		if(pPlane.Raycast(ray, out hitDistance))
		{
			Vector3 targetPoint = ray.GetPoint(hitDistance);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			
			if(RotationSpeedOn)
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerRotationSpeed * Time.deltaTime); // Speed
			else
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1); // No Speed
		}
	}
	
	void CheckKeys()
	{
		if(Input.GetKey(KeyCode.W)) // W: Walk Forward
			WalkForward();
		if(Input.GetKey(KeyCode.S)) // S: Backward
			WalkBackward();
		if(Input.GetKey(KeyCode.D)) // D: Right
			WalkRight();
		if(Input.GetKey(KeyCode.A)) // A: Left
			WalkLeft();
		
	}
	
	void WalkForward()
	{
		if(rType == RotationType.None)
		{
			transform.position += new Vector3(0,0,PlayerWalkSpeed/10);
		}
		else if(rType == RotationType.Strafe)
		{
			transform.position += (transform.forward * PlayerWalkSpeed) / 10;
		}
	}
	void WalkBackward()
	{
		if(rType == RotationType.None)
		{
			transform.position -= new Vector3(0,0,PlayerWalkSpeed/10);
		}
		else if(rType == RotationType.Strafe)
		{
			transform.position -= (transform.forward * PlayerWalkSpeed) / 10;
		}
	}
	void WalkRight()
	{
		if(rType == RotationType.None)
		{
			transform.position += new Vector3(PlayerWalkSpeed/10,0,0);
		}
		else if(rType == RotationType.Strafe)
		{
			transform.position += (transform.right * PlayerWalkSpeed) / 10;
		}
	}
	void WalkLeft()
	{
		if(rType == RotationType.None)
		{
			transform.position -= new Vector3(PlayerWalkSpeed/10,0,0);
		}
		else if(rType == RotationType.Strafe)
		{
			transform.position -= (transform.right * PlayerWalkSpeed) / 10;
		}
	}
}



/* Other Version for CheckKeys... takes in the fact of walking/straffing speed... */
/*
 * void CheckKeys()
	{
		//Walking
		if(Input.GetKey(KeyCode.W)) // Forward
		{
			_isWalking = true;
			
			if(_isStraffing)
				transform.position += (transform.forward * PlayerWalkSpeed) / 20;
			else
				transform.position += (transform.forward * PlayerWalkSpeed) / 10;
		}
		else
		{
			_isWalking = false;
		}
		
		if(Input.GetKey(KeyCode.S)) // Backward
		{
			_isWalking = true;
			if(_isStraffing)
				transform.position -= (transform.forward * PlayerWalkSpeed) / 20;
			else
				transform.position -= (transform.forward * PlayerWalkSpeed) / 10;
		}
		else
		{
			_isWalking = false;
		}
		
		//Straffing or Orbiting
		if(Input.GetKey(KeyCode.D)) // Right
		{
			_isStraffing = true;
			if(rType == RotationType.Strafe)
			{
				if(_isWalking)
					transform.position += (transform.right * PlayerWalkSpeed) / 10;
				else
					transform.position += (transform.right * PlayerWalkSpeed) / 20;
			}
			else if (rType == RotationType.Orbit)
			{
				if(_isWalking)
					transform.RotateAround(CursorObject.transform.position, new Vector3(0,-1,0), PlayerWalkSpeed);
				else
					transform.RotateAround(CursorObject.transform.position, new Vector3(0,-1,0), PlayerWalkSpeed/2);
			}
		}
		else
		{
			_isStraffing = false;
		}
		
		if(Input.GetKey(KeyCode.A)) // Left
		{
			_isStraffing = true;
			if(rType == RotationType.Strafe)
			{
				if(_isWalking)
					transform.position -= (transform.right * PlayerWalkSpeed) / 10;
				else
					transform.position -= (transform.right * PlayerWalkSpeed) / 20;
			}
			else if (rType == RotationType.Orbit)
			{
				if(_isWalking)
					transform.RotateAround(CursorObject.transform.position, new Vector3(0,1,0), PlayerWalkSpeed);
				else
					transform.RotateAround(CursorObject.transform.position, new Vector3(0,1,0), PlayerWalkSpeed/2);
			}
		}
		else
		{
			_isStraffing = false;
		}
		
		if(Input.GetKeyUp(KeyCode.P))
		{
			
		}
	}*/