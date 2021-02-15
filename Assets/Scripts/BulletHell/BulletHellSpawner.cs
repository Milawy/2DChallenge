using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawner : MonoBehaviour
{
    #region Variables

    [Header("BulletsPrefab")]
    public GameObject bulletPrefab;

    [Header("LimitBorders")]
    public Transform BorderMax;
    public Transform BorderMin;

    [Header("SpawnerParameters")]
    public float moveSpeed = 5f;
    public float shootingSpeed = 1f;

    [Header("CheckValues")]
    public bool movingDirection = true; //false = left, true = right
    public bool hasShot = false;

    #endregion

    void Update()
    {
        Move();
        if (!hasShot) AllowToShoot();
    }

    void Move()
    {
        if (transform.localPosition.x > BorderMax.localPosition.x) movingDirection = !movingDirection;
        else if (transform.localPosition.x < BorderMin.localPosition.x) movingDirection = !movingDirection;

        if (!movingDirection) transform.localPosition = new Vector2(transform.localPosition.x - moveSpeed * Time.deltaTime, transform.localPosition.y);
        else transform.localPosition = new Vector2(transform.localPosition.x + moveSpeed * Time.deltaTime, transform.localPosition.y);
    }

    void AllowToShoot()
    {
        hasShot = true;
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(shootingSpeed);
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        hasShot = false;
    }
}
