using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent<Vector2> spaceshipMove = new UnityEvent<Vector2>();
    public UnityEvent spaceshipShoot = new UnityEvent();
    private static InputHandler instance;

    public InputHandler getInstance()
    {
        if (instance == null)
        {
            //instance = new InputHandler();
            instance = this;
        }
        return instance;
    }
    private void Awake()
    {
        //spaceshipMove = new UnityEvent<Vector2>();
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
            spaceshipShoot.Invoke();
        }
    }

    void Move(Vector2 vector)
    {
        spaceshipMove.Invoke(vector);
    }
}