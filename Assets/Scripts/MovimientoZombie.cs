using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Clase que contiene la logica de movimiento del zombie.
 */
public class MovimientoZombie : MonoBehaviour
{
    public float velocidad = 8f;

    void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.back * velocidad * Time.deltaTime, Space.World);
    }
}

