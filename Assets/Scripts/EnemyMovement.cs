using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class EnemyMovement : MonoBehaviour
{
    //DLL imports
    [DllImport("SimplePlugin")]
    private static extern float EnemyJumpForce();

    [DllImport("SimplePlugin")]
    private static extern float EnemySpeed();

    //enemy properties
    private Rigidbody2D rb;
    private float speed;
    //public float speed;
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
        //Check if DLL works
        Debug.Log(EnemyJumpForce());
        Debug.Log(EnemySpeed());

        //set properties
        //jumpForce = 5f; just to check if DLL really works
        jumpForce = EnemyJumpForce();
        speed = EnemySpeed();

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
