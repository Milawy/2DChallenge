using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    #region Variables

    [Header("Game Camera")]
    public Camera birdsCamera;

    [Header("UI")]
    public GameObject birdsUI;

    [Header("Launch Parameters")]
    public float launchForce = 500f;
    public float maxDragDistance = 2f;

    [Header("Booleans")]
    public bool alreadyCollided;
    public bool isVictory;

    Vector2 birdStartPosition;
    Vector3[] monstersStartPosition;

    Rigidbody2D birdRigidBody2D;
    SpriteRenderer birdSpriteRenderer;
    MonsterController[] monsters;

    #endregion

    void Awake()
    {
        birdRigidBody2D = GetComponent<Rigidbody2D>();
        birdSpriteRenderer = GetComponent<SpriteRenderer>();

        monsters = FindObjectsOfType<MonsterController>();
    }

    void Start()
    {
        birdStartPosition = birdRigidBody2D.position;
        /*
        int i = 0;
        foreach (var monster in monsters)
        {
            monstersStartPosition[i++] = monster.gameObject.transform.position;
        }

        int j = 0;
        foreach (var crate in crates)
        {
            cratesStartPosition[j++] = crate.startPosition;
        }*/
    }

    void Update()
    {
        if (allMonstersDied())
        {
            isVictory = true;
            birdsUI.SetActive(true);
        }
    }

    public bool allMonstersDied()
    {
        foreach (var monster in monsters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void OnMouseDown()
    {
        birdSpriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = birdRigidBody2D.position;
        Vector2 direction = birdStartPosition - currentPosition;
        direction.Normalize();

        birdRigidBody2D.isKinematic = false;
        birdRigidBody2D.AddForce(direction * launchForce);

        birdSpriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = birdsCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        
        float dragDistance = Vector2.Distance(desiredPosition, birdStartPosition);
        if(dragDistance > maxDragDistance)
        {
            Vector2 launchDirection = desiredPosition - birdStartPosition;
            launchDirection.Normalize();
            desiredPosition = birdStartPosition + (launchDirection * maxDragDistance);
        }

        if (desiredPosition.x > birdStartPosition.x)
        {
            desiredPosition.x = birdStartPosition.x;
        }

        birdRigidBody2D.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!alreadyCollided)
        {
            StartCoroutine(ResetAfterDelay());
        }
    }

    IEnumerator ResetAfterDelay()
    {
        alreadyCollided = true;

        yield return new WaitForSeconds(3);

        birdRigidBody2D.isKinematic = true;
        birdRigidBody2D.position = birdStartPosition;
        birdRigidBody2D.velocity = Vector2.zero;
        
        alreadyCollided = false;    
    }
}