using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    //public string leaderboard_names;
    public static string leaderboard_scores;
    static int[] scores;

    public Text highScores;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadData()
    {
        //leaderboard_names = PlayerPrefs.GetString("names");
        leaderboard_scores = PlayerPrefs.GetString("scores");
        scores = parseLeaderboard();
    }
    public static int[] parseLeaderboard()
    {
        string s = leaderboard_scores;
        int c = 0;
        int[] parsed = new int[10];
        while (s.Contains(">"))
        {
            //int i = s.IndexOf(">");
            s = s.Substring(s.IndexOf(">") + 1);
            if (s.IndexOf(">") < 0) parsed[c] = int.Parse(s.Substring(0));
            else parsed[c] = int.Parse(s.Substring(0, s.IndexOf(">")));
            c++;

        }
        return parsed;
    }

    public void updateLeaderboard()
    {
        MainMenuScript.LoadData();

        string temp = "";

        for(int i = 0; i < 10; i++)
        {
            temp += "" + (i + 1) + ". " + scores[i] + "\n";
        }

        highScores.text = temp;
    }

}
