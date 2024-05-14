using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using static UnityEngine.GraphicsBuffer;

public class InputController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] float jumpHeight = 1f;

    [SerializeField] GameObject mainCamera;

    public PlayerInput playerControls;

    private float keyboardW = 0f;
    private float keyboardS = 0f;
    private float cameraRotX = 0f;
    private int rotDir = 0;

    private bool grounded;

    public float gravity = 9.8f;

    private InputAction move;
    private InputAction look;
    private InputAction fire;
    private InputAction jump;

    Rigidbody rb;

    private Vector3 rotation;

    [SerializeField] private float timer = 3;
    private float fireBallTime;

    public GameObject FireBallPrefab;
    public Transform FireSpawnPoint;
    public float FireSpeed;

    //private float timeBetweenJumps;
    //private float jumpTimer;
    //private bool canJump;

    float currentPlayerX;
    float currentPlayerZ;

    private void Awake()
    {
        playerControls = new PlayerInput();
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //playerControls.Enable();
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        look = playerControls.Player.Look;
        look.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        //playerControls.Disable();
        move.Disable();
        fire.Disable();
        look.Disable();
        jump.Disable();
    }


    private void Update()
    {
        
        //HandleHorizontalRotation();
        //HandleVerticalRotation();
        //mainCamera.transform.rotation = Quaternion.Euler(61, -90, 0);
    }

    private void FixedUpdate()
    {
        
        grounded = IsGrounded();

        
        HandleMovement();
        

        if (grounded == false)
        {
            rb.AddRelativeForce(Vector3.down * gravity);
        }
    }

    void HandleMovement()
    {
        
        Vector2 axis = move.ReadValue<Vector2>();

        Vector3 input = (axis.x * transform.right) + (transform.forward * axis.y);

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Quaternion rotation = Quaternion.LookRotation(input, Vector3.up);
        //transform.rotation = rotation;

        //Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //movementDirection.Normalize();

        if (grounded == false) return;

        input *= speed;

        rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);
        //transform.rotation = Quaternion.Euler(0, -180, 0);

        //transform.rotation = Quaternion.LookRotation(input);
        //transform.forward = movementDirection;
    }


    bool IsGrounded()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 3;

        RaycastHit hit;
       

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
        {
            //Debug.Log(hit.collider);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
            return true;
        }
        else
        {
            //Debug.Log(hit.collider);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            return false;
        }
    }

    void Fire(InputAction.CallbackContext context)
    {
        
        shootFireBall();
        Debug.Log("You fired!" + fireBallTime);

    }

    void shootFireBall()
    {
        fireBallTime -= Time.deltaTime;
        Debug.Log(fireBallTime);
        if (fireBallTime > 0) return;

        fireBallTime = timer;
       
        GameObject fireBallObj = Instantiate(FireBallPrefab, FireSpawnPoint.transform.position, FireSpawnPoint.transform.rotation) as GameObject;
        Rigidbody fireBallRig = fireBallObj.GetComponent<Rigidbody>();
        fireBallRig.AddForce(fireBallRig.transform.forward * FireSpeed);
        
        Destroy(fireBallObj, 5f);
    }

    void Jump(InputAction.CallbackContext context)
    {
        
        if (grounded == false) return;
       
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    public void restartPosition()
    {
        gameObject.transform.position = new Vector3(1953, 890, -3422);

    }
}



