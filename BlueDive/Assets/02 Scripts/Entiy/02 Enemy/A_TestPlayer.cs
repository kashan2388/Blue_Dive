using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TestPlayer : MonoBehaviour
{
    [SerializeField] public float speed;

    void Update()
    {
        Move();   
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * 5 * speed * Time.deltaTime;
    }
}
