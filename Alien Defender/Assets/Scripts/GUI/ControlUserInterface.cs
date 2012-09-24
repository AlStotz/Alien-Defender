using UnityEngine;
using System.Collections;

public class ControlUserInterface : MonoBehaviour {
	
	private Rect Rectangle;
	
	private bool isVisable = true;
	
	private string text;
	
	// Use this for initialization
	void Start ()
	{
		text = "W - Move Forward" + "\n" +
			"A - Strafe Left" + "\n" +
			"S - Move Backwards" + "\n" +
			"D - Strafe Right" + "\n\n" +
			"F - Toggle Flashlight" + "\n\n" +
			"Shift+1 - Toggle Debug GUI" + "\n" +
			"Shift+2 - Toggle ControllerGUI";
	}
	
	// Update is called once per frame
	void Update ()
	{
		Rectangle = new Rect(Screen.width - 205, 5, 200, 100);
	}
	
	void OnGUI()
	{
		if(isVisable)
			GUI.TextArea(Rectangle, text);
	}
}
