using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
/* Clase que controla el movimiento del jugador recibiendo entradas del teclado. */
public class MovimientoJugador : MonoBehaviour
{
    public float velocidadAvance = 10f;
    public float velocidadHorizontal = 7f;
    public float fuerzaSalto = 7f;
    private Rigidbody cuerpoRigido;
    private bool enSuelo = true;

    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoPuntaje;
    private int contadorMonedas = 0;
    private float puntaje = 0f;

    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            cuerpoRigido.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
        puntaje += velocidadAvance * Time.deltaTime;
        textoMonedas.text = "MONEDAS: " + contadorMonedas.ToString("D2");
        textoPuntaje.text = "PUNTAJE: " + Mathf.FloorToInt(puntaje).ToString("D8");
    }

    void FixedUpdate()
    {
        Vector3 movimientoAvance = transform.forward * velocidadAvance * Time.fixedDeltaTime;
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movimientoHorizontal = transform.right * inputHorizontal * velocidadHorizontal * Time.fixedDeltaTime;


        cuerpoRigido.MovePosition(cuerpoRigido.position + movimientoAvance + movimientoHorizontal);
    }
    private void OnCollisionEnter(Collision collision)
    {
        enSuelo = true;
        if (collision.gameObject.CompareTag("Obstaculo") || collision.gameObject.CompareTag("Enemigo"))
        {
            ReiniciarPartida();
        }
    }
    void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Moneda"))
        {
            contadorMonedas++;
            Destroy(otro.gameObject);
        }





    }
}
