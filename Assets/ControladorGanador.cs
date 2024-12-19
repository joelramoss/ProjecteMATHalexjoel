using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class ControladorGanador : MonoBehaviour
{
    // Método para cargar la escena "Jugar"
    public void IrALaEscenaJugar()
    {
        SceneManager.LoadScene("Jugar"); // Carga la escena "Jugar"
    }

    // Detecta el final del nivel
    void Update()
    {
        // Lógica para determinar si el nivel ha terminado
        if (NivelCompletado()) // Reemplaza esto con tu propia condición
        {
            IrALaEscenaJugar();
        }
    }

    // Aquí defines la condición para que el nivel se considere completado
    private bool NivelCompletado()
    {
        // Reemplaza esta lógica con la tuya, por ejemplo:
        // Podría ser algo como: return jugadorHaLlegadoAlFinal;
        return true; // Esta es solo una simulación, cámbialo según tu lógica
    }
}
