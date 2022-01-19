using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent<Vector2> spaceshipMove;
    private static InputHandler instance;
    static InputHandler getInstance()
    {
        if(instance == null)
        {
            instance = new InputHandler();
        }
        return instance;
    }
    private void Awake()
    {
        spaceshipMove = new UnityEvent<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(Vector2.up);
            //spaceshipMove.AddListener(); //jak dodac listener z kodu?
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector2.left);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector2.right);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    void Move(Vector2 vector)
    {
        spaceshipMove.Invoke(vector);
    }
}