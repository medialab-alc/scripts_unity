using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class cambiomaterial : MonoBehaviour
{


    public enum estado
    {
        TriggerEnter, TriggerStay, TriggerExit, CollisionEnter
    }
       
    public estado Condicion;

    [Header("Trigger del cambio")]
    public bool cualquiera;
    public Collider desencadenante;

    [Header("Opciones de cambio")]
    public Renderer objetivo;  
    public Material material;
    public Color color;

    [Range(0.0f, 1.0f)]
    public float metallic;
    [Range(0.0f, 1.0f)]
    public float smoothness;

    public Texture albedo;
    public Texture normal;
    public bool Emission;
    public Color EmissionColor;


    private Material newmat;

    Texture tempalbedo;
    Texture tempnormal;
    float tempmetallic;
    float tempsmoothness;
    bool tempemission;
    Color tempemissioncollor;
    Color tempcolor;
    Material tempmaterial;



    



    // Start is called before the first frame update
    void Start()
    {
        //objetivo = gameObject.GetComponent<Renderer>();
        newmat = objetivo.material;
        objetivo.material.EnableKeyword("_NORMALMAP");
        objetivo.material.EnableKeyword("_Metallic");
        objetivo.material.EnableKeyword("_Glossiness");
        objetivo.material.EnableKeyword("_EmissionColor");

        tempalbedo = objetivo.material.GetTexture("_MainTex");
        tempcolor = objetivo.material.color;
        tempnormal = objetivo.material.GetTexture("_BumpMap");
        tempmetallic = objetivo.material.GetFloat("_Metallic");
        tempsmoothness = objetivo.material.GetFloat("_Glossiness");
        tempemissioncollor = objetivo.material.GetColor("_EmissionColor");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
        {     
        if (collision.gameObject.name == desencadenante.name || cualquiera)
        {
            if (material != null) { objetivo.material = material; }
            if (color != null) { newmat.color = color; }
            if (albedo != null) { objetivo.material.SetTexture("_MainTex", albedo); }
            if (color != null) { objetivo.material.SetTexture("_BumpMap", normal); }
            objetivo.material.SetFloat("_Glossiness", smoothness);
            objetivo.material.SetColor("_EmissionColor", EmissionColor);
            objetivo.material.SetFloat("_Metallic", metallic);
            if (Emission) { material.EnableKeyword("_EMISSION"); } else { material.DisableKeyword("_EMISSION"); }

        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        if ((other == desencadenante && Condicion == estado.TriggerEnter) || (Condicion == estado.TriggerEnter && cualquiera))
        {
            if (material != null) { objetivo.material = material; }
            if (color != null) { newmat.color = color; }
            if (albedo != null) { objetivo.material.SetTexture("_MainTex", albedo); }
            if (color != null) { objetivo.material.SetTexture("_BumpMap", normal); }
            objetivo.material.SetFloat("_Glossiness", smoothness);
            objetivo.material.SetColor("_EmissionColor", EmissionColor);
            objetivo.material.SetFloat("_Metallic", metallic);
            if (Emission) { material.EnableKeyword("_EMISSION"); } else { material.DisableKeyword("_EMISSION"); }

        }

        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay && cualquiera))
        {
            if (material != null) { objetivo.material = material; }
            if (color != null) { newmat.color = color; }
            if (albedo != null) { objetivo.material.SetTexture("_MainTex", albedo); }
            if (color != null) { objetivo.material.SetTexture("_BumpMap", normal); }
            objetivo.material.SetFloat("_Glossiness", smoothness);
            objetivo.material.SetColor("_EmissionColor", EmissionColor);
            objetivo.material.SetFloat("_Metallic", metallic);
            if (Emission) { material.EnableKeyword("_EMISSION"); } else { material.DisableKeyword("_EMISSION"); }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if ((other == desencadenante && Condicion == estado.TriggerExit) || (Condicion == estado.TriggerExit && cualquiera))
        {
            if (material != null) { objetivo.material = material; }
            if (color != null) { newmat.color = color; }
            if (albedo != null) { objetivo.material.SetTexture("_MainTex", albedo); }
            if (color != null) { objetivo.material.SetTexture("_BumpMap", normal); }
            objetivo.material.SetFloat("_Glossiness", smoothness);
            objetivo.material.SetColor("_EmissionColor", EmissionColor);
            objetivo.material.SetFloat("_Metallic", metallic);
            if (Emission) { material.EnableKeyword("_EMISSION"); } else { material.DisableKeyword("_EMISSION"); }
        }

        if ((other == desencadenante && Condicion == estado.TriggerStay) || (Condicion == estado.TriggerStay&& cualquiera))
        {
            if (material != null) { objetivo.material = tempmaterial; }
            if (color != null) { newmat.color = color; }
            if (albedo != null) { objetivo.material.SetTexture("_MainTex", tempalbedo); }
            if (color != null) { objetivo.material.SetTexture("_BumpMap", tempnormal); }
            objetivo.material.SetFloat("_Glossiness", tempsmoothness);
            objetivo.material.SetColor("_EmissionColor", tempemissioncollor);
            objetivo.material.SetFloat("_Metallic", tempmetallic);
            if (Emission) { material.DisableKeyword("_EMISSION"); } else { material.EnableKeyword("_EMISSION"); }
        }
    }

}
