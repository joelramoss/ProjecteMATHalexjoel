using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public GameObject questionImage;        // Imagen de la pregunta
    public Image win;
    public Image lose;
    public Button[] answerButtons;     // Botones para las respuestas
    private int selectedAnswer;        // Variable para guardar la respuesta seleccionada

    void Start()
    {
        // Desactivar la imagen de la pregunta al inicio (opcional)
        questionImage.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);

        // Asignar las funciones a los botones de respuesta
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int answerIndex = i; // Crear una copia local para usar en la lambda
            answerButtons[i].onClick.AddListener(() => SelectAnswer(answerIndex));
        }
    }

    // Función para mostrar la imagen de la pregunta y las respuestas
    public void ShowQuestion(Sprite questionSprite, string[] answers)
    {
        // Activar la imagen de la pregunta
        questionImage.gameObject.SetActive(true);
        
    

        // Asignar el texto de las respuestas a los botones
        for (int i = 0; i < answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answers[i];
        }
    }

    // Función que guarda el número de la respuesta seleccionada
    public void SelectAnswer(int answerIndex)
    {
        selectedAnswer = answerIndex;
        Debug.Log("Respuesta seleccionada: " + selectedAnswer);

        // Desactivar la imagen de la pregunta después de seleccionar una respuesta (opcional)
        questionImage.gameObject.SetActive(false);
    }

    // Función para ocultar la imagen
    public void HideQuestionImage()
    {
        questionImage.gameObject.SetActive(false);
    }


    public void showWin (){
        if (selectedAnswer == 4){
            win.gameObject.SetActive(true);
        }else{
            lose.gameObject.SetActive(true);
        }
    }
}

