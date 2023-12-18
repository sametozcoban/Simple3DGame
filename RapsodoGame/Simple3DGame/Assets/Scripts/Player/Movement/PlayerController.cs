using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
  // [SerializeField] private int moveSpeed = 2;
  // [SerializeField] private float rotationSpeed = 5f; // Yön döndürme hızı
  // [SerializeField] private GameObject finishUI;
  // 
  // private PlayerMovement _playerMovement;
  // private Vector3 movement;
  // private Rigidbody rb;

  // private void Awake()
  // {
  //     _playerMovement = new PlayerMovement();
  //     rb = GetComponent<Rigidbody>();
  // }

  // private void Start()
  // {
  //     finishUI.SetActive(false);
  // }

  // private void OnEnable()
  // {
  //     _playerMovement.Enable();
  // }

  // // Update is called once per frame
  // void Update()
  // {
  //     PlayerInput();
  // }

  // private void FixedUpdate()
  // {
  //     Move();
  //     RotateWithMouse(); // Mouse ile bakış yönünü kontrol et
  // }

  // void PlayerInput()
  // {
  //     movement = _playerMovement.Movement.Move.ReadValue<Vector3>();
  // }

  // void Move()
  // {
  //     rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
  // }

  // void RotateWithMouse()
  // {
  //     // Mouse girişlerini al
  //     float mouseX = _playerMovement.Movement.RotateX.ReadValue<float>();
  //     float mouseY = _playerMovement.Movement.RotateY.ReadValue<float>();

  //     // Mouse'un yatay hareketine göre karakteri döndürme
  //     transform.Rotate(Vector3.up, mouseX * rotationSpeed);

  //     // Mouse'un dikey hareketine göre karakteri döndürme (isteğe bağlı)
  //     transform.Rotate(Vector3.right, mouseY * rotationSpeed);
  // }

  // private void OnTriggerEnter(Collider other)
  // {
  //     if (other.CompareTag("Finish"))
  //     {
  //         finishUI.SetActive(true);
  //         Time.timeScale = 0f;
  //     }
  // }
    public Camera playerCamera;
    public GameObject finishUI;
    public float walkSpeed = 3f;
    public float runSpeed = 4f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    public bool gameOver;

    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

    
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("SampleScene");
                gameOver = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
                gameOver = false;
            }
        }
    }
    
     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Finish"))
         {
             finishUI.SetActive(true);
             Time.timeScale = 0f;
             gameOver = true;
             
         }
     }
}
