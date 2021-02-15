using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellBulletController : MonoBehaviour
{
    #region Variables

    [Header("BulletsParameters")]
    public float moveSpeed = 6f;
    public float livingTime = 2f;

    #endregion

    void Start()
    {
        Destroy(gameObject, livingTime);
    }

    void Update()
    {
        Vector3 currentPosition = transform.localPosition;
        currentPosition.y -= moveSpeed * Time.deltaTime;
        transform.localPosition = currentPosition;
    }
}
