using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPechera : MonoBehaviour
{
    public LogicaNPC logicaNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Player")
        {
            logicaNPC.numDeObjetivos--;
            logicaNPC.textoMision.text = "Obten todas las pecheras" + "Restantes: " + logicaNPC.numDeObjetivos;
            if (logicaNPC.numDeObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "Completa la misión";
                logicaNPC.botonDeMision.SetActive(true);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
