using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_or_off : MonoBehaviour
{
    public GameObject DisableDoor;
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player" && DisableDoor!=null){
            Destroy(DisableDoor);
        }    
    }
}
