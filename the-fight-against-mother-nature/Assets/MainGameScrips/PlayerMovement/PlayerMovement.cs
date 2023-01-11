using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float crouchSpeed;
    [SerializeField]
    private float crouchYScale;
    [SerializeField]
    private float jumpForce; // Is relatief met de mass
    [SerializeField]
    private float jumpCoolDown;
    [SerializeField]
    private bool jumpContinuous;
    [SerializeField]
    private float airMultiplier;
    [SerializeField]
    private float groundDrag;
    private bool readyToJump = true;


    [Header("Keybinds")]
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    [SerializeField]
    private float playerHeigt;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool onGround;

    [SerializeField]
    private Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private bool jumpted;
    private bool sprinted;
    private bool crouchedDown;
    private bool crouchedUp;

    private Vector3 moveDirection;

    Rigidbody rb;

  

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // gebruik de rigidbody component
        rb.freezeRotation = true;
    }


    private void Update()
    {
        MyInput(); // checkt forupdates van de input
        MovePlayer(); // set here because game feels smoother if its here (but not correctly because it moves player based on fysics

        checkPlayerOnGround();
        if (onGround)
        {
            rb.drag = groundDrag;

        }
        else
        {
            rb.drag = 0;
        }

    }
    private void FixedUpdate()
    {
        // move player 
        SpeedControll();
        playerSpeed();


        if (jumpted & readyToJump & onGround & !crouchedDown & !crouchedUp)
        {
            readyToJump = false;
            jump();
            Invoke(nameof(resetJump), jumpCoolDown); // gaat na x aantal tijd, de functie resetJump runnen, en jumping terug toestaan

        }



    }

    private void checkPlayerOnGround()
    {

        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeigt * 0.5f + 0.2f, whatIsGround); // gaat check of de speler op de grond staat, schiet een raycast van de helft van je speler hoogte + 0.2 buffer, als deze iets detecteerd betekend dat hij op de grond staat          
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // update horizontalInput
        verticalInput = Input.GetAxisRaw("Vertical");


        if (jumpContinuous)
        {
            jumpted = Input.GetKey(jumpKey);
        } else
        {
            jumpted = Input.GetKeyDown(jumpKey);
        }

         
        crouchedDown = Input.GetKeyDown(crouchKey);
        crouchedUp = Input.GetKeyUp(crouchKey);
        sprinted = Input.GetKey(sprintKey);


        if (crouchedDown)
        {
            makePlayerCrouch(true);
        }
        else if (crouchedUp)
        {
            makePlayerCrouch(false);
        }








    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; // calculate moveDirection


        if (onGround)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); // add a forward force to the player

        }
        else if (!onGround)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControll()
    {

        // Make the player a fixt speed!
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 
        if (flatVel.magnitude > moveSpeed) // zorgt ervoor dat snelheid constant blijft
        {
            Vector3 limetedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limetedVel.x, rb.velocity.y, limetedVel.z);
        }
    }


    private void playerSpeed()
    {


        if (crouchedDown & crouchedUp) {


            moveSpeed = crouchSpeed;


        } else if (sprinted) {

            moveSpeed = sprintSpeed;
        } else if (onGround) // als je op de grond bent
        {

            moveSpeed = walkSpeed;
        } 
    }




    private void makePlayerCrouch(bool state)
    {
        if (state)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z); // zal de speler een nieuwe y scale geven wanneer hij croucht
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); // drukt de speler gelijk tegen de grond (anders zal hij wanneer hij croucht uit de lucht vallen
        } else if (!state) // make player uncrouch
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        }

    }

    private void jump()
    {

            
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // reset y velocity to 0
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); // voegt force naar boven uit
   
    }

    private void resetJump()
    {
        readyToJump = true;
    }
}
