using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class BotonControlador : MonoBehaviour
{
    // Método para cambiar a la escena de menú
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu"); // Cambiar "Menu" por el nombre de tu escena
    }
}
