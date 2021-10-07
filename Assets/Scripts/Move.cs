using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpForce;
    private float dirX, dirZ, dirY;
    private bool isGrounded = true; //check if on the ground

    //get audio component
    AudioSource audioData; //plays the clip in the component

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        jumpForce = 50f;
        rb = GetComponent<Rigidbody2D>();
        //Get sound stuff
        audioData = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        //Arrow key controls
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirZ = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(0, jumpForce));
            //Play Sound
            audioData.Play(0);
            isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);


    }
    /*
    void OnCollisionEnter(Collision col)
    {
        // When target is hit
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
    */

    

    //Reset if grounded
    public void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;

        // When target is hit
        if (col.gameObject.tag == "DoorPortal")
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene(sceneName: "PlayScreen");
        }
        // When collided 
        if (col.gameObject.tag == "Enemy")
        {
            //Play Sound
            
        }
    }
}
