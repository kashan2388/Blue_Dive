using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearfish : Enemy
{
    // 큰 이빨 곰치
    [SerializeField] public float waitTime = 1.0f;  // 경고 시간
    [SerializeField] public GameObject warningBlock;    // 경고 블록
    private WaitForSeconds warningTime;
    private SpriteRenderer warningSprite;
    private void Start()
    {
        warningTime = new WaitForSeconds(waitTime);
        warningSprite = warningBlock.GetComponent<SpriteRenderer>();
    }

    public override void Attack()
    {
        // 플레이어에게 경고 후 애니메이션 및 피해
        StartCoroutine(IEWarning());
    }

    IEnumerator IEWarning()
    {
        while (true)
        {
            InPlayer();

            if(warningSprite.color.a <= 0f)
            {
                isAttack = true;
                StopCoroutine(IECoolTime());
                break;
            }
            else if (warningSprite.color.a >= 0.7f)
            {
                Damage(damage);
                warningSprite.color = new Color(warningSprite.color.r, warningSprite.color.g, warningSprite.color.b, 0);
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void InPlayer()
    {
        if(target != null)
        {
            warningSprite.color += new Color(0, 0, 0, 0.07f);
        }
        else
        {
            warningSprite.color += new Color(0, 0, 0, -0.07f);
        }
    }
}
