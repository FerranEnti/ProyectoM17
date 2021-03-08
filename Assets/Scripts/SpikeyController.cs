using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyController : MonoBehaviour
{
    public enum Direction { NONE, UP, DOWN, RIGHT, LEFT, SPACE, ATTACK };
    public Direction SpikeyDirection = Direction.NONE;

    private float baseSpeed = 4.5f;
    private float currentSpeedV = 0.0f;
    private float currentSpeedH = 0.0f;
    private float thrust = 4.5f;

    public bool canJump = false;
    private bool canClimb = false;

    KeyCode upButton = KeyCode.W;
    KeyCode downButton = KeyCode.S;
    KeyCode rightButton = KeyCode.D;
    KeyCode leftButton = KeyCode.A;
    KeyCode spaceButton = KeyCode.Space;
    KeyCode attackButton = KeyCode.Q;

    private Rigidbody2D rigidBody;
    //private AudioSource audio;

    public GameObject pua;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SpikeyDirection = Direction.NONE;

        if (Input.GetKey(upButton) && canClimb)
        {
            SpikeyDirection = Direction.UP;
        }
        else if (Input.GetKey(downButton) && canClimb)
        {
            SpikeyDirection = Direction.DOWN;
        }

        if (Input.GetKey(rightButton))
        {
            SpikeyDirection = Direction.RIGHT;
        }
        else if (Input.GetKey(leftButton))
        {
            SpikeyDirection = Direction.LEFT;
        }

        if (Input.GetKeyDown(spaceButton) && canJump)
        {
            jump();
        }

        if (Input.GetKeyDown(attackButton))
        {
            attack();
        }

    }

    private void jump()
    {
        // rigidBody.transform.position.y = new Vector3(transform.position.x, transform.position.y + 5, 0);
        float delta = Time.fixedDeltaTime * 1000;
        rigidBody.AddForce(new Vector2(currentSpeedH, currentSpeedV) * thrust * delta, ForceMode2D.Impulse);
        canJump = false;

    }
    private void attack()
    {
        GameObject Pua1 = Instantiate(pua, transform.position + transform.up, Quaternion.Euler(0, 0, 0));
        GameObject Pua2 = Instantiate(pua, transform.position + transform.up, Quaternion.Euler(0, 0, 45));
        GameObject Pua3 = Instantiate(pua, transform.position + transform.up, Quaternion.Euler(0, 0, 325));
        GameObject Pua4 = Instantiate(pua, transform.position + transform.up, Quaternion.Euler(0, 0, 280));
        GameObject Pua5 = Instantiate(pua, transform.position + transform.up, Quaternion.Euler(0, 0, 90));
        Destroy(Pua1, 3);
        Destroy(Pua2, 3);
        Destroy(Pua3, 3);
        Destroy(Pua4, 3);
        Destroy(Pua5, 3);
    }


    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;

        currentSpeedV = 0;
        currentSpeedH = 0;

        switch (SpikeyDirection)
        {
            default: break;
            case Direction.UP:
                currentSpeedV = baseSpeed;
                break;
            case Direction.DOWN:
                currentSpeedV = -1 * baseSpeed;
                break;
            case Direction.RIGHT:
                currentSpeedH = baseSpeed;
                break;
            case Direction.LEFT:
                currentSpeedH = -1 * baseSpeed;
                break;
        }
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tilemap")
        {
            canJump = true;
        }

        if (collision.gameObject.tag == "Nombre del gameobject qe permite escalar")
        {
            canClimb = true;
        }


    }
}
