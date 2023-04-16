using UnityEngine;

public class PlayerFall : MonoBehaviour {

    public PlayerMovement movement;
    static int highScore = 0;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Floor") {
            movement.enabled = false;
            int score = movement.GetScore();
            if (highScore < score)
                highScore = score;
            FindObjectOfType<GameManager>().EndGame(score, highScore);
        }
    }
}