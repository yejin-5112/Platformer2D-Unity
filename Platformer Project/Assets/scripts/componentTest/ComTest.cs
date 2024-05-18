using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{

    public GameObject TestObject;

    private void Awake()
    {
        Debug.Log("Awake ����");
        TestObject = new GameObject();
    }

    private void Start()
    {
        Debug.Log("Start ����");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable ����");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate ����");
    }

    private void Update()
    {
        Debug.Log("Update ����");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate ����");
    }
}
