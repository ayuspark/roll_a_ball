using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
	private int count;

    public float speed;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick_up"))
		{
			other.gameObject.SetActive (false);
			count += 1;
			setCountText ();
		}
	}

	void setCountText ()
	{	
		countText.text = "Count: " + count.ToString ();
		if (count == 8) 
		{
			winText.text = "You win!";
		}
	}
}