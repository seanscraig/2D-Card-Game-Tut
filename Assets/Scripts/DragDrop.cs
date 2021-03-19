using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject _DropZone;
    private GameObject _StartParent;

    private Vector2 _startPosition;
    
    private bool _isDragging = false;
    private bool _isOverDropZone = false;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    void Update()
    {
        if (_isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isOverDropZone = true;
        _DropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isOverDropZone = false;
        _DropZone = null;
    }

    public void StartDrag()
    {
        _StartParent = transform.parent.gameObject;
        _startPosition = transform.position;
        _isDragging = true;
    }

    public void EndDrag()
    {
        _isDragging = false;

        if (_isOverDropZone)
        {
            transform.SetParent(_DropZone.transform, false);
        }
        else
        {
            transform.position = _startPosition;
            transform.SetParent(_StartParent.transform, false);
        }
    }
}
