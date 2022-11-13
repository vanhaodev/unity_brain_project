using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionObjectType
{
    Cup = 0,
    Trap = 1,
}
public class CollisionObject : MonoBehaviour
{
    public CollisionObjectType objectType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch(objectType)
            {
                case CollisionObjectType.Cup:
                    PopupManager.Instance.OnWin();
                    break;
                case CollisionObjectType.Trap:
                    PopupManager.Instance.OnLose();
                    break;
            }
            CommandManager.Instance.ResetBall();
        }

        if (collision.gameObject.tag == "Basketball")
        {
            switch (objectType)
            {
                case CollisionObjectType.Cup:
                    PopupManager.Instance.OnWin();
                    break;
                case CollisionObjectType.Trap:
                    PopupManager.Instance.OnLose();
                    break;
            }
            GameObject.FindGameObjectWithTag("Basketball").transform.position = new Vector3(0, 0, GameObject.FindGameObjectWithTag("Basketball").transform.position.z);
        }
    }
}
