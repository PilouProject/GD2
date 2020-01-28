using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                cardHand.Add((Instantiate(cardPrefab, transform) as GameObject));
                cardHand[cardHand.Count - 1].GetComponent<EventTrigger>().triggers.Add(CreatePointerEnterEntry());
                cardHand[cardHand.Count - 1].GetComponent<EventTrigger>().triggers.Add(CreatePointerExitEntry());
                cardHand[cardHand.Count - 1].GetComponent<CardHandler>().LoadCard(str);
            }
        }

        private EventTrigger.Entry CreatePointerEnterEntry()
        {
            EventTrigger.Entry entry;

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); });
            UnityEngine.Debug.Log(entry);
            return entry;
        }

        private EventTrigger.Entry CreatePointerExitEntry()
        {
            EventTrigger.Entry entry;

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data); });
            return entry;
        }

        public void OnPointerEnterDelegate(PointerEventData pointerEventData)
        {
            UnityEngine.Debug.Log("enter");
            transform.localScale += new Vector3(1.1F, 1.1f, 1.1f);
        }

        public void OnPointerExitDelegate(PointerEventData pointerEventData)
        {
            UnityEngine.Debug.Log("leaves");
            transform.localScale = new Vector3(0.5F, 0.5f, 1.0f);
        }
    }
}