using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    GameObject target;
    Vector3 dirToTarget;
    float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
        speed = Random.Range(1.0f, 10.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            GameManager1.Instance.HealthDown();
            Destroy(this.gameObject);
        }
    }

    private float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}
