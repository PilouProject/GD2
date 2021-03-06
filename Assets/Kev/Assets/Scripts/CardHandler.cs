﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CardFight
{
    public class CardHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject   cardPrefab;
        public Image        cardArt;
        public Image        cardSelected;
        private string      _name;
        private GameObject  _zoom;
        private bool        _isZoom = false;
        private bool        _isClicked = false;

        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(GameObject.Find("/GameLoop").GetComponent<GameLoop>().handleCard);
        }

        void Update()
        {
            if (cardArt != null && this.transform.localScale.x < 0.5f && this.transform.localScale.y < 0.5f)
                this.transform.localScale += new Vector3(0.02F, 0.02f, 0.0f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_isZoom)
            {
                _zoom = Instantiate(cardPrefab, this.transform.parent.transform.parent.transform) as GameObject;
                _zoom.GetComponent<CardHandler>().LoadZoom(_name);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_isZoom)
                Destroy(_zoom);
        }

        public void OnClick()
        {
            if (!_isZoom)
            {
                if (_isClicked)
                    this.transform.GetChild(0).gameObject.SetActive(false);
                else
                    this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.parent.GetComponent<HandHandler>().UpdateSelectedCard(this.transform.gameObject);
                _isClicked = !_isClicked;
            }
        }

        public void LoadArt(string name)
        {
            if (name == null)
                return;
            _name = name;
            cardArt.sprite = Resources.Load<Card>("Cards/" + name).cardArt;
            cardSelected.sprite = Resources.Load<Card>("Cards/" + name).cardSelected;
        }

        public void LoadZoom(string name)
        {
            if (name == null)
                return;
            _isZoom = true;
            _name = name;
            cardArt.sprite = Resources.Load<Card>("Cards/" + name).cardArt;
            cardSelected.sprite = null;
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.position = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
            this.transform.localScale = new Vector3(1.25F, 1.25f, 1.25f);
        }
    }
}