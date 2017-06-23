using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {

	public InputField playerName;
	public Text playerNameText;
	public static string userName;
	public static bool ready;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void LockInput(InputField input)
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			userName = input.text;
			playerNameText.text = "Your players name is " + userName;
			ready = true;
		}
	}

	public void Start()
	{
		playerName.onEndEdit.AddListener(delegate {LockInput(playerName); });
	}
}