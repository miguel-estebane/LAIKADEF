using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //--------------------------------------------
    [Header ("References")]
    public Camera playerCamera;
    //------------------------------------------
    private Rigidbody JugadorRB;
    private GameObject camara;
    public int velocidad = 80;
    private int sensibilidad = 140;
    //private int fuerzaSalto = 5;
    private float ejeX;
    private float ejeY;
    private float rotar;

    //CAMARA-------------------------------------
    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;

    //----------------------------------------
    bool floorDetected = false; 
    bool Isjump = false;
    public float ForceJump = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        JugadorRB = GetComponent<Rigidbody>();
        camara = GameObject.Find("camera");
        // camara.transform.parent = JugadorRB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ejeX = Input.GetAxis("Horizontal");
        ejeY = Input.GetAxis("Vertical");
        rotar = Input.GetAxis("Mouse X");
        transform.Translate(Vector3.right * Time.deltaTime * velocidad * ejeX);
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * ejeY);
        transform.Rotate(Vector3.up * Time.deltaTime * sensibilidad * rotar);

            Vector3 floor = transform.TransformDirection(Vector3.down);

    if(Physics.Raycast(transform.position, floor, 1.03f))
    {
        floorDetected = true;
        print("Contacto con el suelo");
        
    }
     else
    {
        floorDetected = false;
        print("No hay contacto");
    }

    Isjump = Input.GetButtonDown("Jump");

        if(Isjump && floorDetected)
        {   
            JugadorRB.AddForce(new Vector3(0,ForceJump,9), ForceMode.Impulse); 
        }
    }
        private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotar * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotar * Time.deltaTime;

        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle,0f,0f);
    }

}
