using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private float ballForce;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseCLick();
        }
        
    }
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void LaunchOnMouseCLick()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.velocity = new Vector2(xPush, yPush);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(randomFactor, 0),
                                            Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rb.velocity += velocityTweak;
        }
    }
}
