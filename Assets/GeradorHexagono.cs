using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorHexagono : MonoBehaviour
{
    [SerializeField]
    private float _velocidadeGeracao = 3f;
    [SerializeField]
    private GameObject _hexagono;

    void Start()
    {
        InvokeRepeating("GeraHexagono", 0, _velocidadeGeracao);
    }

    public void GeraHexagono()
    {
        Instantiate(_hexagono);
    }
}
