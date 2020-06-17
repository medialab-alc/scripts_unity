using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer_desaparecer : MonoBehaviour
{
    public enum accion
    {
        aparecer,desaparecer
    }

    public accion Accion;

    public enum estado
    {
        TriggerEnter, TriggerExit, TriggerStay, CollisionEnter
    }

    public estado Condicion;

    [Header("Objetivo")]
    public GameObject Objetivo;
    [Header("Desencadenante")]
    public Collider desencadenante;

    private bool stay = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Accion == accion.aparecer) { Objetivo.SetActive(false); }
        if (Accion == accion.desaparecer) { Objetivo.SetActive(true); }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == desencadenante && Condicion == estado.TriggerEnter)
        {
            if (Accion == accion.aparecer) { Objetivo.SetActive(true); }
            if (Accion == accion.desaparecer) { Objetivo.SetActive(false); }
            
        }
        if (other == desencadenante && Condicion == estado.TriggerStay)
        {
            if (Accion == accion.aparecer) { Objetivo.SetActive(true); }
            if (Accion == accion.desaparecer) { Objetivo.SetActive(false); }
            stay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == desencadenante && Condicion == estado.TriggerExit)
        {
            if (Accion == accion.aparecer) { Objetivo.SetActive(true); }
            if (Accion == accion.desaparecer) { Objetivo.SetActive(false); }
        }
        if (stay == true)
        {
            if (Accion == accion.aparecer) { Objetivo.SetActive(false); }
            if (Accion == accion.desaparecer) { Objetivo.SetActive(true); }
            stay = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.name == desencadenante.name && Condicion == estado.CollisionEnter) { 
            if (Accion == accion.aparecer) { Objetivo.SetActive(true); }
            if (Accion == accion.desaparecer) { Objetivo.SetActive(false); }
        }
    }



}
