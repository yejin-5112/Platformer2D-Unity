using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;
    public float speed = 5f;
    public int moveIndex = 0;
    public readonly int workParameterHash = Animator.StringToHash("isWorking");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveTrap();
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
}
