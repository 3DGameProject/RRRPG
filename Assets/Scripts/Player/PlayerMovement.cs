using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
    }
}
