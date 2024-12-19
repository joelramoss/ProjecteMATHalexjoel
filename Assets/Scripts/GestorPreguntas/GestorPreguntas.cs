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

    // Lista de preguntas
    private List<Pregunta> preguntas = new List<Pregunta>();

    private string preguntaActual;
    private string[] opcionesPreguntaActual;
    private int indiceRespuestaCorrecta;

    void Start()
    {
        fondoBlanco.SetActive(false); // Ocultar el fondo al inicio
        panelPregunta.SetActive(false); // Ocultar el panel al inicio

        // Inicializar preguntas
        preguntas.Add(new Pregunta("Quin és el resultat de 5 + 3?", new string[] { "6", "7", "8" }, 2));
        preguntas.Add(new Pregunta("Quin nombre és el doble de 6?", new string[] { "10", "12", "14" }, 1));
        preguntas.Add(new Pregunta("Quant és 12 dividit entre 4?", new string[] { "2", "3", "4" }, 0));
        preguntas.Add(new Pregunta("Si un triangle té un angle de 90°, com s'anomena?", new string[] { "Cercle", "Triangle rectàngul", "Quadrat" }, 0));
        preguntas.Add(new Pregunta("Quin és el valor de π (pi) amb dos decimals?", new string[] { "3.14", "3.15", "3.13" }, 0));
        preguntas.Add(new Pregunta("Si x + 3 = 8, quin és el valor de x?", new string[] { "5", "4", "3" }, 0));
        preguntas.Add(new Pregunta("Quina és l'àrea d'un quadrat amb costats de 4 cm?", new string[] { "16 cm²", "12 cm²", "8 cm²" }, 0));
        preguntas.Add(new Pregunta("Quants graus té un angle recte?", new string[] { "60", "90", "120" }, 1));
        preguntas.Add(new Pregunta("Quant és 15 - 7?", new string[] { "6", "7", "8" }, 0));
        preguntas.Add(new Pregunta("Si un cercle té un radi de 5 cm, quin és el seu diàmetre?", new string[] { "10 cm", "5 cm", "15 cm" }, 0));
        preguntas.Add(new Pregunta("Què és un nombre primer?", new string[] { "Un nombre primer", "Un nombre divisible entre 2", "Un nombre que no té factors" }, 0));
        preguntas.Add(new Pregunta("Quants costats té un hexàgon?", new string[] { "4", "6", "8" }, 1));
        preguntas.Add(new Pregunta("Quin és el resultat de 3 * 6?", new string[] { "18", "20", "16" }, 0));
        preguntas.Add(new Pregunta("Si un rectangle té una base de 10 cm i una alçada de 5 cm, quina és la seva àrea?", new string[] { "50 cm²", "30 cm²", "10 cm²" }, 0));
        preguntas.Add(new Pregunta("Què és un nombre senar?", new string[] { "Un nombre que no es pot dividir entre 2", "Un nombre que sempre és parell", "Un nombre que acaba en 0 o 5" }, 0));
        preguntas.Add(new Pregunta("Quant és 25 dividit entre 5?", new string[] { "3", "4", "5" }, 2));
        preguntas.Add(new Pregunta("Quina és l'arrel quadrada de 49?", new string[] { "7", "6", "9" }, 0));
        preguntas.Add(new Pregunta("Què és el perímetre d'un cercle?", new string[] { "Circumferència", "Àrea", "Perímetre" }, 0));
        preguntas.Add(new Pregunta("Quants graus té un angle obtús?", new string[] { "120", "135", "100" }, 0));
        preguntas.Add(new Pregunta("Com s'anomena la forma amb quatre costats de la mateixa longitud?", new string[] { "Quadrat", "Rectangle", "Rombo" }, 0));
        preguntas.Add(new Pregunta("Quin és el valor de 4²?", new string[] { "16", "8", "4" }, 0));
        preguntas.Add(new Pregunta("Què és una fracció equivalent?", new string[] { "Fracció que representa el mateix valor", "Fracció amb el mateix denominador", "Fracció que es pot simplificar" }, 0));
        preguntas.Add(new Pregunta("Quin és el valor de 3³?", new string[] { "9", "27", "81" }, 1));
        preguntas.Add(new Pregunta("Quants mil·límetres hi ha en un centímetre?", new string[] { "100", "10", "1" }, 1));
        preguntas.Add(new Pregunta("Quants segons hi ha en una hora?", new string[] { "60", "3600", "600" }, 1));
        preguntas.Add(new Pregunta("Quants minuts hi ha en 3 hores?", new string[] { "180", "300", "60" }, 0));
        preguntas.Add(new Pregunta("Si el radi d'un cercle és de 7 cm, quina és la seva àrea?", new string[] { "154 cm²", "153 cm²", "150 cm²" }, 0));
        preguntas.Add(new Pregunta("Què és una equació?", new string[] { "Una igualtat matemàtica", "Una operació", "Una seqüència de nombres" }, 0));
        preguntas.Add(new Pregunta("Què és un nombre compost?", new string[] { "Un nombre divisible entre 3 i 5", "Un nombre divisible entre 1 i ell mateix", "Un nombre divisible entre diversos divisors" }, 2));
        preguntas.Add(new Pregunta("Quin és el resultat de 16 ÷ 2?", new string[] { "8", "6", "7" }, 0));
        preguntas.Add(new Pregunta("Què significa el terme 'mitjana' en estadística?", new string[] { "Mitjana", "Moda", "Mediana" }, 0));
        preguntas.Add(new Pregunta("Si un nombre és divisible entre 2, com se'n diu?", new string[] { "Parell", "Senar", "Divisible per 3" }, 0));
        preguntas.Add(new Pregunta("Què és un angle agut?", new string[] { "Menor de 90", "Major de 90", "Igual a 90" }, 0));
        preguntas.Add(new Pregunta("Com s'anomena un angle de 180°?", new string[] { "Recte", "Agut", "Pla" }, 0));
        preguntas.Add(new Pregunta("Què significa 'sumar' en matemàtiques?", new string[] { "Sumar", "Restar", "Multiplicar" }, 0));
        preguntas.Add(new Pregunta("Què és un nombre racional?", new string[] { "Un nombre enter", "Un nombre que pot ser expressat com una fracció", "Un nombre racional" }, 1));
        preguntas.Add(new Pregunta("Quant és 8 * 7?", new string[] { "56", "54", "64" }, 0));
        preguntas.Add(new Pregunta("Què és un triangle equilàter?", new string[] { "Un triangle equilàter", "Un triangle amb angles rectes", "Un triangle amb angles obtusos" }, 0));
        preguntas.Add(new Pregunta("Quin és el resultat de 9 + 6?", new string[] { "15", "14", "16" }, 0));
        preguntas.Add(new Pregunta("Si un nombre és divisible entre 3, quina propietat té?", new string[] { "Divisible entre 2", "Divisible entre 3", "Divisible entre 5" }, 1));
        preguntas.Add(new Pregunta("Què és un nombre irracional?", new string[] { "Un nombre que té decimals infinits no repetits", "Un nombre que té decimals periòdics", "Un nombre enter" }, 0));
        preguntas.Add(new Pregunta("Com es calcula el perímetre d'un triangle equilàter?", new string[] { "Sumant els tres costats", "Multiplicant els tres costats", "Sumant els costats" }, 0));
        preguntas.Add(new Pregunta("Què significa 'restar' en matemàtiques?", new string[] { "Sumar", "Multiplicar", "Restar" }, 2));
        preguntas.Add(new Pregunta("Què és la propietat distributiva de la multiplicació?", new string[] { "Distributiva", "Associativa", "Commutativa" }, 0));
        preguntas.Add(new Pregunta("Quina és la suma dels angles interns d'un triangle?", new string[] { "180", "360", "90" }, 0));
        preguntas.Add(new Pregunta("Quants decimals té el nombre 1/3?", new string[] { "2", "1", "0" }, 0));
        preguntas.Add(new Pregunta("Com s'anomena el valor d'un nombre en una equació?", new string[] { "Despeje", "Valor", "Resultat" }, 1));
        preguntas.Add(new Pregunta("Què és el mínim comú múltiple (MCM)?", new string[] { "El menor múltiple comú", "El major múltiple comú", "El major divisor comú" }, 0));
        preguntas.Add(new Pregunta("Què és el màxim comú divisor (MCD)?", new string[] { "El major múltiple comú", "El major divisor comú", "El menor múltiple comú" }, 1));
        preguntas.Add(new Pregunta("Quant és 100 ÷ 4?", new string[] { "25", "24", "30" }, 0));
        preguntas.Add(new Pregunta("Com s'anomena la línia que divideix un triangle per la meitat?", new string[] { "Mediana", "Bisectriu", "Alçada" }, 0));
        preguntas.Add(new Pregunta("Què és l'àrea d'un cercle?", new string[] { "Àrea = πr²", "Àrea = 2πr", "Àrea = 4r" }, 0));


        // Verificaciones iniciales
        if (preguntas.Count == 0)
        {
            Debug.LogError("No hay preguntas disponibles.");
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

        if (preguntas.Count == 0)
        {
            Debug.Log("No quedan preguntas disponibles.");
            return;
        }

        // Selecciona una pregunta aleatoria
        int indicePregunta = Random.Range(0, preguntas.Count);
        Pregunta preguntaSeleccionada = preguntas[indicePregunta];
        preguntaActual = preguntaSeleccionada.textoPregunta;
        opcionesPreguntaActual = preguntaSeleccionada.opciones;
        indiceRespuestaCorrecta = preguntaSeleccionada.respuestaCorrecta;

        // Muestra la pregunta
        textoPregunta.text = preguntaActual;

        // Asigna las opciones a los botones
        for (int i = 0; i < botonesOpciones.Length; i++)
        {
            TextMeshProUGUI textoBoton = botonesOpciones[i].GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
            {
                textoBoton.text = opcionesPreguntaActual[i];
                int indice = i; // Captura la variable 'i' correctamente
                botonesOpciones[i].onClick.RemoveAllListeners();
                botonesOpciones[i].onClick.AddListener(() => ValidarRespuesta(indice));
            }
        }

        fondoBlanco.SetActive(true);
        panelPregunta.SetActive(true);
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
}

[System.Serializable]
public class Pregunta
{
    public string textoPregunta;
    public string[] opciones;
    public int respuestaCorrecta;

    public Pregunta(string texto, string[] opciones, int respuestaCorrecta)
    {
        this.textoPregunta = texto;
        this.opciones = opciones;
        this.respuestaCorrecta = respuestaCorrecta;
    }
}
