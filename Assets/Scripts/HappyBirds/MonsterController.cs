using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region Variables

    [Header("Visuals")]
    public Sprite deadMonsterSprite;
    public ParticleSystem deathParticles;
    
    [Header("Booleans")]
    public bool hasDied;

    [HideInInspector] public Vector3 startPosition;

    #endregion

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (shouldDieFromCollision(collision)) StartCoroutine(Die());
    }

    bool shouldDieFromCollision(Collision2D collision)
    {
        if (hasDied)
        {
            return false;
        }

        BirdController bird = collision.gameObject.GetComponent<BirdController>();
        if (bird != null)
        {
            return true;
        }

        if (collision.contacts[0].normal.y < -0.5) //Check collision with something falling on the monster
        {
            return true;
        }

        return false;
    }

    IEnumerator Die()
    {
        hasDied = true;
        deathParticles.Play();
        GetComponent<SpriteRenderer>().sprite = deadMonsterSprite;

        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);
    }
}
