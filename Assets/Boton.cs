using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class Boton : MonoBehaviour
{
    // Método que cambia a la escena "Menu"
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");  // Asegúrate de que "Menu" es el nombre de tu escena
    }
}
