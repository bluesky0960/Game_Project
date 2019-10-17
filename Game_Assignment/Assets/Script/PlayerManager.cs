using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MoveObject
{
    public bool isDie = false;
    //static public PlayerManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(!isDie)
        tr = GetComponent<Transform>();
        boxCollder = GetComponent<BoxCollider2D>();
        //instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenChk();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), tr.position.z);
            tr.Translate(Vector3.up * moveSpeed * vector.y * Time.deltaTime, Space.Self);
            tr.Translate(Vector3.right * moveSpeed * vector.x * Time.deltaTime, Space.Self);
        }
        
    }

    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        if (worlpos.y < 0.05f) worlpos.y = 0.05f;
        if (worlpos.y > 0.95f) worlpos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
