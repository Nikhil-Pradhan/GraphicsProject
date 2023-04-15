using UnityEngine;

public class PlayerFall : MonoBehaviour {

    public PlayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Floor") {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame(movement.GetScore());
        }
    }
}