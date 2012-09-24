using UnityEngine;
using System.Collections;

/*
 * GUI KeyboardLayout
 *     - Graphical User Interface using GUILayout to play a dropdown keyboard layout to visual see the current keys being pressed.
 */

public class KeyboardLayout : MonoBehaviour {
	
	/* Settings */
	public GUISkin guiSkin; // Custom GUI Skin for boxs and such
	public enum keyboardH {Left, Center, Right};
	public enum keyboardV {Top, Center, Bottom};

	/* Toolbar */
	//private Rect ToolbarRect;  // Where to draw the Toolbar
	//private float hMargin = 5; // Defaul Horizontal Margin for the Toolbar
	//private float vMargin = 5; // Defaul Vertical Margin for the Toolbar
	
	/* Keyboard */
	public bool isKeyboardVisible = false;
	public float KeySize = 32;
	public keyboardH HorizontalLocation = keyboardH.Center;
	public keyboardV VerticalLocation = keyboardV.Bottom;
	
	private Rect keyboardRect;    // Where to draw the Keyboard Layout
	private Rect secondaryRect;
	private float keyboardWidth;  // Keyboard Layout Width
	private float keyboardHeight; // Keyboard Layout Height
	private float keyboardX;      // Keyboard Layout X Position
	private float keyboardY;      // Keyboard Layout Y Position
	private float SpacerSize;     //private float SpacerSize = 16;
	
	/* Mouse */
	private Rect mouseRect;    // Where to draw the Mouse Layout
	private float mouseWidth;  // Mouse Layout Width
	private float mouseHeight; // Mouse Layout Height
	private float mouseX;      // Mouse Layout X Position
	private float mouseY;      // Mouse Layout Y Position
	
	/* Mouse Cursor */
	private Rect mouseView; 
	private Rect mCursorRect;
	private float mCursorWidth = 15;
	private float mCursorHeight = 15;
	private float mPosX, mPosY;
	public GameObject mouseCursor;
	public Texture mouseCursorTexture;
	
	// Use this for initialization
	void Start ()
	{
		GetMousePosition();
		//SetupToolbar();
		SetupKeyboard();
	}
	
	void GetMousePosition()
	{
		
	}
	
	void SetupKeyboard()
	{		
		// SpacerSize of the 'halfkeys'
		SpacerSize = KeySize / 2; // Spacer Size is half the width of the standard key size
		
		// Width/Height of the entire keyboard
		keyboardWidth = (KeySize * 24f);
		keyboardHeight = (KeySize * 7.5f);
		mouseWidth = (KeySize * 5);
		mouseHeight = (KeySize * 6);
		
		// Horizontal Keyboard Location
		if(HorizontalLocation == keyboardH.Left)
		{
			keyboardX = 0;
		}
		else if(HorizontalLocation == keyboardH.Center)
		{
			keyboardX = (Screen.width - (keyboardWidth + mouseWidth)) / 2;
		}
		else if(HorizontalLocation == keyboardH.Right)
		{
			keyboardX = (Screen.width - (keyboardWidth + mouseWidth));
		}
		mouseX = (keyboardX + keyboardWidth);
		
		// Vertical Keyboard Location
		if(VerticalLocation == keyboardV.Top)
		{
			keyboardY = 0;
		}
		else if(VerticalLocation == keyboardV.Center)
		{
			keyboardY = (Screen.height - (keyboardHeight + mouseWidth)) / 2;
		}
		else if(VerticalLocation == keyboardV.Bottom)
		{
			keyboardY = (Screen.height - (keyboardHeight));
		}
		mouseY = (keyboardY + (KeySize*1.25f));
		
		// Keyboard Rectangle
		keyboardRect = new Rect(keyboardX, keyboardY, keyboardWidth, keyboardHeight);
		// Secondary Rectangle for Vertical Keys ('keypadplus' and 'keypadenter')
		secondaryRect = new Rect(keyboardX + (keyboardWidth - (KeySize * 1.5f)), keyboardY + (keyboardHeight - (KeySize * 4.5f)), KeySize, KeySize*4f);
		
		// MouseRect Rectangle
		mouseRect = new Rect(mouseX, mouseY, mouseWidth, mouseHeight);
		mouseView = new Rect((mouseX + SpacerSize), (mouseY + SpacerSize), (mouseWidth - (SpacerSize*2)), (mouseHeight - (KeySize + SpacerSize*2)));
		
		float sX = Camera.main.WorldToScreenPoint(mouseCursor.transform.position).x;
		float sY = Screen.height + (-Camera.main.WorldToScreenPoint(mouseCursor.transform.position).y);
		
		mPosX = ((sX / Screen.width) * mouseView.width);
		mPosY = ((sY / Screen.height) * mouseView.height);
		
		mCursorRect = new Rect(mPosX - (mCursorWidth/2), mPosY- (mCursorHeight/2), mCursorWidth, mCursorHeight);
	}
	
	// Update is called once per frame
	void Update ()
	{
		SetupKeyboard ();
		
		if(Input.GetKeyUp(KeyCode.F12))
			if(isKeyboardVisible)
				isKeyboardVisible = false;
			else
				isKeyboardVisible = true;
	}
	
	void Draw(string key)
	{		
		switch(key)
		{
			/* Alpha */
			case "a":
				if(Input.GetKey(KeyCode.A))
					GUILayout.Toggle(true, "A", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "A", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "b":
				if(Input.GetKey(KeyCode.B))
					GUILayout.Toggle(true, "B", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "B", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "c":
				if(Input.GetKey(KeyCode.C))
					GUILayout.Toggle(true, "C", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "C", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "d":
				if(Input.GetKey(KeyCode.D))
					GUILayout.Toggle(true, "D", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "D", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "e":
				if(Input.GetKey(KeyCode.E))
					GUILayout.Toggle(true, "E", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "E", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "f":
				if(Input.GetKey(KeyCode.F))
					GUILayout.Toggle(true, "F", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "g":
				if(Input.GetKey(KeyCode.G))
					GUILayout.Toggle(true, "G", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "G", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "h":
				if(Input.GetKey(KeyCode.H))
					GUILayout.Toggle(true, "H", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "H", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "i":
				if(Input.GetKey(KeyCode.I))
					GUILayout.Toggle(true, "I", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "I", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "j":
				if(Input.GetKey(KeyCode.J))
					GUILayout.Toggle(true, "J", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "J", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "k":
				if(Input.GetKey(KeyCode.K))
					GUILayout.Toggle(true, "K", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "K", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "l":
				if(Input.GetKey(KeyCode.L))
					GUILayout.Toggle(true, "L", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "L", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "m":
				if(Input.GetKey(KeyCode.M))
					GUILayout.Toggle(true, "M", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "M", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "n":
				if(Input.GetKey(KeyCode.N))
					GUILayout.Toggle(true, "N", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "N", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "o":
				if(Input.GetKey(KeyCode.O))
					GUILayout.Toggle(true, "O", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "O", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "p":
				if(Input.GetKey(KeyCode.P))
					GUILayout.Toggle(true, "P", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "P", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "q":
				if(Input.GetKey(KeyCode.Q))
					GUILayout.Toggle(true, "Q", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Q", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "r":
				if(Input.GetKey(KeyCode.R))
					GUILayout.Toggle(true, "R", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "R", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "s":
				if(Input.GetKey(KeyCode.S))
					GUILayout.Toggle(true, "S", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "S", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "t":
				if(Input.GetKey(KeyCode.T))
					GUILayout.Toggle(true, "T", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "T", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "u":
				if(Input.GetKey(KeyCode.U))
					GUILayout.Toggle(true, "U", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "U", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "v":
				if(Input.GetKey(KeyCode.V))
					GUILayout.Toggle(true, "V", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "V", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "w":
				if(Input.GetKey(KeyCode.W))
					GUILayout.Toggle(true, "W", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "W", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "x":
				if(Input.GetKey(KeyCode.X))
					GUILayout.Toggle(true, "X", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "X", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "y":
				if(Input.GetKey(KeyCode.Y))
					GUILayout.Toggle(true, "Y", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Y", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "z":
				if(Input.GetKey(KeyCode.Z))
					GUILayout.Toggle(true, "Z", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Z", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			
			/* Numeric */
			case "1":
				if(Input.GetKey(KeyCode.Alpha1))
					GUILayout.Toggle(true, "1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "2":
				if(Input.GetKey(KeyCode.Alpha2))
					GUILayout.Toggle(true, "2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "3":
				if(Input.GetKey(KeyCode.Alpha3))
					GUILayout.Toggle(true, "3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "4":
				if(Input.GetKey(KeyCode.Alpha4))
					GUILayout.Toggle(true, "4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "5":
				if(Input.GetKey(KeyCode.Alpha5))
					GUILayout.Toggle(true, "5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "6":
				if(Input.GetKey(KeyCode.Alpha6))
					GUILayout.Toggle(true, "6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "7":
				if(Input.GetKey(KeyCode.Alpha7))
					GUILayout.Toggle(true, "7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "8":
				if(Input.GetKey(KeyCode.Alpha8))
					GUILayout.Toggle(true, "8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "9":
				if(Input.GetKey(KeyCode.Alpha9))
					GUILayout.Toggle(true, "9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "0":
				if(Input.GetKey(KeyCode.Alpha0))
					GUILayout.Toggle(true, "0", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "0", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			
			/* Function Keys */
			case "esc":
				if(Input.GetKey(KeyCode.Escape))
					GUILayout.Toggle(true, "Esc", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Esc", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F1":
				if(Input.GetKey(KeyCode.F1))
					GUILayout.Toggle(true, "F1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F2":
				if(Input.GetKey(KeyCode.F2))
					GUILayout.Toggle(true, "F2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F3":
				if(Input.GetKey(KeyCode.F3))
					GUILayout.Toggle(true, "F3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F4":
				if(Input.GetKey(KeyCode.F4))
					GUILayout.Toggle(true, "F4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F5":
				if(Input.GetKey(KeyCode.F5))
					GUILayout.Toggle(true, "F5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F6":
				if(Input.GetKey(KeyCode.F6))
					GUILayout.Toggle(true, "F6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F7":
				if(Input.GetKey(KeyCode.F7))
					GUILayout.Toggle(true, "F7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F8":
				if(Input.GetKey(KeyCode.F8))
					GUILayout.Toggle(true, "F8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F9":
				if(Input.GetKey(KeyCode.F9))
					GUILayout.Toggle(true, "F9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F10":
				if(Input.GetKey(KeyCode.F10))
					GUILayout.Toggle(true, "F10", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F10", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F11":
				if(Input.GetKey(KeyCode.F11))
					GUILayout.Toggle(true, "F11", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F11", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "F12":
				if(Input.GetKey(KeyCode.F12))
					GUILayout.Toggle(true, "F12", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "F12", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			
			/* Between Button */
			case "printscreen":
				if(Input.GetKey(KeyCode.Print))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "scrolllock":
				if(Input.GetKey(KeyCode.ScrollLock))
					GUILayout.Toggle(true, "Scroll\nLock", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Scroll\nLock", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "pause":
				if(Input.GetKey(KeyCode.Pause))
					GUILayout.Toggle(true, "Pause\nBreak", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Pause\nBreak", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "insert":
				if(Input.GetKey(KeyCode.Insert))
					GUILayout.Toggle(true, "Ins", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Ins", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "home":
				if(Input.GetKey(KeyCode.Home))
					GUILayout.Toggle(true, "Home", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Home", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "pageup":
				if(Input.GetKey(KeyCode.PageUp))
					GUILayout.Toggle(true, "Page\nUp", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Page\nUp", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "delete":
				if(Input.GetKey(KeyCode.Delete))
					GUILayout.Toggle(true, "Del", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Del", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "end":
				if(Input.GetKey(KeyCode.End))
					GUILayout.Toggle(true, "End", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "End", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "pagedown":
				if(Input.GetKey(KeyCode.PageDown))
					GUILayout.Toggle(true, "Page\nDown", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Page\nDown", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "uparrow":
				if(Input.GetKey(KeyCode.UpArrow))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "leftarrow":
				if(Input.GetKey(KeyCode.LeftArrow))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "downarrow":
				if(Input.GetKey(KeyCode.DownArrow))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "rightarrow":
				if(Input.GetKey(KeyCode.RightArrow))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			
			/* Main Other */
			case "backquote":
				if(Input.GetKey(KeyCode.BackQuote))
					GUILayout.Toggle(true, "`", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "`", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "tab":
				if(Input.GetKey(KeyCode.Tab))
					GUILayout.Toggle(true, "Tab", "Button", GUILayout.Width(KeySize*1.5f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Tab", "Button", GUILayout.Width(KeySize*1.5f), GUILayout.Height(KeySize)); //
				break;
			case "capslock":
				if(Input.GetKey(KeyCode.CapsLock))
					GUILayout.Toggle(true, "Caps\nLock", "Button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize)); // 
				else
					GUILayout.Toggle(false, "Caps\nLock", "Button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize)); // 
				break;
			case "leftshift":
				if(Input.GetKey(KeyCode.LeftShift))
					GUILayout.Toggle(true, "Shift", "Button", GUILayout.Width(KeySize*2.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Shift", "Button", GUILayout.Width(KeySize*2.25f), GUILayout.Height(KeySize)); //
				break;
			case "leftcontrol":
				if(Input.GetKey(KeyCode.LeftControl))
					GUILayout.Toggle(true, "Ctrl", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Ctrl", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "leftwindows":
				if(Input.GetKey(KeyCode.LeftWindows))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "leftalt":
				if(Input.GetKey(KeyCode.LeftAlt))
					GUILayout.Toggle(true, "Alt", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Alt", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "space":
				if(Input.GetKey(KeyCode.Space))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize*6.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize*6.25f), GUILayout.Height(KeySize)); //
				break;
			case "rightalt":
				if(Input.GetKey(KeyCode.RightAlt))
					GUILayout.Toggle(true, "Alt", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Alt", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "menu":
				if(Input.GetKey(KeyCode.Menu))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "rightwindows":
				if(Input.GetKey(KeyCode.RightWindows))
					GUILayout.Toggle(true, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "rightcontrol":
				if(Input.GetKey(KeyCode.RightControl))
					GUILayout.Toggle(true, "Ctrl", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Ctrl", "Button", GUILayout.Width(KeySize*1.25f), GUILayout.Height(KeySize)); //
				break;
			case "rightshift":
				if(Input.GetKey(KeyCode.RightShift))
					GUILayout.Toggle(true, "Shift", "Button", GUILayout.Width(KeySize*2.75f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Shift", "Button", GUILayout.Width(KeySize*2.75f), GUILayout.Height(KeySize)); //
				break;
			case "return":
				if(Input.GetKey(KeyCode.Return))
					GUILayout.Toggle(true, "Enter", "Button", GUILayout.Width(KeySize*2.25f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Enter", "Button", GUILayout.Width(KeySize*2.25f), GUILayout.Height(KeySize)); //
				break;
			case "backspace":
				if(Input.GetKey(KeyCode.Backspace))
					GUILayout.Toggle(true, "Back", "Button", GUILayout.Width(KeySize*2f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "Back", "Button", GUILayout.Width(KeySize*2f), GUILayout.Height(KeySize)); //
				break;
			case "leftbracket":
				if(Input.GetKey(KeyCode.LeftBracket))
					GUILayout.Toggle(true, "[", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "[", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "rightbracket":
				if(Input.GetKey(KeyCode.RightBracket))
					GUILayout.Toggle(true, "]", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "]", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "backslash":
				if(Input.GetKey(KeyCode.Backslash))
					GUILayout.Toggle(true, "\\", "Button", GUILayout.Width(KeySize*1.5f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "\\", "Button", GUILayout.Width(KeySize*1.5f), GUILayout.Height(KeySize)); //
				break;
			case "semicolon":
				if(Input.GetKey(KeyCode.Semicolon))
					GUILayout.Toggle(true, ";", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, ";", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "quote":
				if(Input.GetKey(KeyCode.Quote))
					GUILayout.Toggle(true, "'", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "'", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "comma":
				if(Input.GetKey(KeyCode.Comma))
					GUILayout.Toggle(true, ",", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, ",", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "period":
				if(Input.GetKey(KeyCode.Period))
					GUILayout.Toggle(true, ".", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, ".", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "slash":
				if(Input.GetKey(KeyCode.Slash))
					GUILayout.Toggle(true, "/", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "/", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "minus":
				if(Input.GetKey(KeyCode.Minus))
					GUILayout.Toggle(true, "-", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "-", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "equals":
				if(Input.GetKey(KeyCode.Equals))
					GUILayout.Toggle(true, "=", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "=", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			
			/* right side keypad*/
			case "numlock":
				if(Input.GetKey(KeyCode.Numlock))
					GUILayout.Toggle(true, "Num\nLock", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "Num\nLock", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypaddivide":
				if(Input.GetKey(KeyCode.KeypadDivide))
					GUILayout.Toggle(true, "/", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "/", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypadmultiply":
				if(Input.GetKey(KeyCode.KeypadMultiply))
					GUILayout.Toggle(true, "*", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "*", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypadminus":
				if(Input.GetKey(KeyCode.KeypadMinus))
					GUILayout.Toggle(true, "-", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "-", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad7":
				if(Input.GetKey(KeyCode.Keypad7))
					GUILayout.Toggle(true, "7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "7", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad8":
				if(Input.GetKey(KeyCode.Keypad8))
					GUILayout.Toggle(true, "8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "8", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad9":
				if(Input.GetKey(KeyCode.Keypad9))
					GUILayout.Toggle(true, "9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "9", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypadplus":
				if(Input.GetKey(KeyCode.KeypadPlus))
					GUILayout.Toggle(true, "+", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize*2f)); // VERTICAL
				else
					GUILayout.Toggle(false, "+", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize*2f)); // VERTICAL
				break;
			case "keypad4":
				if(Input.GetKey(KeyCode.Keypad4))
					GUILayout.Toggle(true, "4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "4", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad5":
				if(Input.GetKey(KeyCode.Keypad5))
					GUILayout.Toggle(true, "5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "5", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad6":
				if(Input.GetKey(KeyCode.Keypad6))
					GUILayout.Toggle(true, "6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "6", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad1":
				if(Input.GetKey(KeyCode.Keypad1))
					GUILayout.Toggle(true, "1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "1", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad2":
				if(Input.GetKey(KeyCode.Keypad2))
					GUILayout.Toggle(true, "2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "2", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypad3":
				if(Input.GetKey(KeyCode.Keypad3))
					GUILayout.Toggle(true, "3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, "3", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
			case "keypadenter":
				if(Input.GetKey(KeyCode.KeypadEnter))
					GUILayout.Toggle(true, "Enter", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize*2f)); // VERTICAL
				else
					GUILayout.Toggle(false, "Enter", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize*2f)); // VERTICAL
				break;
			case "keypad0":
				if(Input.GetKey(KeyCode.Keypad0))
					GUILayout.Toggle(true, "0", "Button", GUILayout.Width(KeySize*2f), GUILayout.Height(KeySize)); //
				else
					GUILayout.Toggle(false, "0", "Button", GUILayout.Width(KeySize*2f), GUILayout.Height(KeySize)); //
				break;
			case "keypadperiod":
				if(Input.GetKey(KeyCode.KeypadPeriod))
					GUILayout.Toggle(true, ".", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				else
					GUILayout.Toggle(false, ".", "Button", GUILayout.Width(KeySize), GUILayout.Height(KeySize));
				break;
		}
	}
	
	void OnGUI()
	{
		GUI.skin = guiSkin;
		
		// Draw the Keyboard Layout
		if(isKeyboardVisible)
		{			
			GUILayout.BeginArea(keyboardRect);
			// Start Area
			
			//Spacer
			GUILayout.BeginVertical();
			GUILayout.Space(SpacerSize);
			GUILayout.EndVertical();
			
			//Row 6
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("esc");
			GUILayout.Space(KeySize);
			Draw("F1");
			Draw("F2");
			Draw("F3");
			Draw("F4");
			GUILayout.Space(SpacerSize);
			Draw("F5");
			Draw("F6");
			Draw("F7");
			Draw("F8");
			GUILayout.Space(SpacerSize);
			Draw("F9");
			Draw("F10");
			Draw("F11");
			Draw("F12");
			GUILayout.Space(SpacerSize);
			Draw("printscreen");
			Draw("scrolllock");
			Draw("pause");
			GUILayout.Space(KeySize);
			GUILayout.Space(KeySize); // toggle light 1
			GUILayout.Space(KeySize); // toggle light 2
			GUILayout.Space(KeySize); // toggle light 3
			GUILayout.Space(KeySize);
			GUILayout.EndHorizontal();
			
			//Spacer
			GUILayout.BeginVertical();
			GUILayout.Space(SpacerSize);
			GUILayout.EndVertical();
			
			//Row 5
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("backquote");
			Draw("1");
			Draw("2");
			Draw("3");
			Draw("4");
			Draw("5");
			Draw("6");
			Draw("7");
			Draw("8");
			Draw("9");
			Draw("0");
			Draw("minus");
			Draw("equals");
			Draw("backspace");
			GUILayout.Space(SpacerSize);
			Draw("insert");
			Draw("home");
			Draw("pageup");
			GUILayout.Space(SpacerSize);
			Draw("numlock");
			Draw("keypaddivide");
			Draw("keypadmultiply");
			Draw("keypadminus");
			GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			//Row 4
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("tab");
			Draw("q");
			Draw("w");
			Draw("e");
			Draw("r");
			Draw("t");
			Draw("y");
			Draw("u");
			Draw("i");
			Draw("o");
			Draw("p");
			Draw("leftbracket");
			Draw("rightbracket");
			Draw("backslash");
			GUILayout.Space(SpacerSize);
			Draw("delete");
			Draw("end");
			Draw("pagedown");
			GUILayout.Space(SpacerSize);
			Draw("keypad7");
			Draw("keypad8");
			Draw("keypad9");
			//Draw("keypadplus"); //////// VERTICAL TOP
			//GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			//Row 3
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("capslock");
			Draw("a");
			Draw("s");
			Draw("d");
			Draw("f");
			Draw("g");
			Draw("h");
			Draw("j");
			Draw("k");
			Draw("l");
			Draw("semicolon");
			Draw("quote");
			Draw("return");
			GUILayout.Space(SpacerSize);
			GUILayout.Space(KeySize);
			GUILayout.Space(KeySize);
			GUILayout.Space(KeySize);
			GUILayout.Space(SpacerSize);
			Draw("keypad4");
			Draw("keypad5");
			Draw("keypad6");
			//Draw("keypadplus"); //////// VERTICAL BOTTOM
			//GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			//Row 2
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("leftshift");
			Draw("z");
			Draw("x");
			Draw("c");
			Draw("v");
			Draw("b");
			Draw("n");
			Draw("m");
			Draw("comma");
			Draw("period");
			Draw("slash");
			Draw("rightshift");
			GUILayout.Space(SpacerSize);
			GUILayout.Space(KeySize);
			Draw("uparrow");
			GUILayout.Space(KeySize);
			GUILayout.Space(SpacerSize);
			Draw("keypad1");
			Draw("keypad2");
			Draw("keypad3");
			//Draw("keypadenter"); //////// VERTICAL TOP
			//GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			//Row 1
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			Draw("leftcontrol");
			Draw("leftwindows");
			Draw("leftalt");
			Draw("space");
			Draw("rightalt");
			Draw("rightwindows");
			Draw("menu");
			Draw("rightcontrol");
			GUILayout.Space(SpacerSize);
			Draw("leftarrow");
			Draw("downarrow");
			Draw("rightarrow");
			GUILayout.Space(SpacerSize);
			Draw("keypad0");
			Draw("keypadperiod");
			//Draw("keypadenter"); //////// VERTICAL BOTTOM
			//GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			//Spacer
			GUILayout.BeginVertical();
			GUILayout.Space(SpacerSize);
			GUILayout.EndVertical();
			
			// End Area
			GUILayout.EndArea();
			
			// Secondary Draw for Vertical Keys
			GUILayout.BeginArea(secondaryRect);
			GUILayout.BeginVertical();
			Draw ("keypadplus");
			Draw ("keypadenter");
			GUILayout.EndVertical();
			GUILayout.EndArea();
			
			// Mouse Draw
			GUILayout.BeginArea(mouseRect);
			
			// Spacer
			GUILayout.BeginVertical();
			GUILayout.Space(SpacerSize);
			GUILayout.EndVertical();
			
			// Mouse xy area
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			GUILayout.Box("", GUILayout.Width(KeySize*4), GUILayout.Height(KeySize*4));// DrawMouseBox
			GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			// Buttons
			GUILayout.BeginHorizontal();
			GUILayout.Space(SpacerSize);
			if(Input.GetMouseButton(0)) // left
				GUILayout.Toggle(true, "", "button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize));
			else
				GUILayout.Toggle(false, "", "button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize));
			if(Input.GetMouseButton(2)) // left
				GUILayout.Toggle(true, "", "button", GUILayout.Width(KeySize*0.5f), GUILayout.Height(KeySize));
			else
				GUILayout.Toggle(false, "", "button", GUILayout.Width(KeySize*0.5f), GUILayout.Height(KeySize));
			if(Input.GetMouseButton(1)) // left
				GUILayout.Toggle(true, "", "button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize));
			else
				GUILayout.Toggle(false, "", "button", GUILayout.Width(KeySize*1.75f), GUILayout.Height(KeySize));
			GUILayout.Space(SpacerSize);
			GUILayout.EndHorizontal();
			
			GUILayout.EndArea();
			
			DrawMousePosition();
		}
	}
		
	void DrawMousePosition()
	{
		GUI.BeginGroup(mouseView);
		GUI.DrawTexture(mCursorRect, mouseCursorTexture);
		GUI.EndGroup();
	}	
}
