using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Clase que se encarga de generar obstaculos, enemigos o monedas en el juego.
 */
public class GeneradorObjetos : MonoBehaviour
{
    public Transform[] puntosAparicion;
    public GameObject[] prefabsObstaculosYEnemigos;
    public GameObject prefabMoneda;

    void Start()
    {
        GenerarElementoAleatorio();
    }
    void GenerarElementoAleatorio()
    {
        int carrilObligatorio = Random.Range(0, puntosAparicion.Length);
        for (int i = 0; i < puntosAparicion.Length; i++)
        {
            bool generarAqui = (i == carrilObligatorio) || (Random.value < 0.5f);
            if (generarAqui)
            {
                Transform punto = puntosAparicion[i];
                int tipoObjeto = Random.Range(0, 2);
                GameObject prefabElegido;
                if (tipoObjeto == 0)
                {
                    int indiceObstaculo = Random.Range(0, prefabsObstaculosYEnemigos.Length);
                    prefabElegido = prefabsObstaculosYEnemigos[indiceObstaculo];
                }
                else
                {
                    prefabElegido = prefabMoneda;
                }

                GameObject nuevoObjeto = Instantiate(prefabElegido, punto.position, prefabElegido.transform.rotation);
                nuevoObjeto.transform.SetParent(this.transform);
            }
        }
    }
}