using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int sceneToLoad = -1;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    { 
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        print("Scene loaded");
    }

}
