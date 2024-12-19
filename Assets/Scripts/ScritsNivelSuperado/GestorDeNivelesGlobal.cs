using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeNivelesGlobal : MonoBehaviour
{
    // Variables globales para el estado de los niveles
    public static bool Nivel1Pasado = false;
    public static bool Nivel2Pasado = false;
    public static bool Nivel3Pasado = false;
    public static bool Nivel4Pasado = false;
    public static bool Nivel5Pasado = false;
    public static bool Nivel6Pasado = false;
    public static bool Nivel7Pasado = false;
    public static bool Nivel8Pasado = false;
    public static bool Nivel9Pasado = false;
    public static bool Nivel10Pasado = false;

    // Método para establecer un nivel como completado
    public static void MarcarNivelComoCompletado(int nivel)
    {
        switch (nivel)
        {
            case 1:
                Nivel1Pasado = true;
                break;
            case 2:
                Nivel2Pasado = true;
                break;
            case 3:
                Nivel3Pasado = true;
                break;
            case 4:
                Nivel4Pasado = true;
                break;
            case 5:
                Nivel5Pasado = true;
                break;
            case 6:
                Nivel6Pasado = true;
                break;
            case 7:
                Nivel7Pasado = true;
                break;
            case 8:
                Nivel8Pasado = true;
                break;
            case 9:
                Nivel9Pasado = true;
                break;
            case 10:
                Nivel10Pasado = true;
                break;
            default:
                Debug.LogWarning("Nivel no válido.");
                break;
        }
        if (Nivel10Pasado){
            SceneManager.LoadScene("fin_ganado");
        }
    }
}
