using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputShift = KeyCode.LeftShift;
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererWalkUp;
    public AnimatedSpriteRenderer spriteRendererWalkUpRight;
    public AnimatedSpriteRenderer spriteRendererWalkUpLeft;
    public AnimatedSpriteRenderer spriteRendererWalkDown;
    public AnimatedSpriteRenderer spriteRendererWalkDownRight;
    public AnimatedSpriteRenderer spriteRendererWalkDownLeft;
    public AnimatedSpriteRenderer spriteRendererWalkLeft;
    public AnimatedSpriteRenderer spriteRendererWalkRight;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererUpRight;
    public AnimatedSpriteRenderer spriteRendererUpLeft;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererDownRight;
    public AnimatedSpriteRenderer spriteRendererDownLeft;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;

    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
    public AudioSource death;

    public Vector3 CameraCoordinates = new Vector3(-6f, 5f, -10f);

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputShift)) {
            if (Input.GetKey(inputUp) && Input.GetKey(inputLeft)) 
            {
                speed = 3f;
                Vector2 upleft = new Vector2(-1, 0.5f);
                SetDirection(upleft, spriteRendererUpLeft);
            } else if (Input.GetKey(inputUp) && Input.GetKey(inputRight)) 
            {
                speed = 3f;
                Vector2 upright = new Vector2(1, 0.5f);
                SetDirection(upright, spriteRendererUpRight);
            } else if (Input.GetKey(inputDown) && Input.GetKey(inputLeft)) 
            {
                speed = 3f;
                Vector2 downleft = new Vector2(-1, -0.5f);
                SetDirection(downleft, spriteRendererDownLeft);
            } else if (Input.GetKey(inputDown) && Input.GetKey(inputRight)) 
            {
                speed = 3f;
                Vector2 downright = new Vector2(1, -0.5f);
                SetDirection(downright, spriteRendererDownRight);
            } else if (Input.GetKey(inputUp))
            {
                speed = 3f;
                SetDirection(Vector2.up, spriteRendererUp);
            } else if (Input.GetKey(inputDown))
            {
                speed = 3f;
                SetDirection(Vector2.down, spriteRendererDown);
            } else if (Input.GetKey(inputLeft))
            {
                speed = 3f;
                SetDirection(Vector2.left, spriteRendererLeft);
            } else if (Input.GetKey(inputRight))
            {
                speed = 3f;
                SetDirection(Vector2.right, spriteRendererRight);
            } else
            {
                speed = 3f;
                SetDirection(Vector2.zero, activeSpriteRenderer);
            } 
        } else {
            if (Input.GetKey(inputUp) && Input.GetKey(inputLeft)) 
            {
                speed = 1.75f;
                Vector2 upleft = new Vector2(-1, 0.5f);
                SetDirection(upleft, spriteRendererWalkUpLeft);
            } else if (Input.GetKey(inputUp) && Input.GetKey(inputRight)) 
            {
                speed = 1.75f;
                Vector2 upright = new Vector2(1, 0.5f);
                SetDirection(upright, spriteRendererWalkUpRight);
            } else if (Input.GetKey(inputDown) && Input.GetKey(inputLeft)) 
            {
                speed = 1.75f;
                Vector2 downleft = new Vector2(-1, -0.5f);
                SetDirection(downleft, spriteRendererWalkDownLeft);
            } else if (Input.GetKey(inputDown) && Input.GetKey(inputRight)) 
            {
                speed = 1.75f;
                Vector2 downright = new Vector2(1, -0.5f);
                SetDirection(downright, spriteRendererWalkDownRight);
            } else if (Input.GetKey(inputUp))
            {
                speed = 1.75f;
                SetDirection(Vector2.up, spriteRendererWalkUp);
            } else if (Input.GetKey(inputDown))
            {
                speed = 1.75f;
                SetDirection(Vector2.down, spriteRendererWalkDown);
            } else if (Input.GetKey(inputLeft))
            {
                speed = 1.75f;
                SetDirection(Vector2.left, spriteRendererWalkLeft);
            } else if (Input.GetKey(inputRight))
            {
                speed = 1.75f;
                SetDirection(Vector2.right, spriteRendererWalkRight);
            } else
            {
                speed = 1.75f;
                SetDirection(Vector2.zero, activeSpriteRenderer);
            }
        }
        CameraCoordinates = rigidbody.position;
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererWalkUp.enabled = spriteRenderer == spriteRendererWalkUp;
        spriteRendererWalkUpLeft.enabled = spriteRenderer == spriteRendererWalkUpLeft;
        spriteRendererWalkUpRight.enabled = spriteRenderer == spriteRendererWalkUpRight;
        spriteRendererWalkDown.enabled = spriteRenderer == spriteRendererWalkDown;
        spriteRendererWalkDownLeft.enabled = spriteRenderer == spriteRendererWalkDownLeft;
        spriteRendererWalkDownRight.enabled = spriteRenderer == spriteRendererWalkDownRight;
        spriteRendererWalkLeft.enabled = spriteRenderer == spriteRendererWalkLeft;
        spriteRendererWalkRight.enabled = spriteRenderer == spriteRendererWalkRight;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererUpLeft.enabled = spriteRenderer == spriteRendererUpLeft;
        spriteRendererUpRight.enabled = spriteRenderer == spriteRendererUpRight;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererDownLeft.enabled = spriteRenderer == spriteRendererDownLeft;
        spriteRendererDownRight.enabled = spriteRenderer == spriteRendererDownRight;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
            death.Play();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererWalkUp.enabled = false;
        spriteRendererWalkUpLeft.enabled = false;
        spriteRendererWalkUpRight.enabled = false;
        spriteRendererWalkDown.enabled = false;
        spriteRendererWalkDownLeft.enabled = false;
        spriteRendererWalkDownRight.enabled = false;
        spriteRendererWalkLeft.enabled = false;
        spriteRendererWalkRight.enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererUpLeft.enabled = false;
        spriteRendererUpRight.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererDownLeft.enabled = false;
        spriteRendererDownRight.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;

        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }
}
