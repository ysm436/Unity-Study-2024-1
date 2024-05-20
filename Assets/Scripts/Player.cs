
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int speed;
    Vector3 directionVector;

    private void Update()
    {
        directionVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        transform.position += directionVector * Time.deltaTime * speed;
    }

}
*/