using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Clase que instancia proyectiles al presionar una tecla.
 */
public class DIsparoJugador : MonoBehaviour
{
    public GameObject prefabBalas;
    public Transform puntoDeDisparo;
    public float tiempoEntreDisparos = 0.5f;
    private float tiempoUltimoDisparo = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }
    void Disparar()
    {
        Instantiate(prefabBalas, puntoDeDisparo.position, puntoDeDisparo.rotation);
    }

}
