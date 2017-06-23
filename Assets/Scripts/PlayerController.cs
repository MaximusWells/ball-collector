using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public Text countText;
	public Text winText;
	public Text controls;
	public Text playerName;
	public Button mainMenu;

	private Rigidbody rb;
	public int count;
	private bool jump;

	void SetCountText ()
	{
		countText.text = "Cubes collected: " + count.ToString ();
		if (count >= 17)
		{
			winText.text = "You Win!";
			Time.timeScale = 0;
			mainMenu.gameObject.SetActive (true);
		}
	}

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		jump = false;
		SetCountText ();
		winText.text = "";
		playerName.text = NameInput.userName;
		controls.text = "W,A,S,D - Move\n RMB - Look around\n L.Shift - Stop moving\n Space - Jump\n ESC - Exit game";
	}

	void Update ()
	{
		if (Input.GetKeyDown ("escape"))
		{
			Application.Quit ();
		}
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

		if(Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") !=0)
		{
			rb.AddForce (Camera.main.transform.forward * moveVertical);
			rb.AddForce (Camera.main.transform.right * moveHorizontal);
		}

		if (Input.GetKeyDown ("space") && jump == false)
		{
			rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			jump = true;
		}

		if(Input.GetKeyDown(KeyCode.LeftShift) && jump == false)
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero; 
		}

		if (transform.position.y < -25)
		{
			transform.position = new Vector3(0, 1, 11);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}

	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.CompareTag ("Play Area"))
		{
			jump = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
}