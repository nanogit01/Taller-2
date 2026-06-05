using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Clase que se encargar de la logica de la bala.
 */
public class Proyectil : MonoBehaviour
{
    public float velocidad = 25f;
    public float tiempoVida = 3f;
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Enemigo") || otro.CompareTag("Obstaculo"))
        {
            Destroy(otro.gameObject);
            Destroy(this.gameObject);
        }
    }
}

