using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _playerRigidBody;
    private PolygonCollider2D _polygonCollider;
    private SpriteRenderer _spriteRenderer;
    private Animator _playerAnimator;
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<Animator>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetAnimation()
    {
        if()
    }

}
