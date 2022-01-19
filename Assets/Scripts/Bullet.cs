using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 24f;
    [SerializeField] private Rigidbody2D rb;

    public void Awake()
    {
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.gravityScale = 0;
    }

    public void Fire(Vector2 position, float rotation)
    {
        gameObject.SetActive(true);
        rb.MovePosition(position);
        rb.SetRotation(rotation);
        rb.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
        StartCoroutine(BulletTime());
    }
    
    private IEnumerator BulletTime()
    {
        float timer = 3f;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        
        gameObject.SetActive(false);
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(/*kolizja*/true)
        {
            gameObject.SetActive(false);
        }
    }
}
