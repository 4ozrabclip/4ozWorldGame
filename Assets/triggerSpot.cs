using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class triggerSpot : MonoBehaviour
{
    public BrianStateManager brianStateManager;
    public GameObject brian;
    private void OnTriggerStay(Collider other){
        if (other.gameObject == brian){
            brianStateManager.setBrianHome(true);
        }
        else{
            brianStateManager.setBrianHome(false);
        }
    }
}
