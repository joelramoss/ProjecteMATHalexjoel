using UnityEngine;
using UnityEngine.UI;

public class GestorPreguntas : MonoBehaviour
{
    public Pregunta[] preguntas; // Lista de preguntas
    public GameObject fondoBlanco; // Fondo blanco
    public GameObject panelPregunta; // Panel que contiene la pregunta y las opciones
    public Text textoPregunta; // Texto para la pregunta
    public Button[] botonesOpciones; // Botones para las respuestas

    private Pregunta preguntaActual;

    void Start()
    {
        fondoBlanco.SetActive(false); // Ocultar el fondo al inicio
        panelPregunta.SetActive(false); // Ocultar el panel al inicio
    }

    // Llama a este método cuando el jugador alcance la posición
    public void MostrarPregunta()
    {
        preguntaActual = preguntas[Random.Range(0, preguntas.Length)]; // Seleccionar una pregunta aleatoria
        textoPregunta.text = preguntaActual.textoPregunta;

        for (int i = 0; i < botonesOpciones.Length; i++)
        {
            botonesOpciones[i].GetComponentInChildren<Text>().text = preguntaActual.opciones[i];
            int indice = i; // Capturar el índice correcto
            botonesOpciones[i].onClick.RemoveAllListeners();
            botonesOpciones[i].onClick.AddListener(() => ValidarRespuesta(indice));
        }

        fondoBlanco.SetActive(true); // Mostrar fondo blanco
        panelPregunta.SetActive(true); // Mostrar panel de la pregunta
    }

    // Valida si la respuesta seleccionada es correcta
    private void ValidarRespuesta(int indiceSeleccionado)
    {
        if (indiceSeleccionado == preguntaActual.indiceRespuestaCorrecta)
        {
            Debug.Log("¡Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
        }

        // Ocultar el fondo y el panel después de responder
        fondoBlanco.SetActive(false);
        panelPregunta.SetActive(false);
    }
}
