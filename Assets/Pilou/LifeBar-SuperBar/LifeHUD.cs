using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHUD : MonoBehaviour
{
    private float _lifeSliderMaxValue;

    // Start is called before the first frame update
    void Start()
    {
        _lifeSliderMaxValue = GetComponent<Slider>().maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //fonction to deal damage to a player, return false if he dies or true if he still lives
    public bool TakeDamage(int _nbDamage)
    {
        GetComponent<Slider>().value = GetComponent<Slider>().value + _nbDamage;
        if (GetComponent<Slider>().value >= _lifeSliderMaxValue)
            return (false);
        return (true);
    }

    //fonction to heal the player
    public void Heal(int _nbHeal)
    {
        if (GetComponent<Slider>().value - _nbHeal < 0)
            GetComponent<Slider>().value = 0;
        else
            GetComponent<Slider>().value = GetComponent<Slider>().value - _nbHeal;
    }
}
