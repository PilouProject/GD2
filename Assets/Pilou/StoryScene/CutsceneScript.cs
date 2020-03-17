using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (test());
    }

    IEnumerator test(){
        yield return new WaitForSeconds (5.0f);
        Debug.Log("ezaeaz");
        SceneManager.LoadScene("Assets/Pilou/FinalScene/FinalScene.unity");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
