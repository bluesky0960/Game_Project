using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveSpeed;
    protected Transform tr;
    protected Vector3 vec3;
    

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 start = tr.position;
        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector3.x*moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate(Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            tr.Translate(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            tr.Translate(Vector3.back * moveSpeed);
        }
    }
}
