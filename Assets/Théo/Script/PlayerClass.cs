using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int hp;
    public List<string> deck;
    public List<string> hand;
    public int superBar;
    public int strenght;
    public int stance;
    public float strenghtcoef;
    public bool thornsup;
    
    public void addCard()
    {
        int j = Random.Range(0, deck.Count - 1);
        hand.Add(deck[j]);
        deck.RemoveAt(j);
    }

    public void init()
    {
        hp = 30;
        strenght = 2;
        deck = new List<string>();
        hand = new List<string>();
        string[] deckcards = { "knuckles", "knuckles", "bite", "bite", "baseball", "heal", "heal", "enrage", "enrage", "thorns", "taunt", "taunt", "remove", "remove", "weakness"};
        deck.AddRange(deckcards);
        superBar = 0;
        stance = -1;
        strenghtcoef = 1;
        thornsup = false;
        for (int i = 0; i < 4; i++)
            {
                addCard();
            }
    }
    public void resetStat()
    {
        stance = -1;
        strenghtcoef = 1;
        strenght = 2;
        thornsup = false;
    }

    public List<string> status(List<string> tags)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            switch (tags[i])
            {
                case "bite":
                    hp += -1;
                    tags.Add("bite1");
                    break;
                case "bite1":
                    hp += -1;
                    break;
                case "enrage":
                    strenght += 2;
                    break;
                case "weakness":
                    strenghtcoef = 0.5f;
                    break;
            }
            tags.RemoveAt(i);
        }
        Debug.Log(tags);
        return (tags);
    }

}
