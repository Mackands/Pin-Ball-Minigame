using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public Joystick joystick;
	private int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetScoreText ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = joystick.Horizontal;
		float moveVertical = joystick.Vertical;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Item")) {
			Destroy (other.gameObject);
			score = score + 1;
			SetScoreText ();
		}
	}

	void SetScoreText (){
		scoreText.text = "Score : " + score.ToString ();
	}
}
