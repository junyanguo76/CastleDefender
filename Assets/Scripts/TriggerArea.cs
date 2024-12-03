using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = this.GetComponent<Collider>(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            CameraController.instance.ChangingToBowlCamera();
        }

    }

    
}
