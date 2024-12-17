using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestorPreguntas : MonoBehaviour
{
    public GameObject fondoBlanco; // Fondo blanco
    public GameObject panelPregunta; // Panel que contiene la pregunta y las opciones
    public Text textoPregunta; // Texto para la pregunta
    public Button[] botonesOpciones;
    public PlayerController playerController;

    private GameObject enemigoActual;


// Las preguntas:
private string[] preguntes = {
    "Quin és el resultat de 5 + 3?",
    "Quin nombre és el doble de 6?",
    "Quant és 12 dividit entre 4?",
    "Si un triangle té un angle de 90°, com s'anomena?",
    "Quin és el valor de π (pi) amb dos decimals?", // Añadida aquí
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
    "Què és l'àrea d'un cercle?",
    "Què és una progressió aritmètica?",
    "Com es calcula el volum d'un cub?",
    "Què és la mediana en un conjunt de dades?",
    "Quants vèrtexs té un cub?",
    "Què és una equació de segon grau?",
    "Què significa 'multiplicar' en matemàtiques?",
    "Quin és el resultat de 4 * 9?",
    "Com s'anomena l'angle major de 90°?",
    "Quants angles rectes té un rectangle?",
    "Què significa 'dividir' en matemàtiques?",
    "Què és la fracció 1/2 en decimal?",
    "Quina és la distància entre dos punts en el pla cartesià?",
    "Què és un nombre decimal?",
    "Com es representa un nombre negatiu?",
    "Què és un angle pla?",
    "Què és una matriu en matemàtiques?",
    "Quants costats té un pentàgon?",
    "Què és una arrel quadrada?",
    "Com s'anomena el resultat de multiplicar un nombre per ell mateix?",
    "Què és el quocient d'una divisió?",
    "Què és la regla de tres simple?",
    "Quina és la funció principal d'un sistema de coordenades cartesianes?",
    "Què és una fracció impròpia?",
    "Quants costats té un dodecàgon?",
    "Què és la simplificació de fraccions?"
};


// Las opciones:
private string[][] opcions = new string[][] {
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
    new string[] { "Àrea = πr²", "Àrea = 2πr", "Àrea = 4r" },
    new string[] { "Una seqüència de nombres", "Una suma de nombres", "Una resta de nombres" },
    new string[] { "Costat³", "Costat²", "Costat*Costat*Costat" },
    new string[] { "La mitjana", "El valor central", "El valor mitjà" },
    new string[] { "6", "8", "4" },
    new string[] { "Una equació quadràtica", "Una equació amb dues incògnites", "Una equació de tercer grau" },
    new string[] { "Sumar", "Multiplicar", "Restar" },
    new string[] { "24", "36", "48" },
    new string[] { "Obtús", "Recte", "Agut" },
    new string[] { "2", "4", "3" },
    new string[] { "Restar", "Dividir", "Sumar" },
    new string[] { "0.5", "1", "2" },
    new string[] { "Per la distància entre els punts", "Usant les coordenades", "Per la distància dels eixos" },
    new string[] { "Un nombre amb coma decimal", "Un nombre amb punt decimal", "Un nombre sense coma decimal" },
    new string[] { "Amb el signe negatiu", "Amb el signe positiu", "Amb punt decimal" },
    new string[] { "180", "90", "360" },
    new string[] { "Una matriu és una taula", "Un conjunt de nombres organitzats", "Una seqüència matemàtica" },
    new string[] { "5", "6", "4" },
    new string[] { "El nombre que es multiplica per ell mateix", "El nombre que té arrel quadrada", "El nombre que s'eleva a 2" },
    new string[] { "Quadrat", "Exponencial", "Producte" },
    new string[] { "El quocient", "El divisor", "El numerador" },
    new string[] { "Una regla de proporcions", "Una regla de càlcul", "Una regla de tres" },
    new string[] { "Ubicar punts", "Establir relacions", "Dividir eixos" },
    new string[] { "Fracció major que 1", "Fracció menor que 1", "Fracció que no es pot simplificar" },
    new string[] { "10", "12", "14" },
    new string[] { "Fer més petita una fracció", "Dividir una fracció", "Substituir un denominador" }
};


private int[] respostesCorrectes = {
    2,  // Quin és el resultat de 5 + 3? (Respuesta: 8)
    1,  // Quin nombre és el doble de 6? (Respuesta: 12)
    1,  // Quant és 12 dividit entre 4? (Respuesta: 3)
    1,  // Si un triangle té un angle de 90, com s'anomena? (Respuesta: Triangle rectàngul)
    0,  // Quin és el valor de pi amb dos decimals? (Respuesta: 3.14)
    0,  // Si x + 3 = 8, quin és el valor de x? (Respuesta: 5)
    0,  // Quina és l'àrea d'un quadrat amb costats de 4 cm? (Respuesta: 16 cm²)
    1,  // Quants graus té un angle recte? (Respuesta: 90)
    2,  // Quant és 15 - 7? (Respuesta: 8)
    0,  // Si un cercle té un radi de 5 cm, quin és el seu diàmetre? (Respuesta: 10 cm)
    0,  // Què és un nombre primer? (Respuesta: Un nombre primer)
    1,  // Quants costats té un hexàgon? (Respuesta: 6)
    2,  // Quin és el resultat de 3 * 6? (Respuesta: 18)
    1,  // Si un rectangle té una base de 10 cm i una alçada de 5 cm, quina és la seva àrea? (Respuesta: 50 cm²)
    0,  // Què és un nombre senar? (Respuesta: Un nombre que no es pot dividir entre 2)
    2,  // Quant és 25 dividit entre 5? (Respuesta: 5)
    0,  // Quina és l'arrel quadrada de 49? (Respuesta: 7)
    2,  // Què és el perímetre d'un cercle? (Respuesta: Perímetre)
    0,  // Quants graus té un angle obtús? (Respuesta: 120)
    0,  // Com s'anomena la forma amb quatre costats de la mateixa longitud? (Respuesta: Quadrat)
    0,  // Quin és el valor de 4²? (Respuesta: 16)
    0,  // Què és una fracció equivalent? (Respuesta: Fracció que representa el mateix valor)
    1,  // Quin és el valor de 3³? (Respuesta: 27)
    0,  // Quants mil·límetres hi ha en un centímetre? (Respuesta: 10)
    1,  // Quants segons hi ha en una hora? (Respuesta: 3600)
    0,  // Quants minuts hi ha en 3 hores? (Respuesta: 180)
    1,  // Si el radi d'un cercle és de 7 cm, quina és la seva àrea? (Respuesta: 154 cm²)
    0,  // Què és una equació? (Respuesta: Una igualtat matemàtica)
    1,  // Què és un nombre compost? (Respuesta: Un nombre divisible entre 1 i ell mateix)
    0,  // Quin és el resultat de 16 ÷ 2? (Respuesta: 8)
    0,  // Què significa el terme 'mitjana' en estadística? (Respuesta: Mitjana)
    1,  // Si un nombre és divisible entre 2, com se'n diu? (Respuesta: Senar)
    0,  // Què és un angle agut? (Respuesta: Menor de 90)
    0,  // Com s'anomena un angle de 180? (Respuesta: Recte)
    0,  // Què significa 'sumar' en matemàtiques? (Respuesta: Sumar)
    1,  // Què és un nombre racional? (Respuesta: Un nombre que pot ser expressat com una fracció)
    2,  // Quant és 8 * 7? (Respuesta: 56)
    0,  // Què és un triangle equilàter? (Respuesta: Un triangle amb costats iguals)
    0,  // Quin és el resultat de 9 + 6? (Respuesta: 15)
    1,  // Si un nombre és divisible entre 3, quina propietat té? (Respuesta: Divisible entre 3)
    0,  // Què és un nombre irracional? (Respuesta: Un nombre que té decimals infinits no repetits)
    0,  // Com es calcula el perímetre d'un triangle equilàter? (Respuesta: Sumant els tres costats)
    0,  // Què significa 'restar' en matemàtiques? (Respuesta: Restar)
    0,  // Què és la propietat distributiva de la multiplicació? (Respuesta: Distributiva)
    0,  // Quina és la suma dels angles interns d'un triangle? (Respuesta: 180)
    1,  // Quants decimals té el nombre 1/3? (Respuesta: 2)
    0,  // Com s'anomena el valor d'un nombre en una equació? (Respuesta: Valor)
    0,  // Què és el mínim comú múltiple? (Respuesta: El menor múltiple comú)
    1,  // Què és el màxim comú divisor? (Respuesta: El major divisor comú)
    0,  // Quant és 100 ÷ 4? (Respuesta: 25)
    0,  // Com s'anomena la línia que divideix un triangle per la meitat? (Respuesta: Bisectriu)
    0,  // Què és l'àrea d'un cercle? (Respuesta: Àrea = πr²)
    0,  // Què és una progressió aritmètica? (Respuesta: Una seqüència de nombres)
    0,  // Com es calcula el volum d'un cub? (Respuesta: Costat³)
    1,  // Què és la mediana en un conjunt de dades? (Respuesta: El valor central)
    0,  // Quants vèrtexs té un cub? (Respuesta: 6)
    0,  // Què és una equació de segon grau? (Respuesta: Una equació quadràtica)
    1,  // Quin és el resultat de 4 * 9? (Respuesta: 36)
    1,  // Com s'anomena l'angle major de 90? (Respuesta: Obtús)
    0,  // Quants angles rectes té un rectangle? (Respuesta: 2)
    0,  // Què significa 'dividir' en matemàtiques? (Respuesta: Dividir)
    1,  // Què és la fracció 1/2 en decimal? (Respuesta: 0.5)
    0,  // Quina és la distància entre dos punts en el pla cartesià? (Respuesta: Usant les coordenades)
    0,  // Què és un nombre decimal? (Respuesta: Un nombre amb coma decimal)
    0,  // Com es representa un nombre negatiu? (Respuesta: Amb el signe negatiu)
    0,  // Què és un angle pla? (Respuesta: 180)
    1,  // Què és una matriu en matemàtiques? (Respuesta: Un conjunt de nombres organitzats)
    0,  // Quants costats té un pentàgon? (Respuesta: 5)
    0,  // Què és una arrel quadrada? (Respuesta: El nombre que té arrel quadrada)
    0,  // Com s'anomena el resultat de multiplicar un nombre per ell mateix? (Respuesta: Quadrat)
    0,  // Què és el quocient d'una divisió? (Respuesta: El quocient)
    0,  // Què és la regla de tres simple? (Respuesta: Una regla de proporcions)
    0,  // Quina és la funció principal d'un sistema de coordenades cartesianes? (Respuesta: Ubicar punts)
    1,  // Què és una fracció impròpia? (Respuesta: Fracció major que 1)
    0,  // Quants costats té un dodecàgon? (Respuesta: 12)
    0   // Què és la simplificació de fraccions? (Respuesta: Fer més petita una fracció)
};


    private string preguntaActual;
    private string[] opcionesPreguntaActual;
    private int indiceRespuestaCorrecta;

    void Start()
    {
        fondoBlanco.SetActive(false); // Ocultar el fondo al inicio
        panelPregunta.SetActive(false); // Ocultar el panel al inicio

        // Verificar si la referencia al PlayerController está asignada correctamente
        playerController = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("No se encontró un objeto llamado 'Player' o no tiene el componente PlayerController.");
            return;
        }

        // Verificar que el número de preguntas y opciones coincida
        if (preguntes.Length != opcions.Length)
        {
            Debug.LogError(preguntes.Length);
            Debug.LogError(opcions.Length);  // Salir si no coinciden
            Debug.LogError("El número de preguntas no coincide con el número de opciones.");
            return; // Salir si no coinciden
        }

        // Verificar que el número de respuestas correctas coincida con el número de preguntas
        if (preguntes.Length != respostesCorrectes.Length)
        {
            Debug.LogError(preguntes.Length);
            Debug.LogError(respostesCorrectes.Length);
            Debug.LogError("El número de respuestas correctas no coincide con el número de preguntas.");
            return; // Salir si no coinciden
        }
    }
    public void MostrarPregunta(GameObject enemigo)
    {
        enemigoActual = enemigo;
        // Verificar que el array de preguntas no esté vacío
        if (preguntes.Length == 0)
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

        // Verificar que fondoBlanco, panelPregunta, y textoPregunta están asignados
        if (fondoBlanco == null || panelPregunta == null || textoPregunta == null)
        {
            Debug.LogError("Uno de los elementos UI no está asignado en el Inspector.");
            return;  // Salir si algún UI no está asignado
        }

        // Seleccionar una pregunta aleatoria
        int indicePregunta = Random.Range(0, preguntes.Length);
        preguntaActual = preguntes[indicePregunta];
        opcionesPreguntaActual = opcions[indicePregunta];
        indiceRespuestaCorrecta = respostesCorrectes[indicePregunta];

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

        // Eliminar solo al enemigo actual
        if (enemigoActual != null)
        {
            Destroy(enemigoActual.gameObject); // Destruir al enemigo actual
            Debug.Log("Enemigo eliminado correctamente.");
            enemigoActual = null; // Limpiar la referencia
        }
        else
        {
            Debug.LogError("No hay un enemigo actual asignado para eliminar.");
        }
    }
    else
    {
        Debug.Log("Respuesta incorrecta.");
        playerController.vida -= 1; // Restar una vida si la respuesta es incorrecta
    }

    // Ocultar el fondo y el panel después de responder
    fondoBlanco.SetActive(false);
    panelPregunta.SetActive(false);
}

    internal void MostrarPregunta(Dragon_Controller1 dragon_Controller1)
    {
        throw new System.NotImplementedException();
    }
}