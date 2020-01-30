using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CardFight
{
    public class HandHandler : MonoBehaviour
    {
        public GameObject           cardPrefab;
        private GameObject          _selectedCard;
        private List<GameObject>    _cardHand = new List<GameObject>();

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
                _cardHand.Add((Instantiate(cardPrefab, this.transform) as GameObject));
                _cardHand[_cardHand.Count - 1].name = name;
                _cardHand[_cardHand.Count - 1].GetComponent<CardHandler>().LoadArt(name);
            }
        }

        public void DestroyHand()
        {
            if (_cardHand.Count > 0)
            {
                foreach (GameObject card in _cardHand)
                    Destroy(card);
                _cardHand.Clear();
            }
        }

        public void UpdateSelectedCard(GameObject newSelectedCard)
        {
            if (GameObject.ReferenceEquals(_selectedCard, newSelectedCard))
            {
                _selectedCard = null;
            }
            else
            {
                if (_selectedCard != null)
                    _selectedCard.GetComponent<CardHandler>().OnClick();
                _selectedCard = newSelectedCard;
            }
        }
    }
}