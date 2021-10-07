using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //enemy properties
    private Rigidbody2D rb;
    public float speed;
    private float jumpForce;

    //targeting
    private Transform target;

    //check if on ground
    private bool isGrounded = true; //check if on the ground

    //get audio component
    AudioSource audioData; //plays the clip in the component

    // Start is called before the first frame update
    void Start()
    {
        //set properties
        jumpForce = 50f;
        rb = GetComponent<Rigidbody2D>();

        //set target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Get sound stuff
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //toggle variable
            isGrounded = false;

            //Play jump Sound
            audioData.Play(0);
        }
    }
    private void FixedUpdate()
    {
        

    }

    //Reset if grounded
    public void OnCollisionEnter2D()
    {
        isGrounded = true;

        //They always jump so play the collide sound
        

    }

}
