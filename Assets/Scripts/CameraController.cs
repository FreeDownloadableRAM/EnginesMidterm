using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerBox; //Get the player

    private Vector3 offset; //Follow the player

    // Start is called before the first frame update
    void Start()
    {
        //Calculate where the player is
        offset = transform.position - PlayerBox.transform.position;

    }

    // Late Update is called to update once per frame after Update()
    void LateUpdate()
    {
        //Set camera position to the player
        transform.position = PlayerBox.transform.position + offset;
    }
}
