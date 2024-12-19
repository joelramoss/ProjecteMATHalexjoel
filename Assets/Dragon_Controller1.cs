using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Controller1 : MonoBehaviour
{
    private Rigidbody2D rb;

    // Velocidades de movimiento
    public GestorPreguntas gestorPreguntas;
    public float verticalSpeed = 2f;       // Velocidad de movimiento vertical
    public float horizontalSpeed = 1.5f;   // Velocidad de movimiento horizontal

    private Vector2 moveDirection = Vector2.down; // Dirección inicial vertical (bajando)
    private float horizontalDirection = -1f;      // Dirección horizontal inicial (hacia la izquierda)

    void Start()
    {
        // Obtener el Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
            Debug.LogError("No se encontró un componente Rigidbody2D en el GameObject.");
    }

    void Update()
    {
        // Calcular el movimiento combinado (horizontal y vertical)
        Vector2 movement = new Vector2(horizontalDirection * horizontalSpeed, moveDirection.y * verticalSpeed);
        rb.velocity = movement;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado. Mostrando pregunta.");
            gestorPreguntas.MostrarPregunta(this.gameObject);
            // Detener el movimiento del dragón (opcional, si no quieres que se mueva)
            verticalSpeed = 0f;
            horizontalSpeed = 0f;
            rb.isKinematic = true;
            
            return; // Salir del método, evitando que se ejecute cualquier otra lógica
        }

        // Cambiar dirección a la inversa cuando el dragón toca cualquier trigger
        if (gameObject.CompareTag("dragon"))
        {
            // Cambiar la dirección vertical (arriba o abajo)
            if (other.CompareTag("TriggerArriba") || other.CompareTag("TriggerAbajo"))
            {
                moveDirection = moveDirection == Vector2.up ? Vector2.down : Vector2.up; // Invertir dirección vertical
                Debug.Log("Dirección vertical invertida: " + moveDirection);
            }

            // Cambiar la dirección horizontal (izquierda o derecha)
            if (other.CompareTag("TriggerIzquierda"))
            {
                horizontalDirection = 1f; // Cambiar dirección a derecha
                Debug.Log("Dirección horizontal invertida: Derecha");
            }
            else if (other.CompareTag("TriggerDerecha"))
            {
                horizontalDirection = -1f; // Cambiar dirección a izquierda
                Debug.Log("Dirección horizontal invertida: Izquierda");
            }
        }
    }
}
