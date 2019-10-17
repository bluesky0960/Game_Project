using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//오른쪽 x=1 왼쪽 x=-1, 위쪽 y=1 아래쪽 y=-1

public class MoveObject : MonoBehaviour
{

    public BoxCollider2D boxCollder;
    public float moveSpeed;
    protected Vector3 vector;
    protected Transform tr;
    public LayerMask layerMask;

    protected bool CheckCollision()
    {
        RaycastHit2D hit;

        Vector2 start = tr.position;
        Vector2 end = start + new Vector2(vector.x * moveSpeed * Time.deltaTime, vector.y * moveSpeed * Time.deltaTime);

        boxCollder.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollder.enabled = true;
        if (hit.transform == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

