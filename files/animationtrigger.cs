using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtrigger : MonoBehaviour
{

    public enum estado
    {
        TriggerEnter, TriggerStay, TriggerExit, collisionEnter
    }

    public estado Condicion;

    [Header("Animator")]
    public Animator objetivo;
    public string NombreAnimacion;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other == desencadenante && Condicion == estado.TriggerEnter || Condicion == estado.TriggerEnter && cualquiera)
        {
            objetivo.enabled = true;
            objetivo.Play(NombreAnimacion);
        }
        if (other == desencadenante && Condicion == estado.TriggerStay || Condicion == estado.TriggerStay && cualquiera)
        {
            objetivo.enabled = true;
            objetivo.Play(NombreAnimacion);
            stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == desencadenante && Condicion == estado.TriggerExit || Condicion == estado.TriggerExit && cualquiera)
        {
            objetivo.enabled = true;
            objetivo.Play(NombreAnimacion);
        }
        if (stay == true)
        {
            objetivo.enabled = false;
            stay = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == desencadenante.name && Condicion == estado.collisionEnter || Condicion == estado.collisionEnter && cualquiera)
        {
            objetivo.enabled = true;
            objetivo.Play(NombreAnimacion);
        }
    }
}
