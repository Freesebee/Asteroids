using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent spaceshipMove;
    public UnityEngine.Events.UnityEvent spaceshipShoot;
    public UnityEngine.Events.UnityEvent spaceshipTurnLeft;
    public UnityEngine.Events.UnityEvent spaceshipTurnRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //spaceshipMove.AddListener(); //jak dodac listener z kodu?
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
