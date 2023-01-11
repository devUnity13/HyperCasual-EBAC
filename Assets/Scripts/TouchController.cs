using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    private float _sideLimit = 4.5f;

    private void Update() 
    {
        if(Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPosition.x);
        }
        pastPosition = Input.mousePosition;

        if(transform.position.x > _sideLimit)
        {
            transform.position = new Vector3(_sideLimit,0,0);
        }
        else if(transform.position.x < -_sideLimit)
        {
            transform.position = new Vector3(-_sideLimit,0,0);
        }
    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
