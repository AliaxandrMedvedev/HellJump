using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            transform.gameObject.GetComponent<AudioManager>().PlayCrashSound(); //play sound from method in AudioManager script
            other.GetComponentInParent<Platform>().Break();                     //use method from Platform to explose Platform
            Destroy(other.gameObject);                                          //destroy invisible trigger segment
            
        }
    }
}
