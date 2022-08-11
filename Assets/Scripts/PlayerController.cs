using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 offset;
    Rigidbody2D rb;
    bool touch = true;
    public int coinsEarn;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coinsEarn = 0;
    }

    void FixedUpdate()
    {
        if (transform.position.x <= -12)
        {
            gameObject.transform.Translate(1, 0, 0);
            touch = false;
        }
        else if (transform.position.x >= 12)
        {
            gameObject.transform.Translate(-1, 0, 0);
            touch = false;
        }
        if (transform.position.y <= -5f)
        {
            gameObject.transform.Translate(0, 0.5f, 0);
            touch = false;
        }
        else if (transform.position.y >= 15)
        {
            gameObject.transform.Translate(0, -0.5f, 0);
            touch = false;
        }
    }

    void OnMouseDown()
    {
        touch = true;
        offset = transform.position - MouseWorldPosition();
        rb.gravityScale = 0;
    }

    void OnMouseUp()
    {
        rb.gravityScale = 1;
    }

    void OnMouseDrag()
    {
        if (touch)
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
