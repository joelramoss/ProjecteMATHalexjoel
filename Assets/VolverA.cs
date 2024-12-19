using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar las escenas

public class VolverA : MonoBehaviour
{
    // Método para ir a la escena "Menu"
    public void IrAMenu()
    {
        SceneManager.LoadScene("Menu"); // Carga la escena llamada "Menu"
    }
}
