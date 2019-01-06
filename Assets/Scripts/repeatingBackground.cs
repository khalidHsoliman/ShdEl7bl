using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
    private Rigidbody2D rb2d;


    private float GHLength; //ground horizontal length
    public float scrollSpeed = -0.5f;


    // Use this for initialization
    void Start ()
	{
		groundCollider = GetComponent<BoxCollider2D> ();
        rb2d = GetComponent<Rigidbody2D>();

        GHLength = groundCollider.size.x;
        rb2d.velocity = new Vector2(scrollSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < -GHLength) 
		{
			repositionBackground ();
		}
	}

	private void repositionBackground()
	{
		Vector2 groundOffset = new Vector2 (GHLength * 2f, 0f);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
