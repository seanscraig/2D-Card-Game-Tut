using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject _ZoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        _ZoomCard = Instantiate(
            gameObject,
            new Vector2(
                Input.mousePosition.x,
                Input.mousePosition.y + 250
                ),
            Quaternion.identity
            );
        _ZoomCard.transform.SetParent(Canvas.transform, false);
        _ZoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = _ZoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344);
    }

    public void OnHoverExit()
    {
        Destroy(_ZoomCard);
    }
}
