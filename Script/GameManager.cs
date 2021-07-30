using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillzSDK;


public class GameManager : MonoBehaviour
{
	
	public int score;
	public static GameManager inst;
	
	[SerializeField] Text scoreText;
	[SerializeField] PlayerMovement playerMovement;
	[SerializeField] GroundSpawner groundTile;
	
	public void IncrementScore(){
		score++;
		scoreText.text = "SCORE: " + score;
		if(SkillzCrossPlatform.IsMatchInProgress()){
			SkillzCrossPlatform.UpdatePlayersCurrentScore(score);
		}
		// increase the player's speed
		playerMovement.speed += playerMovement.speedIncreasePerPoint;
	}
	/*if(SkillzCrossPlatform.IsMatchInProgress()){
				SkillzCrossPlatform.ReportFinalScore(score);
			}
			*/
	
	private void Awake(){
		inst = this;//singleton
		
	}
    // Start is called before the first frame update
    void Start()
    {
       playerMovement.transform.position = new Vector3(0,0,5);
	   //groundTile = GameObject.FindObjectOfType<GroundSpawner>();
		
    }
	
	public void Play(){
		SkillzCrossPlatform.LaunchSkillz(new GameController());
	}
	public void GetSkillzMatchParams(){
		SkillzCrossPlatform.GetMatchRules();
	}
	public void AbortSkillzMatch(){
		SkillzCrossPlatform.AbortMatch();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
