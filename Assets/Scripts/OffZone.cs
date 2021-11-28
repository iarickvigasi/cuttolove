using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffZone : MonoBehaviour
{
    [SerializeField] string playerTag = "HeartBox";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OffZone collided with: " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals(playerTag))
        {
            SceneManager.Instance.gameController.OnBoxMissed();
        }
    }
}
