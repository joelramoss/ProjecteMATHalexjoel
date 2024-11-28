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

   

    // Definición de preguntas, opciones y respuestas correctas directamente en este script
    private string[] preguntas = {
    "¿Cuál es el resultado de 5 + 3?",
    "¿Qué número es el doble de 6?",
    "¿Cuánto es 12 dividido entre 4?",
    "Si un triángulo tiene un ángulo de 90°, ¿cómo se llama?",
    "¿Cuál es el valor de π (pi) con dos decimales?",
    "Si x + 3 = 8, ¿cuál es el valor de x?",
    "¿Cuál es el área de un cuadrado con lados de 4 cm?",
    "¿Cuántos grados tiene un ángulo recto?",
    "¿Cuánto es 15 - 7?",
    "Si un círculo tiene un radio de 5 cm, ¿cuál es su diámetro?",
    "¿Qué es un número primo?",
    "¿Cuántos lados tiene un hexágono?",
    "¿Cuál es el resultado de 3 * 6?",
    "Si un rectángulo tiene una base de 10 cm y una altura de 5 cm, ¿cuál es su área?",
    "¿Qué es un número impar?",
    "¿Cuánto es 25 dividido entre 5?",
    "¿Cuál es la raíz cuadrada de 49?",
    "¿Qué es el perímetro de un círculo?",
    "¿Cuántos grados tiene un ángulo obtuso?",
    "¿Cómo se llama la forma con cuatro lados de igual longitud?",
    "¿Cuál es el valor de 4²?",
    "¿Qué es una fracción equivalente?",
    "¿Cuál es el valor de 3³?",
    "¿Cuántos milímetros hay en un centímetro?",
    "¿Cuántos segundos hay en una hora?",
    "¿Cuántos minutos hay en 3 horas?",
    "Si el radio de un círculo es 7 cm, ¿cuál es su área?",
    "¿Qué es una ecuación?",
    "¿Qué es un número compuesto?",
    "¿Cuál es el resultado de 16 ÷ 2?",
    "¿Qué significa el término 'media' en estadística?",
    "Si un número es divisible entre 2, ¿cómo se le llama?",
    "¿Qué es un ángulo agudo?",
    "¿Cómo se llama un ángulo de 180°?",
    "¿Qué significa 'sumar' en matemáticas?",
    "¿Qué es un número racional?",
    "¿Cuánto es 8 * 7?",
    "¿Qué es un triángulo equilátero?",
    "¿Cuál es el resultado de 9 + 6?",
    "Si un número es divisible entre 3, ¿qué propiedad tiene?",
    "¿Qué es un número irracional?",
    "¿Cómo se calcula el perímetro de un triángulo equilátero?",
    "¿Qué significa 'restar' en matemáticas?",
    "¿Qué es la propiedad distributiva de la multiplicación?",
    "¿Cuál es la suma de los ángulos internos de un triángulo?",
    "¿Cuántos decimales tiene el número 1/3?",
    "¿Cómo se llama el valor de un número en una ecuación?",
    "¿Qué es el mínimo común múltiplo (MCM)?",
    "¿Qué es el máximo común divisor (MCD)?",
    "¿Cuánto es 100 ÷ 4?",
    "¿Cómo se llama la línea que divide a un triángulo por su mitad?",
    "¿Qué es el área de un círculo?",
    "¿Qué es una progresión aritmética?",
    "¿Cómo se calcula el volumen de un cubo?",
    "¿Qué es la mediana en un conjunto de datos?",
    "¿Cuántos vértices tiene un cubo?",
    "¿Qué es una ecuación de segundo grado?",
    "¿Qué significa 'multiplicar' en matemáticas?",
    "¿Cuál es el resultado de 4 * 9?",
    "¿Cómo se llama el ángulo mayor de 90°?",
    "¿Cuántos ángulos rectos tiene un rectángulo?",
    "¿Qué significa 'dividir' en matemáticas?",
    "¿Qué es la fracción 1/2 en decimal?",
    "¿Cuál es la distancia entre dos puntos en el plano cartesiano?",
    "¿Qué es un número decimal?",
    "¿Cómo se representa un número negativo?",
    "¿Qué es un ángulo llano?",
    "¿Qué es una matriz en matemáticas?",
    "¿Cuántos lados tiene un pentágono?",
    "¿Qué es una raíz cuadrada?",
    "¿Cómo se llama el resultado de multiplicar un número por sí mismo?",
    "¿Qué es el cociente de una división?",
    "¿Qué es la regla de tres simple?",
    "¿Cuál es la función principal de un sistema de coordenadas cartesianas?",
    "¿Qué es una fracción impropia?",
    "¿Cuántos lados tiene un dodecágono?",
    "¿Qué es la simplificación de fracciones?"
};

private string[][] opciones = new string[][] {
    new string[] { "6", "7", "8" },  // Pregunta 1: ¿Cuál es el resultado de 5 + 3?
    new string[] { "10", "12", "14" },  // Pregunta 2: ¿Qué número es el doble de 6?
    new string[] { "2", "3", "4" },  // Pregunta 3: ¿Cuánto es 12 dividido entre 4?
    new string[] { "Círculo", "Triángulo", "Cuadrado" },  // Pregunta 4: Si un triángulo tiene un ángulo de 90°, ¿cómo se llama?
    new string[] { "3.14", "3.15", "3.13" },  // Pregunta 5: ¿Cuál es el valor de π (pi) con dos decimales?
    new string[] { "5", "4", "3" },  // Pregunta 6: Si x + 3 = 8, ¿cuál es el valor de x?
    new string[] { "16 cm²", "12 cm²", "8 cm²" },  // Pregunta 7: ¿Cuál es el área de un cuadrado con lados de 4 cm?
    new string[] { "60°", "90°", "120°" },  // Pregunta 8: ¿Cuántos grados tiene un ángulo recto?
    new string[] { "6", "7", "8" },  // Pregunta 9: ¿Cuánto es 15 - 7?
    new string[] { "10 cm", "5 cm", "15 cm" },  // Pregunta 10: Si un círculo tiene un radio de 5 cm, ¿cuál es su diámetro?
    new string[] { "Un número que solo tiene dos divisores", "Un número divisible entre 2", "Un número que no tiene factores" },  // Pregunta 11: ¿Qué es un número primo?
    new string[] { "4", "6", "8" },  // Pregunta 12: ¿Cuántos lados tiene un hexágono?
    new string[] { "18", "20", "16" },  // Pregunta 13: ¿Cuál es el resultado de 3 * 6?
    new string[] { "50 cm²", "30 cm²", "10 cm²" },  // Pregunta 14: Si un rectángulo tiene una base de 10 cm y una altura de 5 cm, ¿cuál es su área?
    new string[] { "Un número que no se puede dividir entre 2", "Un número que siempre es par", "Un número que termina en 0 o 5" },  // Pregunta 15: ¿Qué es un número impar?
    new string[] { "3", "4", "5" },  // Pregunta 16: ¿Cuánto es 25 dividido entre 5?
    new string[] { "7", "6", "9" },  // Pregunta 17: ¿Cuál es la raíz cuadrada de 49?
    new string[] { "Circunferencia", "Área", "Perímetro" },  // Pregunta 18: ¿Qué es el perímetro de un círculo?
    new string[] { "120°", "135°", "100°" },  // Pregunta 19: ¿Cuántos grados tiene un ángulo obtuso?
    new string[] { "Cuadrado", "Rectángulo", "Rombo" },  // Pregunta 20: ¿Cómo se llama la forma con cuatro lados de igual longitud?
    new string[] { "16", "8", "4" },  // Pregunta 21: ¿Cuál es el valor de 4²?
    new string[] { "Fracción que representa el mismo valor", "Fracción con el mismo denominador", "Fracción que se puede simplificar" },  // Pregunta 22: ¿Qué es una fracción equivalente?
    new string[] { "9", "27", "81" },  // Pregunta 23: ¿Cuál es el valor de 3³?
    new string[] { "100", "10", "1" },  // Pregunta 24: ¿Cuántos milímetros hay en un centímetro?
    new string[] { "60", "3600", "600" },  // Pregunta 25: ¿Cuántos segundos hay en una hora?
    new string[] { "180", "300", "60" },  // Pregunta 26: ¿Cuántos minutos hay en 3 horas?
    new string[] { "154 cm²", "153 cm²", "150 cm²" },  // Pregunta 27: Si el radio de un círculo es 7 cm, ¿cuál es su área?
    new string[] { "Una igualdad matemática", "Una operación", "Una secuencia de números" },  // Pregunta 28: ¿Qué es una ecuación?
    new string[] { "Un número divisible por 3 y 5", "Un número divisible entre 1 y sí mismo", "Un número divisible entre varios divisores" },  // Pregunta 29: ¿Qué es un número compuesto?
    new string[] { "8", "6", "7" },  // Pregunta 30: ¿Cuál es el resultado de 16 ÷ 2?
    new string[] { "Promedio", "Moda", "Mediana" },  // Pregunta 31: ¿Qué significa el término 'media' en estadística?
    new string[] { "Par", "Impar", "Divisible por 3" },  // Pregunta 32: Si un número es divisible entre 2, ¿cómo se le llama?
    new string[] { "Menor de 90°", "Mayor de 90°", "Igual a 90°" },  // Pregunta 33: ¿Qué es un ángulo agudo?
    new string[] { "Recto", "Agudo", "Llano" },  // Pregunta 34: ¿Cómo se llama un ángulo de 180°?
    new string[] { "Sumar", "Restar", "Multiplicar" },  // Pregunta 35: ¿Qué significa 'sumar' en matemáticas?
    new string[] { "Un número entero", "Un número que puede ser expresado como una fracción", "Un número que tiene decimales" },  // Pregunta 36: ¿Qué es un número racional?
    new string[] { "56", "54", "64" },  // Pregunta 37: ¿Cuánto es 8 * 7?
    new string[] { "Un triángulo con lados iguales", "Un triángulo con ángulos rectos", "Un triángulo con ángulos obtusos" },  // Pregunta 38: ¿Qué es un triángulo equilátero?
    new string[] { "15", "14", "16" },  // Pregunta 39: ¿Cuál es el resultado de 9 + 6?
    new string[] { "Divisible entre 2", "Divisible entre 3", "Divisible entre 5" },  // Pregunta 40: Si un número es divisible entre 3, ¿qué propiedad tiene?
    new string[] { "Un número que tiene decimales infinitos no repetidos", "Un número que tiene decimales periódicos", "Un número entero" },  // Pregunta 41: ¿Qué es un número irracional?
    new string[] { "Multiplicando los tres lados", "Sumando los tres lados", "Multiplicando el perímetro por 3" },  // Pregunta 42: ¿Cómo se calcula el perímetro de un triángulo equilátero?
    new string[] { "Sumar", "Multiplicar", "Restar" },  // Pregunta 43: ¿Qué significa 'restar' en matemáticas?
    new string[] { "Distributiva", "Asociativa", "Conmutativa" },  // Pregunta 44: ¿Qué es la propiedad distributiva de la multiplicación?
    new string[] { "180°", "360°", "90°" },  // Pregunta 45: ¿Cuál es la suma de los ángulos internos de un triángulo?
    new string[] { "2", "1", "0" },  // Pregunta 46: ¿Cuántos decimales tiene el número 1/3?
    new string[] { "Despeje", "Valor", "Resultado" },  // Pregunta 47: ¿Cómo se llama el valor de un número en una ecuación?
    new string[] { "El menor múltiplo común", "El mayor múltiplo común", "El mayor divisor común" },  // Pregunta 48: ¿Qué es el mínimo común múltiplo (MCM)?
    new string[] { "El mayor múltiplo común", "El mayor divisor común", "El menor múltiplo común" },  // Pregunta 49: ¿Qué es el máximo común divisor (MCD)?
    new string[] { "25", "24", "30" },  // Pregunta 50: ¿Cuánto es 100 ÷ 4?
    new string[] { "Mediana", "Bisectriz", "Altura" },  // Pregunta 51: ¿Cómo se llama la línea que divide a un triángulo por su mitad?
    new string[] { "Área = πr²", "Área = 2πr", "Área = 4r" },  // Pregunta 52: ¿Qué es el área de un círculo?
    new string[] { "Una secuencia de números", "Una suma de números", "Una resta de números" },  // Pregunta 53: ¿Qué es una progresión aritmética?
    new string[] { "Lado³", "Lado²", "Lado*Lado*Lado" },  // Pregunta 54: ¿Cómo se calcula el volumen de un cubo?
    new string[] { "El promedio", "El valor medio", "El valor central" },  // Pregunta 55: ¿Qué es la mediana en un conjunto de datos?
    new string[] { "6", "8", "4" },  // Pregunta 56: ¿Cuántos vértices tiene un cubo?
    new string[] { "Una ecuación cuadrática", "Una ecuación con dos incógnitas", "Una ecuación de tercer grado" },  // Pregunta 57: ¿Qué es una ecuación de segundo grado?
    new string[] { "Sumar", "Multiplicar", "Restar" },  // Pregunta 58: ¿Qué significa 'multiplicar' en matemáticas?
    new string[] { "24", "36", "48" },  // Pregunta 59: ¿Cuál es el resultado de 4 * 9?
    new string[] { "Obtuso", "Recto", "Agudo" },  // Pregunta 60: ¿Cómo se llama el ángulo mayor de 90°?
    new string[] { "2", "4", "3" },  // Pregunta 61: ¿Cuántos ángulos rectos tiene un rectángulo?
    new string[] { "Sustraer", "Dividir", "Sumar" },  // Pregunta 62: ¿Qué significa 'dividir' en matemáticas?
    new string[] { "0.5", "1", "2" },  // Pregunta 63: ¿Qué es la fracción 1/2 en decimal?
    new string[] { "Por la distancia entre los puntos", "Usando las coordenadas", "Por la distancia de los ejes" },  // Pregunta 64: ¿Cuál es la distancia entre dos puntos en el plano cartesiano?
    new string[] { "Un número con punto decimal", "Un número con coma decimal", "Un número sin punto decimal" },  // Pregunta 65: ¿Qué es un número decimal?
    new string[] { "Con el signo negativo", "Con el signo positivo", "Con punto decimal" },  // Pregunta 66: ¿Cómo se representa un número negativo?
    new string[] { "180°", "90°", "360°" },  // Pregunta 67: ¿Qué es un ángulo llano?
    new string[] { "Una matriz es una tabla", "Un conjunto de números organizados", "Una secuencia matemática" },  // Pregunta 68: ¿Qué es una matriz en matemáticas?
    new string[] { "5", "6", "4" },  // Pregunta 69: ¿Cuántos lados tiene un pentágono?
    new string[] { "El número que se multiplica por sí mismo", "El número que tiene raíz cuadrada", "El número que es elevado a 2" },  // Pregunta 70: ¿Qué es una raíz cuadrada?
    new string[] { "Cuadrado", "Exponencial", "Producto" },  // Pregunta 71: ¿Cómo se llama el resultado de multiplicar un número por sí mismo?
    new string[] { "El cociente", "El divisor", "El numerador" },  // Pregunta 72: ¿Qué es el cociente de una división?
    new string[] { "Una regla de proporciones", "Una regla de cálculo", "Una regla de tres" },  // Pregunta 73: ¿Qué es la regla de tres simple?
    new string[] { "Ubicar puntos", "Establecer relaciones", "Dividir ejes" },  // Pregunta 74: ¿Cuál es la función principal de un sistema de coordenadas cartesianas?
    new string[] { "Fracción mayor que 1", "Fracción menor que 1", "Fracción que no se puede simplificar" },  // Pregunta 75: ¿Qué es una fracción impropia?
    new string[] { "10", "12", "14" },  // Pregunta 76: ¿Cuántos lados tiene un dodecágono?
    new string[] { "Hacer más pequeña una fracción", "Dividir una fracción", "Sustituir un denominador" }  // Pregunta 77: ¿Qué es la simplificación de fracciones?
};
private int[] respuestasCorrectas = {
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
        if (preguntas.Length != opciones.Length)
        {
            Debug.LogError(preguntas.Length);
            Debug.LogError(opciones.Length);  // Salir si no coinciden
            Debug.LogError("El número de preguntas no coincide con el número de opciones.");
            return; // Salir si no coinciden
        }

        // Verificar que el número de respuestas correctas coincida con el número de preguntas
        if (preguntas.Length != respuestasCorrectas.Length)
        {
            Debug.LogError(preguntas.Length);
            Debug.LogError(respuestasCorrectas.Length);
            Debug.LogError("El número de respuestas correctas no coincide con el número de preguntas.");
            return; // Salir si no coinciden
        }
    }
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

        // Verificar que fondoBlanco, panelPregunta, y textoPregunta están asignados
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
            playerController.vida = playerController.vida - 1;
        }

        // Ocultar el fondo y el panel después de responder
        fondoBlanco.SetActive(false);
        panelPregunta.SetActive(false);
    }
}