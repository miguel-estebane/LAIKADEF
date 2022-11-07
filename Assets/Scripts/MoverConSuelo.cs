using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverConSuelo : MonoBehaviour
{
    CharacterController player;
    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastgroundName;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, player.height / 4.2f, -transform.up, out hit))
            {
                GameObject groundedIn= hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if (groundPosition != lastGroundPosition && groundName == lastgroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                }
                lastgroundName = groundName;
                lastGroundPosition = groundPosition;
            }
        }
        else if (!player.isGrounded)
        {
            lastgroundName = null;
            lastGroundPosition = Vector3.zero;
        }
    }

    private void OnDrawGizmos() {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }
}
