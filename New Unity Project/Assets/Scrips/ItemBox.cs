using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    Renderer _renderer;

    public Color touchColor = Color.red;

    public Color originalColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        originalColor = _renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("endpoint"))
        {
            _renderer.material.color = touchColor;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("endpoint"))
        {
            _renderer.material.color = originalColor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag("endpoint"))
        {
            _renderer.material.color = touchColor;
        }
    }
}

