using UnityEngine;

public class PlayerFall : MonoBehaviour {

    public PlayerMovement movement;
    static float highScore = 0f;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Floor") {
            movement.enabled = false;
            float score = movement.GetScore();
            if (highScore < score)
                highScore = score;
            FindObjectOfType<GameManager>().EndGame(score, highScore);
        }
    }
}