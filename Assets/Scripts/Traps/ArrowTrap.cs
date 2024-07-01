using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;
        SoundManger.instance.PlaySound(arrowSound);

        int arrowIndex = FindArrow();
        if (arrowIndex != -1)
        {
            GameObject arrow = arrows[arrowIndex];
            arrow.transform.position = firePoint.position;
            arrow.GetComponent<EnemyProjectile>().ActivateProjectile();
        }
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return -1;
    }
}
