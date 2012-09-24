using UnityEngine;
using System.Collections;

public class BulletProperties : MonoBehaviour {
	
	//public int Damage = 1;
	public int TravelSpeed = 100;
	public float LifeTime = 600;
	
	private int timer = 0;
	
	// Use this for initialization
	void Start ()
	{
		rigidbody.AddForce(transform.forward * TravelSpeed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer++;
		if(timer >= LifeTime)
		{
			Destroy(gameObject);
		}
	}
}
