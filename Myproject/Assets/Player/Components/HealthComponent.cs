using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {
    private float maxHealth;
    private float health;
    private float defense;

    private void Awake() {
        CharactersData data = GetComponent<CharacterContainer>().data;
        maxHealth = data.health;
        health = data.health;
        defense = data.defense;
    }

    public void TakeDamage(float fullDamage) {
        float defensePercentage = defense * 0.05f;
        float trueDamange = fullDamage * (1.0f - defensePercentage);
        health -= trueDamange;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
