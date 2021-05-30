using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Enemy;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private Rigidbody2D _body = null;
    private SpriteRenderer _renderer = null;

    private int index;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
        // Update is called once per frame
    void Update()
    {
        //pega posição antes de atuliza-la para calculo de movimento
        Vector2 positionBefore = transform.position;
        //se move para proxima posição do vetor
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        
        //quando chega na posição do vetor passa para o proxima posição do vetor
        if(transform.position == positions[index])
        {
            //se cheogu no final do vetor retorna para o começo
            if(index == positions.Length - 1)
            {   
                index = 0;
            }    
            else
            {
                index++;            
            }    
        }

        //quando estiver andando para tras inverte as sprites 
        _renderer.flipX = !((positionBefore.x - transform.position.x) < 0.0f);
    }
}
