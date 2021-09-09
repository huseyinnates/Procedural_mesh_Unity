using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    public CharacterController control;
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        Vector3 move = axisX * transform.right + axisY * transform.forward;
        control.Move(move * speed * Time.deltaTime);

    }
}
