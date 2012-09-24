using UnityEngine;
using System.Collections;

public class TopDownShootingController : MonoBehaviour
{	
	public GameObject AmmoType;
	public int ShotsPerSecond = 10;
	
	public GameObject GrenadeType;
	public int ThrowsPerSecond = 1;
	
	private int bulletTimer = 60;
	private int grenadeTimer = 60;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		bulletTimer++;
		grenadeTimer++;
		CheckMouse ();
	}
	
	void CheckMouse()
	{
		/* Mouse Buttons
		 * 0 - Left
		 * 0 - Right
		 * 0 - Center
		 */
		
		if(Input.GetMouseButton(0))
		{
			if(bulletTimer >= 60/ShotsPerSecond)
			{
				bulletTimer = 0;
				Instantiate(AmmoType, transform.position, transform.rotation);
			}
		}
		else if(Input.GetMouseButton(1))
		{
			if(grenadeTimer >= 60/ThrowsPerSecond)
			{
				grenadeTimer = 0;
				Instantiate(GrenadeType, transform.position, transform.rotation);
			}
		}
	}
}
