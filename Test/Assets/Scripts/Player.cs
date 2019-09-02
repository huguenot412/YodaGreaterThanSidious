using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private float _speed = 5;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float previousXPosition = transform.position.x;

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);
        transform.Translate(direction * _speed * Time.deltaTime);

        float xPosition = transform.position.x;

        if(xPosition != previousXPosition)
        {
            Run();
        }
        else
        {
            Idle();
        } 

        if(xPosition < previousXPosition)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }

    }

    void Run()
    {
        Debug.Log("Running");
        _anim.Play("Player_run");
    }

    void Idle()
    {
        Debug.Log("Idling");
        _anim.Play("Player_idle");
    }
}
