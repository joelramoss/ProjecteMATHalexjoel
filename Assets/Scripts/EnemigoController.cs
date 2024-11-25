using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public GameObject jugador;  // Referencia al jugador (asignada en el Inspector)
    public float velocidadMovimiento = 2f;  // Velocidad de movimiento del enemigo

    private void Update()
    {
        // Verificar si el jugador está asignado
        if (jugador != null)
        {
            MoverEnemigo();
        }
    }

    void MoverEnemigo()
    {
        // Mover al enemigo hacia la posición del jugador
        Vector2 direccion = jugador.transform.position - transform.position;
        direccion.Normalize();  // Normaliza la dirección para mantener la velocidad constante

        // Mover el enemigo en la dirección calculada
        transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el enemigo toca al jugador, no hace nada o puedes manejarlo de otra forma
        if (other.CompareTag("Player"))  // Asegúrate de que tu jugador tiene el tag "Player"
        {
            Debug.Log("El enemigo ha tocado al jugador, pero no lo empuja.");
            // Aquí puedes agregar lógica adicional, como daño o alguna otra acción si lo deseas.
        }
    }
}
