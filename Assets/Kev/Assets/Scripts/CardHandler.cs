using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CardFight
{
    public class CardHandler : MonoBehaviour
    {
        public Image cardArt;

        void Start()
        {

        }

        void Update()
        {
            if (cardArt.sprite != null && transform.localScale.x < 0.5f && transform.localScale.y < 0.5f)
                transform.localScale += new Vector3(0.02F, 0.02f);
        }

        public void LoadCard(string name)
        {
            if (name == null)
                return;
            Card card = Resources.Load<Card>("Cards/" + name);
            cardArt.sprite = card.cardArt;
        }
    }
}