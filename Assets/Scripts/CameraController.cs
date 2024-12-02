using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // How smoothly the camera follows the player
    public float smoothSpeed = 0.125f;

    // Offset of the camera from the player
    public Vector3 offset;

    void LateUpdate()
    {
        // Check if the player reference is assigned
        if (player == null)
        {
            Debug.LogError("Player reference is missing in CameraFollow script.");
            return;
        }

        // Calculate the desired position of the camera
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the new smoothed position
        transform.position = smoothedPosition;
    }
    /* public Transform personaje;

     private float tamañoCamara;
     private float alturaPantalla;
     float speed = 5f;

     // Start is called before the first frame update
     void Start()
     {
         tamañoCamara = Camera.main.orthographicSize;
         alturaPantalla = tamañoCamara * 2;
     }

     // Update is called once per frame
     void Update()
     {
         CalcularPosicionCamara();
     }

     void CalcularPosicionCamara()
     {
         int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
         float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamañoCamara;

         transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
     }*/
}