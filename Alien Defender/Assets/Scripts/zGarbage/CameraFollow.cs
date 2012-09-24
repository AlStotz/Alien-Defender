using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject de;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set(de.transform.position.x, 20, de.transform.position.z);
	}
}
