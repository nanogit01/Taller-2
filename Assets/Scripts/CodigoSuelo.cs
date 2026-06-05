using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Clase encargada de generar el suelo infinito.
 */
public class CodigoSuelo : MonoBehaviour
{
    public GameObject prefabSuelo;
    public Transform jugador;
    private float proximaPosicionZ = 0f;

    public float largoPlataforma = 100f;

    public int plataformaEnpantalla = 15;

    private List<GameObject> plataformasActivas = new List<GameObject>();

    public float zonaDestruccion = 15f;

    void Start()
    {
        for (int i = 0; i < plataformaEnpantalla; i++)
        {
            AgregarPlataforma();
        }
    }

    void Update()
    {
        if (jugador.position.z - zonaDestruccion > plataformasActivas[0].transform.position.z)
        {
            AgregarPlataforma();
            BorrarSueloViejo();
        }
    }

    void AgregarPlataforma()
    {
        GameObject nuevaPlataforma = Instantiate(prefabSuelo, new Vector3(0, 0, proximaPosicionZ), Quaternion.identity);
        plataformasActivas.Add(nuevaPlataforma);
        proximaPosicionZ += largoPlataforma;
    }

    private void BorrarSueloViejo()
    {
        Destroy(plataformasActivas[0]);
        plataformasActivas.RemoveAt(0);
    }
}