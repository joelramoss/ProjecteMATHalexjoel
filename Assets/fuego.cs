using UnityEngine;

public class fuego : MonoBehaviour
{
    public float velocidad = 10f;  // Velocidad del fuego
    public Vector2 direccion = Vector2.left;  // Dirección a la izquierda (Vector2 para 2D)
    
    public PlayerController playerController;  // Referencia al PlayerController
    
    private bool haToadoJugador = false;  // Bandera para comprobar si el fuego ya ha tocado al jugador

    // Start is called before the first frame update
    void Start()
    {
        // Si el fuego tiene un Rigidbody2D, le asignamos la velocidad en la dirección deseada
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direccion.normalized * velocidad;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí no se necesita temporizador si solo hay una acción de colisión
    }

    // Método que detecta la colisión con el jugador
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si ha colisionado con el jugador y si no ha tocado antes
        if (other.CompareTag("Player") && !haToadoJugador)  
        {
            // Resta una vida solo la primera vez que toca al jugador
            other.GetComponent<PlayerController>().vida -= 1;
            //playerController.vida -= 1;  
            haToadoJugador = true;  // Establece la bandera a true para evitar más pérdidas de vida
        }

        // Método que detecta la colisión con objetos que tengan el tag "finizquierda"
        if (other.CompareTag("finizquierda"))
        {
            // Destruye el objeto fuego cuando toca un objeto con el tag "finizquierda"
            Destroy(gameObject);
        }

        // Puedes añadir aquí otros casos para detectar colisiones con diferentes objetos sin que afecten a la vida del jugador
        // Ejemplo: Si el fuego toca otro objeto que no es el jugador ni "finizquierda", no hace nada o realiza otra acción
    }

    // Método que se puede usar para reiniciar la bandera, en caso de que sea necesario
    public void ReiniciarTocandoJugador()
    {
        haToadoJugador = false;  // Restablecer la bandera si es necesario (puede ser útil en algunas situaciones)
    }
}
