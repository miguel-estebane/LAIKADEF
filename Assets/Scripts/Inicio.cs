using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public int numeroEscena;

    public void Iniciar()
    {
        SceneManager.LoadScene(numeroEscena);
    }
}
