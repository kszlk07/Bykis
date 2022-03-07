using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnTheGround : MonoBehaviour
{
    private BoxCollider2D coll;
    [SerializeField] private LayerMask ground;

    private bool isGrounded;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public bool GetIsGroundedBool()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}
