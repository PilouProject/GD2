using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PlaySoundsOnObject : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource OnMouseOverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseOverSound.Play();
    }
}
