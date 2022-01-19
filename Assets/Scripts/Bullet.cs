using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 24f;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(/*kolizja*/true)
        {
            gameObject.SetActive(false);
        }
    }
}
