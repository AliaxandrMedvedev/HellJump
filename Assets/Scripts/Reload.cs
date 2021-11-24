
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Reload : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FinishPlatform finishPlatform)) {
            StartCoroutine(RestartScene());
        }
    }



    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
