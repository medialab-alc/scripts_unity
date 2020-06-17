using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public GameObject Destino = null;

    public Collider Trigger = null;

    public Transform personaje = null;

    private bool transportar = false;

    CharacterController cc;

	void Start(){
        cc = personaje.GetComponent<CharacterController>();
    }

	void Update () {

	}

    void OnTriggerEnter(Collider other) {
        if(other == Trigger){
        //transportar = true;
         cc.enabled = false;
         this.transform.position = Destino.transform.position;
         cc.enabled = true;
        }
    }
}