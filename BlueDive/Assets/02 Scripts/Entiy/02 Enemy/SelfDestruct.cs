using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Enemy
{
    // ±â·ÚÆø
    [SerializeField] public float range = 3.0f;    // °Å¸®
    private WaitForSeconds waitingTime = new WaitForSeconds(3.0f);  // Æø¹ß ´ë±â½Ã°£

    public override void Attack()
    {
        StartCoroutine(IEBoom());
    }

    IEnumerator IEBoom()
    {
        yield return waitingTime;

        // Æø¹ß ÀÌÆÑÆ® »ý¼º

        if (Distance() <= range)
        {
            Damage(damage);
        }

        Destroy(this);
    }

    private float Distance()
    {
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position);

        return distance;
    }
}
