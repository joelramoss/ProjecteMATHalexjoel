[System.Serializable]
public class Preguntas
{
    public string preguntaTexto;  // El texto de la pregunta
    public string[] opciones;     // Las opciones de respuesta
    public int respuestaCorrecta; // El índice de la respuesta correcta

    // Constructor
    public Preguntas(string pregunta, string[] opciones, int respuestaCorrecta)
    {
        this.preguntaTexto = pregunta;
        this.opciones = opciones;
        this.respuestaCorrecta = respuestaCorrecta;
    }
}
