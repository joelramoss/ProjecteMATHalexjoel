using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorNivel : MonoBehaviour
{
    // Variable global para verificar si el nivel ha sido pasado
    public static bool Nivel1Pasado = false; // Por defecto es false

    // Método para activar el nivel pasado cuando el jugador elimine a los enemigos y pase por el trigger
    public void NivelSuperado()
    {
        Nivel1Pasado = true;
        Debug.Log("Nivel 1 pasado.");
    }
}

