using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform[] target;
    public float speed = 6.0f; 
    //UNA MATRIZ O ARRAY COMIENZA A CONTAR DESDE CERO
    int curPos = 0;
    int nextPos = 1;

    bool moveNext = true;
    public float timeToNext = 2.0f;
    
    //Rigidbody fuerza;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        if (moveNext)
        {
                    transform.position = Vector3.MoveTowards(transform.position, target[nextPos].position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, target[nextPos].position) <= 0)
        {
            StartCoroutine(TimeMove());
            curPos = nextPos;
            nextPos ++;

            if (nextPos > target.Length - 1)
            {
                nextPos = 0;
            }
        }
    }

    IEnumerator TimeMove()
    {
        moveNext = false;
        yield return new WaitForSeconds (timeToNext);
        moveNext = true;
    }

    /*
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Plataformamovil"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Plataformamovil"))
        {
            transform.parent = null;
        }
    }
    */
}
