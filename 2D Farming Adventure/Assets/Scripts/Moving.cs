using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float movement_speed = 10.0f;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /// <summary>
    /// This function changes the position of the object the script is added to, when the moving controls (e.g.: W-A-S-D) are used 
    /// </summary>
    void Update()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");

        Vector2 position = rigidbody.position;

        position.x = position.x + movement_speed * horizontalValue * Time.deltaTime; //Time.deltaTime to change "speed" per frame in "speed" per second
        position.y = position.y + movement_speed * verticalValue * Time.deltaTime;

        rigidbody.MovePosition(position);
    }
}
