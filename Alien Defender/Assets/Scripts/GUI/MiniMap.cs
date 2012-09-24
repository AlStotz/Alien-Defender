using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	
	public Texture MapOverview; // Text of the entire map overview
	
	public enum vLocation {Top, Center, Bottom};
	public enum hLocation {Left, Center, Right};
	
	public vLocation VerticalLocation = vLocation.Top;     // Vertical Location of the MiniMap
	public hLocation HorizontalLocation = hLocation.Right; // Horizontal Location of the MiniMap
	public float vPadding = 10; // Vertical Padding
	public float hPadding = 10; // Horizontal Padding
	public float MapSize = 200; // Map Size
	
	private Rect MapRect;
	private float MapWidth, MapHeight;
	private float MapX, MapY;
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log(MapOverview.width);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateMap ();
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(MapRect, MapOverview);
	}
	
	void UpdateMap()
	{
		// Set the Map Width/Height
		MapWidth = MapSize;
		MapHeight = MapSize;
		
		// Horizontal Keyboard Location
		if(HorizontalLocation == hLocation.Left)
		{
			MapX = 0;
			MapX += hPadding;
		}
		else if(HorizontalLocation == hLocation.Center)
		{
			MapX = ((Screen.width / 2) - MapWidth);
		}
		else if(HorizontalLocation == hLocation.Right)
		{
			MapX = (Screen.width - MapWidth);
			MapX -= hPadding;
		}
		
		// Vertical Keyboard Location
		if(VerticalLocation == vLocation.Top)
		{
			MapY = 0;
			MapY += vPadding;
		}
		else if(VerticalLocation == vLocation.Center)
		{
			MapY = ((Screen.height / 2) - MapHeight);
		}
		else if(VerticalLocation == vLocation.Bottom)
		{
			MapY = (Screen.height - MapHeight);
			MapY += vPadding;
		}
		
		// Set the Map Rectangle
		MapRect = new Rect(MapX, MapY, MapWidth, MapHeight);
	}
}
