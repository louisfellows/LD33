using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class RecordHighScore : MonoBehaviour {

	public Text highScoreDisplay;
	public string fileName = "highscore" ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void recordAndDisplayScore(int newScore) {
		string hiscoreString = "0";
		
		if (File.Exists(fileName))
		{
			StreamReader reader = new StreamReader(fileName);
			try   
			{    
				hiscoreString = reader.ReadLine();
			}      
			
			catch 
			{ 
				hiscoreString = "0";
			}
			finally
			{
				reader.Close();
			}
		}
		
		int highscore = int.Parse(hiscoreString);
		
		bool newHighScore = false;
		if (newScore > highscore) {
			newHighScore = true;
			
			StreamWriter writer = new StreamWriter(fileName,false);
			writer.WriteLine(newScore.ToString());
			writer.Close();
		}
		
		if (newHighScore) {
			highScoreDisplay.text = "Your score: " + newScore.ToString() +", Previous best: " + highscore + ". NEW HIGH SCORE!";	
		} else {
			highScoreDisplay.text = "Your score: " + newScore.ToString() +", Previous best: " + highscore;
		}
	}
}
