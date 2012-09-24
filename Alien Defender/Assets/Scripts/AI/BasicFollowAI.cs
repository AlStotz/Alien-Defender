using UnityEngine;
using System.Collections;

public class BasicFollowAI : MonoBehaviour {
	
	//public GameObject Target;
	
	//private float targetDistance;
	private Texture tex;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		CalculateTargetDistance();
	}
	
	void CalculateTargetDistance()
	{
		//targetDistance = Vector3.Distance(transform.position, Target.transform.position);
	}
}
