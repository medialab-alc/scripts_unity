using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class collisionaudio : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////
    //EXPLICACIÓN
    //
    //UnaVez: REPRODUCE EL SONIDO SOLO LA PRIMERA VEZ QUE COLISIONA CON EL OBJETO INDICADO
    //
    //CadaVez: REPRODUCE EL SONIDO (DESDE EL INICIO) CADA VEZ QUE COLISIONA CON EL OBJETO INDICADO
    //
    //PorContacto: REPRODUCE EL SONIDO MIENTRAS ESTÉ EN PorContacto CON EL OBJETO INDICADO
    //
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////


    public enum estado
    {
        UnaVez, CadaVez , PorContacto
    }
       
    public estado Condicion;

    [Header("Trigger del sonido")]
    public bool cualquiera;
    public Collider desencadenante;

    [Header("Sonido a reproducir")]
    public AudioClip sonido;

    public AudioSource objetivo;
    private bool UnaVez = false;

    



    // Start is called before the first frame update
    void Start()
    {
        //objetivo = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.UnaVez && UnaVez == false) || (Condicion == estado.UnaVez && cualquiera && UnaVez == false))
        {
            objetivo.clip = sonido;
            objetivo.Play();
            UnaVez = true;
        }

        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.CadaVez) || (Condicion == estado.CadaVez && cualquiera))
        {
            objetivo.clip = sonido;
            objetivo.Play();
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.name == desencadenante.name && Condicion == estado.PorContacto) || (Condicion == estado.PorContacto && cualquiera))
        {
            objetivo.clip = sonido;
            if (!objetivo.isPlaying) { objetivo.Play(); }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == desencadenante.name && Condicion == estado.PorContacto) { objetivo.Stop(); }
    }

}
