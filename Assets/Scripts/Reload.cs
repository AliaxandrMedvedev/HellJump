
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Reload : MonoBehaviour
{
    // change level if the ball collided with the Finish Platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FinishPlatform finishPlatform)) {
            StartCoroutine(RestartScene());
        }
    }



    IEnumerator RestartScene()
    {
        transform.gameObject.GetComponent<AudioManager>().PlayVictorySound();   //play sound from method in AudioManager script
        yield return new WaitForSeconds(1f);                                    //time before changing scene
        SceneManager.LoadScene("SampleScene");                                  //load main scene again
    }
}
