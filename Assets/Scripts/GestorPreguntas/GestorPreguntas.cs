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

    private Enemigo_Controller enemigoActual;


    // Definición de preguntas, opciones y respuestas correctas directamente en este script
    private string[] preguntes = {
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

    private string[][] opcions = new string[][] {
    new string[] { "6", "7", "8" },
    new string[] { "10", "12", "14" },
    new string[] { "2", "3", "4" },
    new string[] { "Cercle", "Triangle", "Quadrat" },
    new string[] { "3.14", "3.15", "3.13" },
    new string[] { "5", "4", "3" },
    new string[] { "16 cm²", "12 cm²", "8 cm²" },
    new string[] { "60°", "90°", "120°" },
    new string[] { "6", "7", "8" },
    new string[] { "10 cm", "5 cm", "15 cm" },
    new string[] { "Un nombre que només té dos divisors", "Un nombre divisible entre 2", "Un nombre que no té factors" },
    new string[] { "4", "6", "8" },
    new string[] { "18", "20", "16" },
    new string[] { "50 cm²", "30 cm²", "10 cm²" },
    new string[] { "Un nombre que no es pot dividir entre 2", "Un nombre que sempre és parell", "Un nombre que acaba en 0 o 5" },
    new string[] { "3", "4", "5" },
    new string[] { "7", "6", "9" },
    new string[] { "Circumferència", "Àrea", "Perímetre" },
    new string[] { "120°", "135°", "100°" },
    new string[] { "Quadrat", "Rectangle", "Rombe" },
    new string[] { "16", "8", "4" },
    new string[] { "Fracció que representa el mateix valor", "Fracció amb el mateix denominador", "Fracció que es pot simplificar" },
    new string[] { "9", "27", "81" },
    new string[] { "100", "10", "1" },
    new string[] { "60", "3600", "600" },
    new string[] { "180", "300", "60" },
    new string[] { "154 cm²", "153 cm²", "150 cm²" },
    new string[] { "Una igualtat matemàtica", "Una operació", "Una seqüència de nombres" },
    new string[] { "Un nombre divisible per 3 i 5", "Un nombre divisible entre 1 i ell mateix", "Un nombre divisible entre diversos divisors" },
    new string[] { "8", "6", "7" },
    new string[] { "Mitjana", "Moda", "Mediana" },
    new string[] { "Parell", "Senar", "Divisible per 3" },
    new string[] { "Menor de 90°", "Major de 90°", "Igual a 90°" },
    new string[] { "Recte", "Agut", "Pla" },
    new string[] { "Sumar", "Restar", "Multiplicar" },
    new string[] { "Un nombre enter", "Un nombre que pot ser expressat com una fracció", "Un nombre que té decimals" },
    new string[] { "56", "54", "64" },
    new string[] { "Un triangle amb costats iguals", "Un triangle amb angles rectes", "Un triangle amb angles obtusos" },
    new string[] { "15", "14", "16" },
    new string[] { "Divisible entre 2", "Divisible entre 3", "Divisible entre 5" },
    new string[] { "Un nombre que té decimals infinits no repetits", "Un nombre que té decimals periòdics", "Un nombre enter" },
    new string[] { "Sumant els tres costats", "Multiplicant els tres costats", "Multiplicant el perímetre per 3" },
    new string[] { "Sumar", "Multiplicar", "Restar" },
    new string[] { "Distributiva", "Associativa", "Commutativa" },
    new string[] { "180°", "360°", "90°" },
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
    new string[] { "180°", "90°", "360°" },
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
    2,  // Pregunta 1: ¿Cuál es el resultado de 5 + 3? (Respuesta correcta: 8)
    1,  // Pregunta 2: ¿Qué número es el doble de 6? (Respuesta correcta: 12)
    0,  // Pregunta 3: ¿Cuánto es 12 dividido entre 4? (Respuesta correcta: 3)
    0,  // Pregunta 4: Si un triángulo tiene un ángulo de 90°, ¿cómo se llama? (Respuesta correcta: Triángulo rectángulo)
    2,  // Pregunta 5: ¿Cuál es el valor de π (pi) con dos decimales? (Respuesta correcta: 3.14)
    0,  // Pregunta 6: Si x + 3 = 8, ¿cuál es el valor de x? (Respuesta correcta: x = 5)
    1,  // Pregunta 7: ¿Cuál es el área de un cuadrado con lados de 4 cm? (Respuesta correcta: 16 cm²)
    0,  // Pregunta 8: ¿Cuántos grados tiene un ángulo recto? (Respuesta correcta: 90°)
    1,  // Pregunta 9: ¿Cuánto es 15 - 7? (Respuesta correcta: 8)
    1,  // Pregunta 10: Si un círculo tiene un radio de 5 cm, ¿cuál es su diámetro? (Respuesta correcta: 10 cm)
    0,  // Pregunta 11: ¿Qué es un número primo? (Respuesta correcta: Un número primo solo puede dividirse entre 1 y él mismo)
    1,  // Pregunta 12: ¿Cuántos lados tiene un hexágono? (Respuesta correcta: 6)
    1,  // Pregunta 13: ¿Cuál es el resultado de 3 * 6? (Respuesta correcta: 18)
    1,  // Pregunta 14: Si un rectángulo tiene una base de 10 cm y una altura de 5 cm, ¿cuál es su área? (Respuesta correcta: 50 cm²)
    0,  // Pregunta 15: ¿Qué es un número impar? (Respuesta correcta: No es divisible entre 2)
    0,  // Pregunta 16: ¿Cuánto es 25 dividido entre 5? (Respuesta correcta: 5)
    0,  // Pregunta 17: ¿Cuál es la raíz cuadrada de 49? (Respuesta correcta: 7)
    1,  // Pregunta 18: ¿Qué es el perímetro de un círculo? (Respuesta correcta: No se calcula de esa forma)
    2,  // Pregunta 19: ¿Cuántos grados tiene un ángulo obtuso? (Respuesta correcta: Más de 90°)
    0,  // Pregunta 20: ¿Cómo se llama la forma con cuatro lados de igual longitud? (Respuesta correcta: Cuadrado)
    0,  // Pregunta 21: ¿Cuál es el valor de 4²? (Respuesta correcta: 16)
    0,  // Pregunta 22: ¿Qué es una fracción equivalente? (Respuesta correcta: 2/4 ≈ 1/2)
    2,  // Pregunta 23: ¿Cuál es el valor de 3³? (Respuesta correcta: 27)
    0,  // Pregunta 24: ¿Cuántos milímetros hay en un centímetro? (Respuesta correcta: 10 mm)
    0,  // Pregunta 25: ¿Cuántos segundos hay en una hora? (Respuesta correcta: 3600 segundos)
    1,  // Pregunta 26: ¿Cuántos minutos hay en 3 horas? (Respuesta correcta: 180 minutos)
    0,  // Pregunta 27: Si el radio de un círculo es 7 cm, ¿cuál es su área? (Respuesta correcta: 3.14 * 7² ≈ 154 cm²)
    0,  // Pregunta 28: ¿Qué es una ecuación? (Respuesta correcta: Una ecuación con una incógnita)
    1,  // Pregunta 29: ¿Qué es un número compuesto? (Respuesta correcta: Tiene más de dos divisores)
    0,  // Pregunta 30: ¿Cuál es el resultado de 16 ÷ 2? (Respuesta correcta: 8)
    0,  // Pregunta 31: ¿Qué significa el término 'media' en estadística? (Respuesta correcta: Valor promedio)
    0,  // Pregunta 32: Si un número es divisible entre 2, ¿cómo se le llama? (Respuesta correcta: Par)
    0,  // Pregunta 33: ¿Qué es un ángulo agudo? (Respuesta correcta: Menor de 90°)
    0,  // Pregunta 34: ¿Cómo se llama un ángulo de 180°? (Respuesta correcta: Ángulo recto)
    1,  // Pregunta 35: ¿Qué significa 'sumar' en matemáticas? (Respuesta correcta: Encontrar el total)
    1,  // Pregunta 36: ¿Qué es un número racional? (Respuesta correcta: Fracción de dos enteros)
    1,  // Pregunta 37: ¿Cuánto es 8 * 7? (Respuesta correcta: 56)
    0,  // Pregunta 38: ¿Qué es un triángulo equilátero? (Respuesta correcta: Triángulo con tres lados iguales)
    0,  // Pregunta 39: ¿Cuál es el resultado de 9 + 6? (Respuesta correcta: 15)
    0,  // Pregunta 40: Si un número es divisible entre 3, ¿qué propiedad tiene? (Respuesta correcta: Si la suma de los dígitos es divisible entre 3)
    1,  // Pregunta 41: ¿Qué es un número irracional? (Respuesta correcta: No se puede escribir como fracción)
    0,  // Pregunta 42: ¿Cómo se calcula el perímetro de un triángulo equilátero? (Respuesta correcta: Perímetro = 3 * lado)
    1,  // Pregunta 43: ¿Qué significa 'restar' en matemáticas? (Respuesta correcta: Quitar o reducir)
    0,  // Pregunta 44: ¿Qué es la propiedad distributiva de la multiplicación? (Respuesta correcta: Aplica en multiplicación)
    0,  // Pregunta 45: ¿Cuál es la suma de los ángulos internos de un triángulo? (Respuesta correcta: 180°)
    0,  // Pregunta 46: ¿Cuántos decimales tiene el número 1/3? (Respuesta correcta: Aproximadamente 0.3333)
    0,  // Pregunta 47: ¿Cómo se llama el valor de un número en una ecuación? (Respuesta correcta: Número de variable)
    0,  // Pregunta 48: ¿Qué es el mínimo común múltiplo (MCM)? (Respuesta correcta: El menor múltiplo común)
    1,  // Pregunta 49: ¿Qué es el máximo común divisor (MCD)? (Respuesta correcta: El mayor divisor común)
    0,  // Pregunta 50: ¿Cuánto es 100 ÷ 4? (Respuesta correcta: 25)
    0,  // Pregunta 51: ¿Cómo se llama la línea que divide a un triángulo por su mitad? (Respuesta correcta: Mediana)
    0,  // Pregunta 52: ¿Qué es el área de un círculo? (Respuesta correcta: Área = π * radio²)
    0,  // Pregunta 53: ¿Qué es una progresión aritmética? (Respuesta correcta: Secuencia con diferencia constante)
    0,  // Pregunta 54: ¿Cómo se calcula el volumen de un cubo? (Respuesta correcta: Volumen = lado³)
    1,  // Pregunta 55: ¿Qué es la mediana en un conjunto de datos? (Respuesta correcta: El valor central)
    0,  // Pregunta 56: ¿Cuántos vértices tiene un cubo? (Respuesta correcta: 8 vértices)
    0,  // Pregunta 57: ¿Qué es una ecuación de segundo grado? (Respuesta correcta: Segunda potencia de un número)
    1,  // Pregunta 58: ¿Qué significa 'multiplicar' en matemáticas? (Respuesta correcta: Obtener el cociente)
    0,  // Pregunta 59: ¿Cuál es el resultado de 4 * 9? (Respuesta correcta: 36)
    0,  // Pregunta 60: ¿Cómo se llama el ángulo mayor de 90°? (Respuesta correcta: Ángulo obtuso)
    0,  // Pregunta 61: ¿Cuántos ángulos rectos tiene un rectángulo? (Respuesta correcta: 4 ángulos rectos)
    0,  // Pregunta 62: ¿Qué significa 'dividir' en matemáticas? (Respuesta correcta: Distribuir equitativamente)
    0,  // Pregunta 63: ¿Qué es la fracción 1/2 en decimal? (Respuesta correcta: 0.5)
    1,  // Pregunta 64: ¿Cuál es la distancia entre dos puntos en el plano cartesiano? (Respuesta correcta: Usando las coordenadas)
    0,  // Pregunta 65: ¿Qué es un número decimal? (Respuesta correcta: Un número con punto decimal)
    1,  // Pregunta 66: ¿Cómo se representa un número negativo? (Respuesta correcta: Con el signo negativo)
    0,  // Pregunta 67: ¿Qué es un ángulo llano? (Respuesta correcta: 180°)
    0,  // Pregunta 68: ¿Qué es una matriz en matemáticas? (Respuesta correcta: Una tabla organizada)
    0,  // Pregunta 69: ¿Cuántos lados tiene un pentágono? (Respuesta correcta: 5)
    1,  // Pregunta 70: ¿Qué es una raíz cuadrada? (Respuesta correcta: El número que se multiplica por sí mismo)
    1,  // Pregunta 71: ¿Cómo se llama el resultado de multiplicar un número por sí mismo? (Respuesta correcta: Cuadrado)
    0,  // Pregunta 72: ¿Qué es el cociente de una división? (Respuesta correcta: El resultado de la división)
    0,  // Pregunta 73: ¿Qué es la regla de tres simple? (Respuesta correcta: Relación de tres números)
    0,  // Pregunta 74: ¿Cuál es la función principal de un sistema de coordenadas cartesianas? (Respuesta correcta: Ayuda a ubicar puntos)
    0,  // Pregunta 75: ¿Qué es una fracción impropia? (Respuesta correcta: Fracción con numerador mayor)
    1,  // Pregunta 76: ¿Cuántos lados tiene un dodecágono? (Respuesta correcta: 12 lados)
    0   // Pregunta 77: ¿Qué es la simplificación de fracciones? (Respuesta correcta: Reducir a su mínima expresión)
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
    public void MostrarPregunta(Enemigo_Controller enemigo)
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



}