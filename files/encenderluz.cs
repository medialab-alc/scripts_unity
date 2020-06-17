using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class encenderluz : MonoBehaviour
{

    public enum estado
    {
        TriggerEnter,TriggerStay,TriggerExit,CollisionEnter,CollisionStay
    }

    public estado Condicion;

    [Header("Luz")]
    public Light objetivo;
    public Color color;
    public float range;
    public float intensity;

    [Header("Collider")]
    public bool cualquiera = false;
    public Collider desencadenante;

    private bool stay = false;

    // Start is called before the first frame update
    void Start()
    {
        objetivo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.CollisionEnter) || (Condicion == estado.CollisionEnter && cualquiera))
        {
            objetivo.enabled = true;
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }

        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.CollisionStay) || (Condicion == estado.CollisionStay && cualquiera))
        {
            objetivo.enabled = true;
            stay = true;
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }


    }


    private void OnCollisionExit(Collision collision)
    {
        if (stay == true)
        {
            objetivo.enabled = false;
            stay = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerEnter) || (Condicion == estado.TriggerEnter && cualquiera))
        {
            objetivo.enabled = true;
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }
        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay && cualquiera))
        {
            objetivo.enabled = true;
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
            stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerExit) || (Condicion == estado.TriggerExit && cualquiera))
        {
            objetivo.enabled = true;
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }
        if (stay == true)
        {
            objetivo.enabled = false;
            stay = false;
        }
    }
}
