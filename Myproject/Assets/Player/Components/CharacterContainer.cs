using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour {
    public CharactersData data;

    // public void SetModifier(float modifier, EnemyType enemyType) {
        // settar os novos atributos dos inimigos
        // com base no tipo de inimigo
    // }

    public void SetNewStats(CharactersData newData) {
        data = newData;
    }
}
