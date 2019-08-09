using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagono : MonoBehaviour
{
    [SerializeField]
    private float _velocidade = 5f;

    void Start()
    {
        transform.Rotate(new Vector3(1, 1, Random.Range(0f, 360f)));
    }

    void Update()
    {
        transform.localScale -= Vector3.one * _velocidade * Time.deltaTime;

        if(transform.localScale.y <= 0.1)
        {
            Destroy(gameObject);
        }
    }
}
