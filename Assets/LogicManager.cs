using UnityEngine;
using UnityEngine.UI; // import UI elements from unity
using UnityEngine.SceneManagement;

/*
* This will track user score
*/

// we don't need start and update methods we will need events only
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameAreaPrefab;
    private BirdScript birdReference;

    [ContextMenu("IncreaseScore") ] // this let the function to be run from unity, this will be found as function in the 3 dot in logic script in inspector to check the increase for debugging
    public void addScore(int score){
        playerScore += score;
        scoreText.text = $"{playerScore}";
    }

    public void setBirdInstance(BirdScript bird){
        this.birdReference = bird;
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the current scene
    }

    void Start(){
         // initialize GameArea using the prefab transform position within unity inspector
        Instantiate(gameAreaPrefab, gameAreaPrefab.transform.position, gameAreaPrefab.transform.rotation);
        this.playerScore = 0;
        scoreText.text = $"{playerScore}";
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        this.birdReference.birdIsAlive = false;
    }
}
