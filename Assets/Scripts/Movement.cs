using UnityEngine;

public class Movement : MonoBehaviour
{
    private enum MovementKeys
    {
        WASD,
        ArrowKeys,
        NumpadKeys,
    }

    [Header("Movement Settings")]
    [SerializeField] private MovementKeys movementKeys = MovementKeys.WASD;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.Q;
    [SerializeField] private KeyCode rotateRightKey = KeyCode.E;
    [SerializeField] private KeyCode changeColorKey = KeyCode.R;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private SpriteRenderer sr;

    // Variables para resetear el color si se mantiene presionada la tecla
    private float holdKeyTime = 0f;
    private const float holdThreshold = 0.5f;

    void Start()
    {

    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(rotateLeftKey))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
        if (Input.GetKeyDown(rotateRightKey))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }

        // Controlamos el tiempo que se mantiene presionada la tecla para cambiar el color
        if (Input.GetKey(changeColorKey))
        {
            holdKeyTime += Time.deltaTime;
        }

        // Si se suelta antes del umbral, cambio de color. Si se mantiene presionada, se resetea
        if (Input.GetKeyUp(changeColorKey))
        {
            if (holdKeyTime < holdThreshold)
            {
                sr.color = Random.ColorHSV();
            }
            else
            {
                sr.color = Color.white;
            }
            holdKeyTime = 0f;
        }
    }

    void Move()
    {
        float step = speed * Time.deltaTime;

        if (movementKeys == MovementKeys.WASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * step);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * step);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * step);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * step);
            }
        }
        else if (movementKeys == MovementKeys.ArrowKeys)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * step);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * step);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * step);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * step);
            }
        }
        else if (movementKeys == MovementKeys.NumpadKeys)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * step);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * step);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.down * step);
            }
            if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(Vector3.left * step);
            }
        }
    }

    public float GetSpeed() 
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        switch (speed)
        {
            case < 0.5f:
                speed = 0.5f;
                break;
            case > 20.0f:
                speed = 20.0f;
                break;
            default:
                this.speed = speed;
                break;
        }
    }
}
