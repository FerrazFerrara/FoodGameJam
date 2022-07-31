using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
    private float velocity;
    private Rigidbody2D body;
    private Transform focus;

    private void Awake() {
        CharactersData data = GetComponent<CharacterContainer>().data;
        body = GetComponent<Rigidbody2D>();
        velocity = data.velocity;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        if (focus != null) {
            float step = velocity * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position, 
                focus.position, 
                step);
        }
    }

    public void changeFocus(Transform newFocus) {
        focus = newFocus;
    }
}
