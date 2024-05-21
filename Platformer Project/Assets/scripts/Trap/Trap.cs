using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    protected bool isWorking;

    protected private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            Debug.Log("Player가 함정에 피격 당함. (Trigger충돌)");
    }
}
