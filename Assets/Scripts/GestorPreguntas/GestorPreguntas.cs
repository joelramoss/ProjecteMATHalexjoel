using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GestorPreguntas : MonoBehaviour
{
    public GameObject fondoBlanco; // Fondo blanco
    public GameObject panelPregunta; // Panel que contiene la pregunta y las opciones
    public Text textoPregunta; // Texto para la pregunta
    public Button[] botonesOpciones;
    public PlayerController playerController;

    private GameObject enemigoActual;

    // Listas dinámicas para manejar las preguntas
    private List<string> preguntes;
    private List<string[]> opcions;
    private List<int> respostesCorrectes;

    private string preguntaActual;
    private string[] opcionesPreguntaActual;
    private int indiceRespuestaCorrecta;

    void Start()
    {
        fondoBlanco.SetActive(false); // Ocultar el fondo al inicio
        panelPregunta.SetActive(false); // Ocultar el panel al inicio

        // Inicializar listas dinámicas y copiar valores
        preguntes = new List<string>(new string[]
        {
            "Quin és el resultat de 5 + 3?",
            "Quin nombre és el doble de 6?",
            "Quant és 12 dividit entre 4?",
            "Si un triangle té un angle de 90°, com s'anomena?",
            "Quin és el valor de π (pi) amb dos decimals?",
            "Si x + 3 = 8, quin és el valor de x?",
            "Quina és l'àrea d'un quadrat amb costats de 4 cm?",
            "Quants graus té un angle recte?",
            "Quant és 15 - 7?",
            "Si un cercle té un radi de 5 cm, quin és el seu diàmetre?",
            "Què és un nombre primer?",
            "Quants costats té un hexàgon?",
            "Quin és el resultat de 3 * 6?",
            "Si un rectangle té una base de 10 cm i una alçada de 5 cm, quina és la seva àrea?",
            "Què és un nombre senar?",
            "Quant és 25 dividit entre 5?",
            "Quina és l'arrel quadrada de 49?",
            "Què és el perímetre d'un cercle?",
            "Quants graus té un angle obtús?",
            "Com s'anomena la forma amb quatre costats de la mateixa longitud?",
            "Quin és el valor de 4²?",
            "Què és una fracció equivalent?",
            "Quin és el valor de 3³?",
            "Quants mil·límetres hi ha en un centímetre?",
            "Quants segons hi ha en una hora?",
            "Quants minuts hi ha en 3 hores?",
            "Si el radi d'un cercle és de 7 cm, quina és la seva àrea?",
            "Què és una equació?",
            "Què és un nombre compost?",
            "Quin és el resultat de 16 ÷ 2?",
            "Què significa el terme 'mitjana' en estadística?",
            "Si un nombre és divisible entre 2, com se'n diu?",
            "Què és un angle agut?",
            "Com s'anomena un angle de 180°?",
            "Què significa 'sumar' en matemàtiques?",
            "Què és un nombre racional?",
            "Quant és 8 * 7?",
            "Què és un triangle equilàter?",
            "Quin és el resultat de 9 + 6?",
            "Si un nombre és divisible entre 3, quina propietat té?",
            "Què és un nombre irracional?",
            "Com es calcula el perímetre d'un triangle equilàter?",
            "Què significa 'restar' en matemàtiques?",
            "Què és la propietat distributiva de la multiplicació?",
            "Quina és la suma dels angles interns d'un triangle?",
            "Quants decimals té el nombre 1/3?",
            "Com s'anomena el valor d'un nombre en una equació?",
            "Què és el mínim comú múltiple (MCM)?",
            "Què és el màxim comú divisor (MCD)?",
            "Quant és 100 ÷ 4?",
            "Com s'anomena la línia que divideix un triangle per la meitat?",
            "Què és l'àrea d'un cercle?"
        });

        opcions = new List<string[]>(new string[][]
        {
            new string[] { "6", "7", "8" },
            new string[] { "10", "12", "14" },
            new string[] { "2", "3", "4" },
            new string[] { "Cercle", "Triangle rectàngul", "Quadrat" },
            new string[] { "3.14", "3.15", "3.13" },
            new string[] { "5", "4", "3" },
            new string[] { "16 cm²", "12 cm²", "8 cm²" },
            new string[] { "60", "90", "120" },
            new string[] { "6", "7", "8" },
            new string[] { "10 cm", "5 cm", "15 cm" },
            new string[] { "Un nombre primer", "Un nombre divisible entre 2", "Un nombre que no té factors" },
            new string[] { "4", "6", "8" },
            new string[] { "18", "20", "16" },
            new string[] { "50 cm²", "30 cm²", "10 cm²" },
            new string[] { "Un nombre que no es pot dividir entre 2", "Un nombre que sempre és parell", "Un nombre que acaba en 0 o 5" },
            new string[] { "3", "4", "5" },
            new string[] { "7", "6", "9" },
            new string[] { "Circumferència", "Àrea", "Perímetre" },
            new string[] { "120", "135", "100" },
            new string[] { "Quadrat", "Rectangle", "Rombo" },
            new string[] { "16", "8", "4" },
            new string[] { "Fracció que representa el mateix valor", "Fracció amb el mateix denominador", "Fracció que es pot simplificar" },
            new string[] { "9", "27", "81" },
            new string[] { "100", "10", "1" },
            new string[] { "60", "3600", "600" },
            new string[] { "180", "300", "60" },
            new string[] { "154 cm²", "153 cm²", "150 cm²" },
            new string[] { "Una igualtat matemàtica", "Una operació", "Una seqüència de nombres" },
            new string[] { "Un nombre divisible entre 3 i 5", "Un nombre divisible entre 1 i ell mateix", "Un nombre divisible entre diversos divisors" },
            new string[] { "8", "6", "7" },
            new string[] { "Mitjana", "Moda", "Mediana" },
            new string[] { "Parell", "Senar", "Divisible per 3" },
            new string[] { "Menor de 90", "Major de 90", "Igual a 90" },
            new string[] { "Recte", "Agut", "Pla" },
            new string[] { "Sumar", "Restar", "Multiplicar" },
            new string[] { "Un nombre enter", "Un nombre que pot ser expressat com una fracció", "Un nombre racional" },
            new string[] { "56", "54", "64" },
            new string[] { "Un triangle equilàter", "Un triangle amb angles rectes", "Un triangle amb angles obtusos" },
            new string[] { "15", "14", "16" },
            new string[] { "Divisible entre 2", "Divisible entre 3", "Divisible entre 5" },
            new string[] { "Un nombre que té decimals infinits no repetits", "Un nombre que té decimals periòdics", "Un nombre enter" },
            new string[] { "Sumant els tres costats", "Multiplicant els tres costats", "Sumant els costats" },
            new string[] { "Sumar", "Multiplicar", "Restar" },
            new string[] { "Distributiva", "Associativa", "Commutativa" },
            new string[] { "180", "360", "90" },
            new string[] { "2", "1", "0" },
            new string[] { "Despeje", "Valor", "Resultat" },
            new string[] { "El menor múltiple comú", "El major múltiple comú", "El major divisor comú" },
            new string[] { "El major múltiple comú", "El major divisor comú", "El menor múltiple comú" },
            new string[] { "25", "24", "30" },
            new string[] { "Mediana", "Bisectriu", "Alçada" },
            new string[] { "Àrea = πr²", "Àrea = 2πr", "Àrea = 4r" }
        });

        respostesCorrectes = new List<int>(new int[]
        {
            2, 1, 1, 1, 0, 0, 0, 1, 2, 0, 0, 1, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0
        });
        // Verificaciones iniciales
        if (preguntes.Count != opcions.Count || opcions.Count != respostesCorrectes.Count)
        {
            Debug.LogError("El número de preguntas, opciones y respuestas correctas no coincide.");
            Debug.LogError("El número de preguntas: " + preguntes.Count);
            Debug.LogError("El número de opciones: " + opcions.Count);
            Debug.LogError("El número de respuestas correctas: " + respostesCorrectes.Count);

            return;
        }

        // Verificar si la referencia al PlayerController está asignada correctamente
        playerController = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("No se encontró un objeto llamado 'Player' o no tiene el componente PlayerController.");
            return;
        }
    }

public void MostrarPregunta(GameObject enemigo)
{
    enemigoActual = enemigo;

    if (preguntes.Count == 0)
    {
        Debug.Log("No quedan preguntas disponibles.");
        return;
    }

    int indicePregunta = Random.Range(0, preguntes.Count);

    preguntaActual = preguntes[indicePregunta];
    opcionesPreguntaActual = opcions[indicePregunta];
    indiceRespuestaCorrecta = respostesCorrectes[indicePregunta];

    textoPregunta.text = preguntaActual;

    for (int i = 0; i < botonesOpciones.Length; i++)
    {
        TextMeshProUGUI textoBoton = botonesOpciones[i].GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton != null)
        {
            textoBoton.text = opcionesPreguntaActual[i];
            int indice = i;
            botonesOpciones[i].onClick.RemoveAllListeners();
            botonesOpciones[i].onClick.AddListener(() => ValidarRespuesta(indice));
        }
    }

    fondoBlanco.SetActive(true);
    panelPregunta.SetActive(true);

    // Eliminar la pregunta usada
    preguntes.RemoveAt(indicePregunta);
    opcions.RemoveAt(indicePregunta);
    respostesCorrectes.RemoveAt(indicePregunta);
}



    private void ValidarRespuesta(int indiceSeleccionado)
    {
        if (indiceSeleccionado == indiceRespuestaCorrecta)
        {
            Debug.Log("¡Respuesta correcta!");
            if (enemigoActual != null)
            {
                Destroy(enemigoActual.gameObject);
                Debug.Log("Enemigo eliminado correctamente.");
                enemigoActual = null;
            }
            else
            {
                Debug.LogError("No hay un enemigo actual asignado para eliminar.");
            }
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
            playerController.vida -= 1;
        }

        fondoBlanco.SetActive(false);
        panelPregunta.SetActive(false);
    }

    internal void MostrarPregunta(Dragon_Controller1 dragon_Controller1)
    {
        throw new System.NotImplementedException();
    }
}