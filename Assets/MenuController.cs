using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Salir;
    [SerializeField] private GameObject BotonPlay;
    [SerializeField] private GameObject BotonCasa; // Referencia al botón para volver al menú
    public GameObject MenuEsc; // Referencia al menú que aparecerá con Esc
    private bool isMenuActive = false; // Estado del menú Esc

    public void Exit()
    {
        // Salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación en la build del juego
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        isMenuActive = false;
        MenuEsc.SetActive(false);
    }

    public void ToggleMenuEsc()
    {
        isMenuActive = !isMenuActive;
        MenuEsc.SetActive(isMenuActive);

        // Pausar o reanudar el tiempo según el estado del menú
        Time.timeScale = isMenuActive ? 0f : 1f;
    }

    public void VolverAlMenu()
    {
        Debug.Log("Volviendo al menú principal...");
        Time.timeScale = 1f; // Asegurarse de reanudar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("Jugar"); // Cambia a la escena llamada "Jugar"
    }

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el menú esté desactivado al inicio
        if (MenuEsc != null)
        {
            MenuEsc.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tecla Escape presionada");
            ToggleMenuEsc();
        }
    }
}
