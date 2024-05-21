using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trap_Saw : Trap
{
    /*public Animator anim;
    public Transform[] movePositions;
    public float speed = 5f;
    public int moveIndex = 0;
    public readonly int workParameterHash = Animator.StringToHash("isWorking");*/

    //----------------------------------------------------
    private Animator anim;
    [SerializeField] private Transform[] movePositions;
    [SerializeField] private float speed;
    public readonly int workParameterHash = Animator.StringToHash("isWorking");

    private SpriteRenderer spriteRenderer;
    private int moveIndex;
    private bool goingForward;
    //----------------------------------------------------


    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveIndex = 0;
    }

    private void Update()
    {
        //MoveTrap();

        anim.SetBool(workParameterHash, isWorking);

        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePositions[moveIndex].position) < 0.15f)
        {
            if (moveIndex == 0)
            {
                Flip(goingForward);
                goingForward = true;
            }

            if (goingForward)
                moveIndex++;
            else
                moveIndex--;

            if (moveIndex >= movePositions.Length)
            {
                moveIndex = movePositions.Length - 1;
                goingForward = false;
            }
        }
    }

    private void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
        }

        if (movePositions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
    }

    /*protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }*/

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    private void Flip(bool isFlip)
    {
        spriteRenderer.flipX = isFlip;
    }
}
