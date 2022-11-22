using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //--------------CAMARA--------------------------------------------------------
    [Header ("Camara")]    
    public Camera playerCamara;
    private float cameraVerticalAngle;
    [Header ("General")]
    //-----------------VARIABLES CAMINAR-------------------------------------------
    public float gravityScale = -20f;
    [Header ("Movimiento")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    
    [Header ("Rotacion")]
    public float rotationSensibility = 10f;

    [Header ("Salto")]
    //-----------------VARIABLES SALTO---------------------------------------------
    public float jumpHeight = 1.9f;
    
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update() 
    {
        Move();
        Look();
    }
    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
                else
                {
                    moveInput = transform.TransformDirection(moveInput) * walkSpeed;
                }

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }
        
        moveInput.y += gravityScale * Time.deltaTime;

        characterController.Move(moveInput * Time.deltaTime);
    }
    private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;
        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -20, 20);

        transform.Rotate(Vector3.up*rotationinput.x);
        playerCamara.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle,0f,0f);

    }
}
