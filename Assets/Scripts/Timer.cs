using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Text time;

	private float timer;

	void Update ()
	{
		timer += Time.deltaTime;

		string minutes = Mathf.Floor(timer / 60).ToString("00");
		string seconds = Mathf.Floor(timer % 60).ToString("00");
		string fraction = Mathf.Floor((timer * 100) % 100).ToString("000");
		time.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
	}
}