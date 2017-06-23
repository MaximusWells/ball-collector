using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public Text messanger;

	void Start()
	{
		messanger.enabled = false;
	}

	IEnumerator ShowMessage (string message, float delay)
	{
		messanger.text = message;
		messanger.enabled = true;
		yield return new WaitForSeconds(delay);
		messanger.enabled = false;
	}

	public void LoadByIndex(int sceneIndex)
	{
		if (NameInput.ready == true)
		{
			SceneManager.LoadScene (sceneIndex);
		}
		else
		{
			StartCoroutine(ShowMessage("Please, Enter Your Name", 3));
		}
	}
}