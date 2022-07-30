using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour {
    private bool canAttack = false;

    private double countdown;
    private bool isCountdown = false;
    private float countdownTimer;

    private float attackCount = 0;
    private float attackVelocity;
    private float attackTime;
    
    private Transform hitbox;
    private float attackRange;
    private LayerMask attackableLayer;

    private void Awake() {
        CharactersData data = GetComponent<CharacterContainer>().data;

        countdownTimer = data.attackCountdown;
        attackVelocity = data.attackVelocity;
        attackTime = data.attackTime;

        hitbox = GetComponent<Player>().hitBox;

        attackRange = 1.5f;
        attackableLayer = LayerMask.GetMask("Enemy");
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
            Attack();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(hitbox.position, attackRange);
    }

    private void MeeleAttack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitbox.position, attackRange, attackableLayer);

        foreach (Collider2D enemy in hitEnemies) {
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
