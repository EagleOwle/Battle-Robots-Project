using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class KeyBinding : MonoBehaviour {

	public delegate void remap(KeyBinding key);
	public static event remap keyRemap;

	//Name comes from enum in KeyBindingsManager scrip
	public keyType keyName;
	//keycode set in inspector and by player
	public KeyCode thisKey = KeyCode.W;
	//Text to display keycode for user feedback
	public Text keyDisplay;

	//Used for color changing during key binding
	public GameObject button;
	public Color toggleColor = new Color();
	Image buttonImage;
	Color originalColor;

	//Internal variables
	bool reassignKey = false;
	Event curEvent;

	//Changes in button behavior should be made here
	void OnGUI()
	{
		curEvent = Event.current;
		//Checks if key is pressed and if button has been pressed indicating wanting to re-assign
		if(curEvent.isKey && curEvent.keyCode != KeyCode.None && reassignKey)
		{
			thisKey = curEvent.keyCode;
			ChangeKeyCode(false);
			UpdateKeyCode();
			SaveKeyCode();
		}
	}

	//Initializes
	void Awake()
	{
		buttonImage = button.GetComponent<Image>();
		originalColor = buttonImage.color;
		button.GetComponent<Button>().onClick.AddListener(() => ChangeKeyCode(true));
	}

	//Loads keycodes from player preferences
	void OnEnable()
	{
		//Comment out this line it you want to allow multiple simultaneous assignments
		KeyBinding.keyRemap += PreventDoubleAssign;

		KeyCode tempKey;
		tempKey = (KeyCode) PlayerPrefs.GetInt(keyName.ToString());

		if(tempKey.ToString() == "None")
		{
			Debug.Log(thisKey.ToString());
			keyDisplay.text = thisKey.ToString();	
			UpdateKeyCode();
			SaveKeyCode();
		}
		else
		{	
			thisKey = tempKey;
			keyDisplay.text = thisKey.ToString();	
			UpdateKeyCode();
		}
	}

	void OnDisable()
	{
		KeyBinding.keyRemap -= PreventDoubleAssign;
	}

	//Called by button on GUI
	public void ChangeKeyCode(bool toggle)
	{
		reassignKey = toggle;

		if(toggle)
		{
			buttonImage.color = toggleColor;

			if(keyRemap != null)
				keyRemap(this);
		}
		else
			buttonImage.color = originalColor;
	}
		
	//saves keycode to player prefs
	public void SaveKeyCode()
	{
		keyDisplay.text = thisKey.ToString();
		PlayerPrefs.SetInt(keyName.ToString(),(int)thisKey);
		PlayerPrefs.Save();
	}

	//Prevents user from remapping two keys at the same time
	void PreventDoubleAssign(KeyBinding kb)
	{
		if(kb != this)
		{
			reassignKey = false;
			buttonImage.color = originalColor;
		}
	}

	//updates dictionary on key bindings manager
	void UpdateKeyCode()
	{		
		KeyBindingManager.singleton.UpdateDictionary(keyName,thisKey);
	}
}
