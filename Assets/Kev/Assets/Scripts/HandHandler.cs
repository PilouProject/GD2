using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CardFight
{
    public class HandHandler : MonoBehaviour
    {
        public GameObject cardPrefab;
        List<GameObject> cardHand = new List<GameObject>();
        List<string> tmp = new List<string> { "Griffure", "LaBatte", "PoingAmericain", "Moquerie" };

        void Start()
        {
            InstantiateHand();
        }

        void Update()
        {

        }

        public void InstantiateHand()
        {
            foreach (string str in tmp)
            {
                cardHand.Add((Instantiate(cardPrefab, this.transform) as GameObject));
                cardHand[cardHand.Count - 1].GetComponent<CardHandler>().LoadArt(str);
            }
        }
    }
}