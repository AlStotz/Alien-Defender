using UnityEngine;
using System.Collections;

public class DebugUserInterface : MonoBehaviour {
	
	private Rect DebugToolbarRect;
	private Rect DebugWindowRect;
	
	private bool isVisable = false;
	private bool isDropDown = false;
	
	public GameObject Enemy, Player;
	
	private string line1, line2, line3;
	
	// Use this for initialization
	void Start ()
	{
		DebugToolbarRect = new Rect(5, 5, Screen.width/4, Screen.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Input.GetKeyUp(KeyCode.F1))
			if(isVisable)
				isVisable = false;
			else
				isVisable = true;
		UpdateStrings();
		
	}
	
	void UpdateStrings()
	{
	}
	
	void OnGUI()
	{
		if(isVisable)
		{
			GUILayout.BeginArea(DebugToolbarRect);
			
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("Debug"))
				if(isDropDown)
					isDropDown = false;
				else
					isDropDown = true;
			GUILayout.EndHorizontal();
			
			if(isDropDown)
			{
				//GUILayout.Window(0, 
			}
			
			GUILayout.EndArea();
		}
	}
}
