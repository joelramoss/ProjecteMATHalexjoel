using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public Button startButton;              // Botón para iniciar la pregunta
    public Image questionImageButton;       // Imagen que muestra la pregunta
    public Image win;                       // Imagen para mostrar si la respuesta es correcta
    public Image lose;                      // Imagen para mostrar si la respuesta es incorrecta
    public Button[] answerButtons;          // Botones para las respuestas
    private int selectedAnswer;             // Variable para guardar la respuesta seleccionada
    private int correctAnswerIndex = 0;     // Establecer el índice correcto de la respuesta

    void Start()
    {
        // Inicializar las imágenes y desactivarlas al inicio
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        questionImageButton.gameObject.SetActive(false); // Ocultar la imagen de la pregunta

        // Asignar listener al botón de inicio
        startButton.onClick.AddListener(ShowQuestion);

        // Inicializar los botones de respuesta
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.AddListener(() => SelectAnswer(System.Array.IndexOf(answerButtons, button)));
        }
    }

    // Función para mostrar la pregunta y las respuestas
    // Función para mostrar la pregunta y las respuestas
public void ShowQuestion()
{
    // Comprobar si la imagen de la pregunta está asignada
    if (questionImageButton == null)
    {
        Debug.LogError("La imagen de la pregunta no está asignada.");
        return;
    }
    
    // Mostrar la imagen de la pregunta
    questionImageButton.gameObject.SetActive(true); 

    // Ejemplo de respuestas (ajusta esto según tus preguntas)
    string[] answers = { "5", "4", "6" };
    correctAnswerIndex = 4; // Establece el índice de la respuesta correcta aquí

    // Asignar el texto de las respuestas a los botones y activarlos
    for (int i = 0; i < answers.Length; i++)
    {
        if (i < answerButtons.Length)
        {
            var button = answerButtons[i];
            if (button == null)
            {
                Debug.LogError("Uno de los botones de respuesta no está asignado.");
                continue; // Saltar a la siguiente iteración si el botón es nulo
            }
            
            button.GetComponentInChildren<Text>().text = answers[i];
            button.gameObject.SetActive(true); // Activar el botón de respuesta
        }
        else
        {
            Debug.LogError("Hay más respuestas que botones disponibles.");
        }
    }

    // Desactivar el botón de inicio si es necesario
    startButton.gameObject.SetActive(false);
}


    // Función que guarda el número de la respuesta seleccionada
    public void SelectAnswer(int answerIndex)
    {
        selectedAnswer = answerIndex;
        Debug.Log("Respuesta seleccionada: " + selectedAnswer);

        // Desactivar los botones de respuesta
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Mostrar el resultado
        ShowResult();
    }

    // Función para mostrar si la respuesta seleccionada es correcta o incorrecta
    public void ShowResult()
    {
        if (selectedAnswer == correctAnswerIndex)
        {
            win.gameObject.SetActive(true);
            lose.gameObject.SetActive(false);
        }
        else
        {
            lose.gameObject.SetActive(true);
            win.gameObject.SetActive(false);
        }
    }
}
