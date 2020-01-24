using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to add or supp a nb of stack of super attack, return false if it's time to "NIQUER DES MERES" 
    public bool AddSuppSuperBar(int _nb)
    {
        GetComponent<Slider>().value = GetComponent<Slider>().value + _nb;
        if (GetComponent<Slider>().value < 0)
            GetComponent<Slider>().value = 0;
        else if (GetComponent<Slider>().value >= GetComponent<Slider>().maxValue)
            return (false);
        return (true);
    }
}
