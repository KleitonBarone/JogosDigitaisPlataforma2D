using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player; //posição jogador
    public Vector3 offsetCamera = new Vector3(0,0,-10); //offset da camera em relacao jogador
    public float smoothSpeed = 0.1f; //quao fluido é a camera de 0 a 1, sendo 0 muito fluido e 1 fixo ao jogador

    //Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPosition = player.position + offsetCamera; //posição desejada com offset
        /*
        * Lerp é um metodo para fazer interpolação linear
        * entre os dois pontos e fazer ficar fluido
        */
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
