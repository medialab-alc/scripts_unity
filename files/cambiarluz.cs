using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class cambiarluz : MonoBehaviour
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

    private Color oldcolor;
    private float oldrange;
    private float oldint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.CollisionEnter) || (Condicion == estado.CollisionEnter && cualquiera))
        {
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }

        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.CollisionStay) || (Condicion == estado.CollisionStay && cualquiera))
        {
            stay = true;
            if (color != null) { oldcolor = objetivo.color; objetivo.color = color; }
            oldrange = objetivo.range;
            objetivo.range = range;
            oldint = objetivo.intensity;
            objetivo.intensity = intensity;
        }


    }


    private void OnCollisionExit(Collision collision)
    {
        if (stay == true)
        {
            //objetivo.enabled = false;
            objetivo.color = oldcolor;
            objetivo.range = oldrange;
            objetivo.intensity = oldint;
            stay = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerEnter) || (Condicion == estado.TriggerEnter && cualquiera))
        {
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }
        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay && cualquiera))
        {
            if (color != null) { oldcolor = objetivo.color; objetivo.color = color; }
            oldrange = objetivo.range;
            objetivo.range = range;
            oldint = objetivo.intensity;
            objetivo.intensity = intensity;
            stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerExit) || (Condicion == estado.TriggerExit && cualquiera))
        {
            if (color != null) { objetivo.color = color; }
            objetivo.range = range;
            objetivo.intensity = intensity;
        }
        if (stay == true)
        {
            objetivo.color = oldcolor;
            objetivo.range = oldrange;
            objetivo.intensity = oldint;
            stay = false;
        }
    }
}
