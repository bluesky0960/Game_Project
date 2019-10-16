using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected Transform tr;
    protected Vector3 vector;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), tr.position.z);

            tr.Translate(Vector3.up * moveSpeed * vector.y * Time.deltaTime, Space.Self);
            tr.Translate(Vector3.right * moveSpeed * vector.x * Time.deltaTime, Space.Self);

            
        }
    }
}
