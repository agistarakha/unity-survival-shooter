using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float initialSpeed = 6f;
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    float speedBoostDuration = 5.0f;
    float speedBoostTimer = 0f;
    bool powerUpConsumed = false;
    PlayerHealth playerHealth;


    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");

        anim = GetComponent<Animator>();

        playerRigidbody = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (powerUpConsumed)
        {
            speedBoostTimer += Time.deltaTime;
            if (speedBoostTimer > speedBoostDuration)
            {
                powerUpConsumed = false;
                speedBoostTimer = 0;
                ResetSpeed();
            }
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        // Move(h, v);
        Turing();
        // Animating(h, v);
    }

    public void Move(float h, float v)
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turing()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }

        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    public void SpeedBoost()
    {
        speed = speed * 3;
        powerUpConsumed = true;
    }

    public void ResetSpeed()
    {
        speed = initialSpeed;
    }

}
