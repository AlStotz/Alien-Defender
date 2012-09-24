using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	
	private Vector3 mousePos;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get Mouse Coordinates rlative to (0,0,0)
		Plane zeroPlane = new Plane( Vector3.up, Vector3.zero );
    	Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		float distance;
		
		if( zeroPlane.Raycast( ray, out distance ) )
		{
			mousePos = ray.origin + ray.direction * distance;
		}
		
		// Set the Cursor to the mouse position
		transform.position = mousePos;
		
	}
}
