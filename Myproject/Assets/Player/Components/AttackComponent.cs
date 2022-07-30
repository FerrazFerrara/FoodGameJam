using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour {
    private bool canAttack = false;

    private double countdown;
    private bool isCountdown = false;
    private float countdownTimer;

    private float attackVelocity;
    private float attackTime;
    
    private Transform hitbox;
    private float attackRange;
    private float attackDamage;
    private LayerMask attackableLayer;

    private void Awake() {
        CharactersData data = GetComponent<CharacterContainer>().data;
        attackDamage = data.damage;
        countdownTimer = data.attackCountdown;
        attackVelocity = data.attackVelocity;
        attackTime = data.attackTime;
        hitbox = transform;
        attackRange = data.attackRange;
        if (data.isPlayer) {
            attackableLayer = LayerMask.GetMask("Enemy");
        } else {
            attackableLayer = LayerMask.GetMask("Player");
        }
    }

    private void FixedUpdate() {
        if (countdown < 0) {
            isCountdown = false;
        } else {
            countdown -= Time.deltaTime;
        }

        if (canAttack && !isCountdown) {
            countdown = countdownTimer;
            isCountdown = true;
            MeeleAttack();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void MeeleAttack() {
        Debug.Log("Atacou");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, attackRange, attackableLayer);

        foreach (Collider2D enemy in hitEnemies) {
            HealthComponent enemyHealth = enemy.gameObject.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(attackDamage);
            Debug.Log("Acertou");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        canAttack = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        canAttack = false;
    }
}
