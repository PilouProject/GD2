using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    public GameObject Ryu;
    public GameObject Ken;
    public Text RyuText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (test());
    }

    IEnumerator test(){
        yield return new WaitForSeconds (5.0f);
        Debug.Log("ezaeaz");
        RyuText.text = "OMG";
        Debug.Log(RyuText.text);
        Ryu.GetComponent<PlayerAnimationController>().FireDefense();
        Ken.GetComponent<PlayerAnimationController>().FireSpecial();
        //Ryu.Play("attack");
        yield return new WaitForSeconds (5.0f);
        SceneManager.LoadScene("Assets/Pilou/FinalScene/FinalScene.unity");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
