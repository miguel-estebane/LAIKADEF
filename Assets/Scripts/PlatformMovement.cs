using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    CharacterController characterController;
    Vector3 groundPos;
    Vector3 lastGroundPos;
    Vector3 currentPos;

    string grounName;
    string lastGroundName;

    bool isJump;

    private void Start() 
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Plataformamovil")
        {
            if (!isJump)
            {
                RaycastHit hit;
                if (Physics.SphereCast(transform.position,characterController.radius, -transform.up, out hit))
                {
                    GameObject inGround = hit.collider.gameObject;
                    grounName = inGround.name;
                    groundPos = inGround.transform.position;

                    if (groundPos != lastGroundPos && grounName == lastGroundName)
                    {
                        currentPos = Vector3.zero;
                        currentPos += groundPos - lastGroundPos;
                        characterController.Move(currentPos);
                    }
                    lastGroundName = grounName;
                    lastGroundPos = groundPos;
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (!characterController.isGrounded)
                {
                    currentPos = Vector3.zero;
                    lastGroundPos = Vector3.zero;
                    lastGroundName = null;
                    isJump = true;
                }
            }
            if (characterController.isGrounded)
            {
                isJump = false;
            }

        }
    }   
}
