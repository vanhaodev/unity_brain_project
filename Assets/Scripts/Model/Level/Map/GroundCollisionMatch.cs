using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Cho collider nó tự match theo size
/// </summary>
public class GroundCollisionMatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var collider = GetComponent<BoxCollider2D>();
        var objectSize = GetComponent<SpriteRenderer>();
        collider.size = new Vector2(objectSize.size.x, objectSize.size.y);
    }

}
