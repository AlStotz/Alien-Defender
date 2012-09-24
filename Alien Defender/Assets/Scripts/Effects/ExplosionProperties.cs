using UnityEngine;
using System.Collections;

public class ExplosionProperties : MonoBehaviour {
	
	public float LifeTime = 0.5f;
	
	private int timer = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(timer >= 60*LifeTime)
			Destroy(gameObject);
	}
}
