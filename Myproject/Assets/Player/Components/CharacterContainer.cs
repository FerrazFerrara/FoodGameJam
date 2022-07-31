using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour {
    public CharactersData data;

    public void SetModifier(float modifier, CharacterType characterType) {
        switch (characterType) {
            case CharacterType.Carrot:
                break;
            case CharacterType.Broccoli:
                break;
            default:
                break;
        }
    }

    public void SetNewStats(CharactersData newData) {
        data = newData;
    }
}
