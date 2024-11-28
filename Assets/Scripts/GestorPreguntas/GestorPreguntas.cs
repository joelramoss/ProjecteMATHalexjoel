using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestorPreguntas : MonoBehaviour
{
    public GameObject fondoBlanco; // Fondo blanco
    public GameObject panelPregunta; // Panel que contiene la pregunta y las opciones
    public Text textoPregunta; // Texto para la pregunta
    public Button[] botonesOpciones; // Botones para las respuestas

    // Definición de preguntas, opciones y respuestas correctas directamente en este script
    private string[] preguntas = new string[]
    {
        "¿Cuál es el resultado de 5 + 7?",
        "¿Cuánto es 9 x 3?",
        "¿Cuál es la raíz cuadrada de 49?",
        "Si tienes 15 manzanas y regalas 5, ¿cuántas te quedan?",
        "¿Cuánto es 12 ÷ 4?",
        "¿Qué número falta en esta secuencia: 2, 4, __, 8?",
        "¿Cuánto es 6 x 7?",
        "¿Cuál es el resultado de 15 - 8?",
        "¿Cuánto es 81 ÷ 9?",
        "Si compras 3 camisetas por 20€ cada una, ¿cuánto gastas en total?",
        "¿Cuánto es 14 + 23?",
        "Si un rectángulo tiene lados de 4 y 7, ¿cuál es su perímetro?",
        "¿Cuánto es 10²?",
        "¿Cuál es la fracción equivalente a 0.5?",
        "Si un coche recorre 60 km en 2 horas, ¿cuál es su velocidad media?",
        "¿Cuánto es 25 + 19?",
        "¿Cuánto es 36 ÷ 6?",
        "¿Cuánto es 8 x 12?",
        "Si un triángulo tiene un ángulo de 90º, ¿cómo se llama?",
        "¿Cuál es el resultado de 100 - 36?",
        "¿Cuánto es 15 x 4?",
        "Si tienes 100€ y gastas el 20%, ¿cuánto te queda?",
        "¿Cuánto es 64 ÷ 8?",
        "¿Cuánto es 7 x 8?",
        "Si un círculo tiene un diámetro de 10, ¿cuál es su radio?",
        "¿Cuánto es 50 + 25?",
        "¿Cuál es el resultado de 18 - 9?",
        "¿Cuánto es 9 x 9?",
        "Si un tren tarda 4 horas en recorrer 240 km, ¿cuál es su velocidad media?",
        "¿Cuánto es 45 ÷ 5?",
        "¿Cuál es el resultado de 7 + 8 + 6?",
        "¿Cuánto es 50 - 18?",
        "Si un cuadrado tiene un lado de 5, ¿cuál es su área?",
        "¿Cuánto es 4³ (4 elevado al cubo)?",
        "¿Cuál es la suma de los ángulos internos de un triángulo?",
        "¿Cuánto es 120 ÷ 12?",
        "¿Cuánto es 6 x 9?",
        "Si un número es divisible por 2, ¿cómo se llama?",
        "¿Cuánto es 100 - 74?",
        "¿Cuál es el menor número primo?",
        "Si un pentágono tiene 5 lados, ¿cuántos tiene un hexágono?",
        "¿Cuánto es 14 x 5?",
        "¿Cuánto es 81 ÷ 3?",
        "¿Cuánto es 0.25 x 4?",
        "¿Cuánto es 8 x 11?",
        "Si tienes 6 cajas con 5 libros cada una, ¿cuántos libros tienes en total?",
        "¿Cuánto es 45 + 55?",
        "Si divides 100 entre 4, ¿cuánto obtienes?",
        "¿Cuánto es 5 x 15?",
        "¿Cuánto es 13² (13 al cuadrado)?",
        "¿Qué número falta en esta secuencia: 3, 6, 9, __, 15?",
        "¿Cuánto es 100 x 0.1?",
        "¿Cuánto es 48 ÷ 6?",
        "¿Cuánto es 7 x 6?",
        "¿Cuánto es 0.5 x 20?",
        "¿Cuánto es 25 x 4?",
        "¿Cuánto es 100 ÷ 20?",
        "Si un triángulo tiene lados de 3, 4 y 5, ¿qué tipo de triángulo es?",
        "¿Cuál es el resultado de 60 ÷ 3?",
        "Si divides 50 entre 2, ¿cuánto obtienes?",
        "¿Cuánto es 7 x 8?",
        "Si tienes 4 manzanas y comes 2, ¿cuántas te quedan?",
        "¿Cuánto es 81 ÷ 9?",
        "¿Cuánto es 3 x 14?",
        "¿Cuánto es 36 ÷ 6?",
        "Si tienes 15 € y gastas 5 €, ¿cuánto te queda?",
        "¿Cuánto es 60 ÷ 12?",
        "¿Cuánto es 4 x 25?",
        "¿Cuánto es 50 ÷ 2?",
        "¿Cuál es la mitad de 72?",
        "¿Cuánto es 8²?",
        "¿Cuál es el triple de 15?",
        "Si tienes 20 € y gastas el 50%, ¿cuánto te queda?"
    };

    private string[][] opciones = new string[][]
    {
        new string[] { "12", "10", "15" },
        new string[] { "18", "27", "24" },
        new string[] { "6", "8", "7" },
        new string[] { "10", "8", "7" },
        new string[] { "2", "4", "3" },
        new string[] { "5", "6", "7" },
        new string[] { "42", "36", "48" },
        new string[] { "6", "7", "5" },
        new string[] { "8", "9", "7" },
        new string[] { "60", "50", "70" },
        new string[] { "37", "36", "38" },
        new string[] { "22", "24", "20" },
        new string[] { "100", "20", "200" },
        new string[] { "1/3", "1/2", "1/4" },
        new string[] { "30 km/h", "25 km/h", "40 km/h" },
        new string[] { "43", "44", "42" },
        new string[] { "5", "6", "7" },
        new string[] { "96", "86", "88" },
        new string[] { "Isósceles", "Rectángulo", "Obtuso" },
        new string[] { "64", "63", "66" },
        new string[] { "65", "60", "70" },
        new string[] { "80€", "90€", "70€" },
        new string[] { "6", "8", "9" },
        new string[] { "56", "48", "64" },
        new string[] { "5", "8", "6" },
        new string[] { "70", "75", "80" },
        new string[] { "9", "10", "8" },
        new string[] { "81", "72", "90" },
        new string[] { "60 km/h", "50 km/h", "70 km/h" },
        new string[] { "8", "9", "10" },
        new string[] { "21", "22", "23" },
        new string[] { "33", "32", "31" },
        new string[] { "20", "15", "25" },
        new string[] { "16", "64", "12" },
        new string[] { "360º", "180º", "90º" },
        new string[] { "10", "12", "8" },
        new string[] { "54", "64", "49" },
        new string[] { "Impar", "Par", "Primo" },
        new string[] { "26", "24", "25" },
        new string[] { "2", "3", "5" },
        new string[] { "6", "7", "8" },
        new string[] { "70", "65", "75" },
        new string[] { "27", "25", "30" },
        new string[] { "1", "0.5", "0.75" },
        new string[] { "80", "88", "96" },
        new string[] { "30", "25", "35" },
        new string[] { "100", "95", "105" },
        new string[] { "20", "25", "30" },
        new string[] { "60", "65", "75" },
        new string[] { "169", "144", "156" },
        new string[] { "10", "11", "12" },
        new string[] { "1", "10", "100" },
        new string[] { "6", "8", "9" },
        new string[] { "42", "48", "36" },
        new string[] { "5", "10", "20" },
        new string[] { "100", "125", "80" },
        new string[] { "4", "5", "6" },
        new string[] { "25", "30", "20" },
        new string[] { "32", "34", "36" },
        new string[] { "64", "48", "56" },
        new string[] { "30", "45", "50" },
        new string[] { "10", "15", "5" }
    };

    private int[] respuestasCorrectas = new int[]
    {
        0, 1, 2, 0, 2, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 2, 0, 1, 0, 0, 2, 1, 1, 0, 1, 0, 1, 0, 1, 2, 2, 0, 1, 0, 1, 0, 2, 0, 0, 1, 1, 0, 0, 1, 0
    };

    private string preguntaActual;
    private string[] opcionesPreguntaActual;
    private int indiceRespuestaCorrecta;

    void Start()
    {
        fondoBlanco.SetActive(false); // Ocultar el fondo al inicio
        panelPregunta.SetActive(false); // Ocultar el panel al inicio
    }

    // Llama a este método cuando el jugador alcance la posición
public void MostrarPregunta()
{
    // Verificar que el array de preguntas no esté vacío
    if (preguntas.Length == 0)
    {
        Debug.LogError("El array de preguntas está vacío.");
        return;  // Salir si no hay preguntas
    }

    // Verificar que botonesOpciones[] esté asignado correctamente
    if (botonesOpciones.Length == 0 || botonesOpciones[0] == null)
    {
        Debug.LogError("Los botones de opciones no están asignados correctamente.");
        return;  // Salir si no hay botones
    }

    // Verificar que fondoBlanco y panelPregunta están asignados
    if (fondoBlanco == null || panelPregunta == null || textoPregunta == null)
    {
        Debug.LogError("Uno de los elementos UI no está asignado en el Inspector.");
        return;  // Salir si algún UI no está asignado
    }

    // Seleccionar una pregunta aleatoria
    int indicePregunta = Random.Range(0, preguntas.Length);
    preguntaActual = preguntas[indicePregunta];
    opcionesPreguntaActual = opciones[indicePregunta];
    indiceRespuestaCorrecta = respuestasCorrectas[indicePregunta];

    // Verificar que las opciones de la pregunta no estén vacías
    if (opcionesPreguntaActual == null || opcionesPreguntaActual.Length == 0)
    {
        Debug.LogError("La pregunta seleccionada no tiene opciones. Texto de la pregunta: " + preguntaActual);
        return;  // Salir si no tiene opciones
    }

    // Mostrar la pregunta en el UI
    textoPregunta.text = preguntaActual;

    // Asignar las opciones a los botones
    for (int i = 0; i < botonesOpciones.Length; i++)
    {
        // Comprobar si el botón existe
        if (botonesOpciones[i] == null)
        {
            Debug.LogError("El botón en el índice " + i + " no está asignado correctamente.");
            continue; // Pasar al siguiente índice si el botón es null
        }

        // Asegurarse de que el componente de texto existe dentro del botón (usando TextMeshProUGUI)
        TextMeshProUGUI textoBoton = botonesOpciones[i].GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton == null)
        {
            Debug.LogError("El botón en el índice " + i + " no tiene un componente TextMeshProUGUI.");
            continue; // Pasar al siguiente índice si no tiene un componente TextMeshProUGUI
        }

        // Asignar el texto de la opción al botón
        textoBoton.text = opcionesPreguntaActual[i];

        int indice = i;  // Capturar el índice correcto para la respuesta
        botonesOpciones[i].onClick.RemoveAllListeners();  // Eliminar cualquier listener previo
        botonesOpciones[i].onClick.AddListener(() => ValidarRespuesta(indice));  // Asignar la función para validar la respuesta
    }

    fondoBlanco.SetActive(true);  // Mostrar el fondo blanco
    panelPregunta.SetActive(true);  // Mostrar el panel de la pregunta
}
    // Valida si la respuesta seleccionada es correcta
    private void ValidarRespuesta(int indiceSeleccionado)
    {
        if (indiceSeleccionado == indiceRespuestaCorrecta)
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