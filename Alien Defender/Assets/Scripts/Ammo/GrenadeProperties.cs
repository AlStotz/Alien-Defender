using UnityEngine;
using System.Collections;

public class GrenadeProperties : MonoBehaviour {
	public GameObject ExplosionType;
	
	public int Angle = 30;
	public int Power = 100;
	
	//public int MinDamage = 10;
	//public int MaxDamage = 100;
	public int Fuse = 3;
	
	private int detTimer = 0;
	
	// Use this for initialization
	void Start ()
	{
		Vector3 force = new Vector3(transform.forward.x, Angle, transform.forward.z);
		
		Debug.Log(transform.forward);
		Debug.Log(force);
		rigidbody.AddForce(force * Power);
	}
	
	// Update is called once per frame
	void Update ()
	{
		detTimer++;
		if(detTimer >= (Fuse*60))
		{
			Explode();
		}
	}
	
	void Explode()
	{
		Instantiate(ExplosionType, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
