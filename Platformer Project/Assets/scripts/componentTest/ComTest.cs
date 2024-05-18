using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{

    public GameObject TestObject;

    private void Awake()
    {
        Debug.Log("Awake 角青");
        TestObject = new GameObject();
    }

    private void Start()
    {
        Debug.Log("Start 角青");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 角青");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 角青");
    }

    private void Update()
    {
        Debug.Log("Update 角青");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 角青");
    }
}
