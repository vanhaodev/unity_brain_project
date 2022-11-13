using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueCal : MonoBehaviour
{

    Vector2 target;
    [SerializeField] Sprite[] bubble;

    string value;
    private void Start()
    {
        StartMove();
        InvokeRepeating("ResetValue", 0f, 10f);
        GetComponent<SpriteRenderer>().sprite = bubble[Random.Range(0, 3)];

    }

    void ResetValue()
    {
        int rand = Random.Range(1, 10);
        switch (Random.Range(1, 5))
        {
            case 1:
                value = "+" + rand;
                break;
            case 2:
                value = "-" + rand;
                break;
            case 3:
                value = "x" + rand;
                break;
            case 4:
                value = "/" + rand;
                break;
        }
        GetComponentInChildren<Text>().text = value;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
    // tự động di chuyển đến vị trí ngẫu nhiêm sau vài giây
    void StartMove()
    {
        target = new Vector2(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - 2f, transform.position.y + 2f));
        Invoke("StartMove", Random.Range(1f, 3f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // chạm collision thì đổi hướng
        target = new Vector2(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - 2f, transform.position.y + 2f));
    }
}
