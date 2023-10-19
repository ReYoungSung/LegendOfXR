using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float speed = 5f; // Corrected the order of "public" and "float" here.

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code (if needed) goes here.
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed;
        transform.Translate(movement * Time.deltaTime);
    }
}
