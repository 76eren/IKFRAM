using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public string[] animClips = new string[2];
    public float speed = 2.0f;
    private Animation anim;


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            ReverseGravity(other.gameObject);
            GetComponent<Animator>().Play("Rotate");
        }
    }

    public static void ReverseGravity(GameObject player) 
    {        
        PlayerStates playerStates = player.GetComponent<PlayerStates>();
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        rigidbody2D.gravityScale = playerStates.gravityScale * -1;
        playerStates.gravityScale = rigidbody2D.gravityScale;
        
        Transform transform = player.GetComponent<Transform>();
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
        
        playerStates.jumpDirection.y *= -1;

        Quaternion rotation = transform.localRotation;
        rotation.y *= -1;
        transform.localRotation = rotation;
    }
}

