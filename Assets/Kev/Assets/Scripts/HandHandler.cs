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

        void Start()
        {

        }

        void Update()
        {

        }

        public void InstantiateHand(List<string> cardNames)
        {
            foreach (string name in cardNames)
            {
                cardHand.Add((Instantiate(cardPrefab, this.transform) as GameObject));
                cardHand[cardHand.Count - 1].name = name;
                cardHand[cardHand.Count - 1].GetComponent<CardHandler>().LoadArt(name);
            }
        }

        public void DestroyHand()
        {
            if (cardHand.Count != 0)
            {
                foreach (GameObject card in cardHand)
                    Destroy(card);
                cardHand.Clear();
            }
        }
    }
}