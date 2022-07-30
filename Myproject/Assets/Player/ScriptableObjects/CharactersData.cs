using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersData", menuName = "Character/New Character", order = 0)]
public class CharactersData : ScriptableObject {
    public float velocity;
    public float health;
    public float damage;
    public float defense;
}
