using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// neue Library hinzuf�gen um mit TextMeshPro Elementen arbeiten zu k�nnen
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variablen deklarieren
    public Snake sn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private int score;
    private int highscore;

    private void Start()
    {
        // wei�t der Variable 'highscore' den gespeicherten Wert zu und passt den Text an (bei Start des Spiels)
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    // Funktion, die das Spiel restartet
    public void RestartGame()
    {
        // l�scht alle Segmente au�er dem Kopf aus dem Spiel
        for(int i = 1; i < sn.segments.Count; i++)
        {
            Destroy(sn.segments[i]);
        }

        // entfernt alle Elemente au�er dem 0-ten (Kopf) aus der Liste
        sn.segments.RemoveRange(1, sn.segments.Count - 1);

        // platziert den Kopf der Schlange in der Mitte des Spielfelds
        sn.transform.position = Vector2.zero;

        // setzt score wieder auf 0 und passt den scoreText an
        score = 0;
        scoreText.text = score.ToString();

        // speichert highscore
        SaveHighscore();
    }

    public void IncreaseScore()
    {
        // erh�ht score um 1 und passt scoreText an
        score++;
        scoreText.text = score.ToString();

        // wenn score > highscore ist, wird highscore = score gesetzt und der highscoreText angepasst
        if(score > highscore)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
        }
    }

    // speichert den highscore, wenn der gerade erreichte highscore gr��er ist als der,
    // der bereits abgespeichert ist
    private void SaveHighscore()
    {
        if(highscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
