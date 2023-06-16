using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 pos;
    private float moveH, moveV;
    private PlayerAnimation playerAnimation;    
    public float moveSpeed = 1.0f;
    /*public Tilemap tilemap;*/
    public string TargetObjectName;
    public string TargetObjectName2;
    public float speedIncreaseAmount = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        /*if (tilemap.GetTile(tilemap.WorldToCell(transform.position)))
        {
            if (tilemap.GetTile(tilemap.WorldToCell(transform.position)).name == "cave-sliced_21")
            {
                transform.position = pos;
            }
        }*/
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        Vector2 inputVector = new Vector2(x: moveH, y: moveV).normalized * moveSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(currentPos + inputVector);

        playerAnimation.SetDirection(new Vector2(x: moveH, y: moveV));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == TargetObjectName)
        {
            moveSpeed *= 2;
        }

        
        
        if (collision.gameObject.name == TargetObjectName2)
        {
            this.gameObject.transform.Translate(pos);
        }
    }
}
