using UnityEngine;

public class ControladorEsferasMapa : MonoBehaviour
{
    public GameObject[] esferasNivel; // Esferas que corresponden a los niveles
    public Color colorCompleto = Color.green; // Color que tendrá la esfera cuando se complete el nivel

    void Start()
    {
        ActualizarEsferas();
    }

    public void ActualizarEsferas()
    {
        // Verificar el estado de cada nivel y actualizar las esferas
        for (int i = 0; i < esferasNivel.Length; i++)
        {
            if (esferasNivel[i] != null)
            {
                // Verificar si el nivel ha sido completado y cambiar el color de la esfera
                bool nivelCompletado = false;
                switch (i)
                {
                    case 0:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel1Pasado;
                        break;
                    case 1:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel2Pasado;
                        break;
                    case 2:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel3Pasado;
                        break;
                    case 3:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel4Pasado;
                        break;
                    case 4:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel5Pasado;
                        break;
                    case 5:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel6Pasado;
                        break;
                    case 6:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel7Pasado;
                        break;
                    case 7:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel8Pasado;
                        break;
                    case 8:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel9Pasado;
                        break;
                    case 9:
                        nivelCompletado = GestorDeNivelesGlobal.Nivel10Pasado;
                        break;
                }

                // Si el nivel está completado, cambia el color de la esfera
                if (nivelCompletado)
                {
                    esferasNivel[i].GetComponent<Renderer>().material.color = colorCompleto;
                }
            }
        }
    }
}
