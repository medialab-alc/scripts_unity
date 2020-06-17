using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class triggeraudio : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////
    //EXPLICACIÓN
    //
    //TriggerEnter: REPRODUCE EL SONIDO CUANDO EL OBJETO INGRESE AL TRIGGER
    //
    //TriggerStay: REPRODUCE EL SONIDO MIENTRAS EL OBJETO SE MANTENGA DENTRO DEL TRIGGER
    //
    //TriggerExit: REPRODUCE EL SONIDO CUANDO EL OBJETO SALE DEL TRIGGER
    //
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////


    public enum estado
    {
        TriggerEnter, TriggerStay, TriggerExit
    }
       
    public estado Condicion;

    [Header("Trigger del sonido")]
    public bool cualquiera;
    public Collider desencadenante;

    [Header("Sonido a reproducir")]
    public AudioClip sonido;
    public AudioSource objetivo;

    //private AudioSource fuente;

    



    // Start is called before the first frame update
    void Start()
    {
        //fuente = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerEnter) || (Condicion == estado.TriggerEnter && cualquiera))
        {
            objetivo.clip = sonido;
            objetivo.Play();
        }

        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay && cualquiera))
        {
            objetivo.clip = sonido;
            objetivo.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerEnter) || (Condicion == estado.TriggerEnter && cualquiera))
        {
            objetivo.clip = sonido;
            if (!objetivo.isPlaying) { objetivo.Play(); }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerExit) || (Condicion == estado.TriggerExit && cualquiera))
        {
            objetivo.clip = sonido;
            objetivo.Play();
        }

        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay && cualquiera))
        {
         
            objetivo.Stop();
        }
    }

}
