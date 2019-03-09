using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

[AddComponentMenu("Practice/Movement/Player")]

public class PlayerMovement : MonoBehaviour {

    [Header("Wendy")]
    [Space(5)]
    [Header("Characters Move Direction")]
    public Vector3 moveDirection; //(has not been initialized)

    public CharacterController playerController;

    [Header("Character properties")]
    [Range(0,80)]
    public float runSpeed;
    [Range(0,80)]
    public float gravity;
    [Range(0,20)]
    public float jumpSpeed, maxJump = 15f;
    private float jumpForce;
    

    


    // Use this for initialization
    void Start ()
    {
        playerController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerController.isGrounded)
        {
            //keep initializing with player current position?
            // vector3 = (x , y , z)
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //this next line helps mouseLook direction of movement
            moveDirection = this.transform.TransformDirection(moveDirection);
            moveDirection *= runSpeed;

            if (Input.GetButton("Jump"))
            {
                #region Force Jump pseudo  code
                //jumpSpeed is the base jump force
                //jumpForce is the variable incremented while jump button is down
                //maxJump is used to set the upper limit of force
                //Note: 
                //if jump button is down 
                    //we build of force till we reach max force
                //else when button is not down
                        //if and only if force is NOT zero
                            //add base force to built up force
                            //make the y (up dir) of our movement vector3 = the total force
                            //set force to zero (so jump button has to be down again for force to not be zero)
                #endregion

                if (jumpForce < maxJump)
                {
                    jumpForce += Time.deltaTime * 10f;
                }
                else
                {
                    jumpForce = maxJump;
                }
                print(jumpForce);
            }
            else
            {
                if (jumpForce > 0)
                {
                    jumpForce += jumpSpeed;
                    moveDirection.y = jumpForce;
                    jumpForce = 0;
                }
            }

        }
        

        moveDirection.y -= gravity * Time.deltaTime; // this constantly emulates gravity 
        playerController.Move(moveDirection * Time.deltaTime); // this is where player actually is moved

    }
}
