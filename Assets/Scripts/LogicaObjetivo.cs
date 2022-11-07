using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivo : MonoBehaviour
{
    public int numObjetivos;
    public TextMeshProUGUI textMision;
    public GameObject botonMision;
    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length;
        textMision.text = "Obten la esfera" + "\n Restantes: " + numObjetivos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numObjetivos--;
            textMision.text = "Obten las esfera" + "\n Restantes: " + numObjetivos;
            if (numObjetivos <= 0)
            {
                textMision.text = "Mision completa";
                botonMision.SetActive(true);
            }
        }
    }
}
