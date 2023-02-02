using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Variablen deklarieren
    private int xBound = 19;
    private int yBound = 10;

    public Snake sn;
    private List<Vector2> emptySpace = new List<Vector2>();

    void Start()
    {
        // Gibt dem Food Objekt eine zuf�llige Position wenn das Spiel startet
        RandomFoodPosition();
    }

    // Berechnet den 'Empty Space' (alle Positionen des Spielfelds, wo die Schlange gerade nicht ist)
    private void CalculateEmptySpace()
    {
        // entfernt alle Eintr�ge der Liste bevor der neue EmptySpace berechnet wird
        emptySpace.Clear();

        // f�gt alle m�glichen Position des Spielfelds der Liste hinzu
        for(int x = -xBound; x<= xBound; x++)
        {
            for (int y = -yBound; y <= yBound; y++)
            {
                emptySpace.Add(new Vector2(x, y));
            }
        }

        // entfernt die Positionen der Schlange aus der Liste
        foreach(GameObject segment in sn.segments)
        {
            int x = Mathf.RoundToInt(segment.transform.position.x);
            int y = Mathf.RoundToInt(segment.transform.position.y);
            Vector2 pos = new Vector2(x, y);
            emptySpace.Remove(pos);
        }
    }

    private void RandomFoodPosition()
    {
        // Berechnet EmptySpace
        CalculateEmptySpace();

        // Nimmt ein zuf�lliges Element aus 'emptySpace' und platziert dort das Food Objekt
        Vector2 newRandomPosition = emptySpace[Random.Range(0, emptySpace.Count)];
        transform.position = newRandomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Wenn der Trigger ausgef�hrt wird, bekommt das Food Objekt eine neue zuf�llige Position
        RandomFoodPosition();
        // und der Score wird erh�ht
        FindObjectOfType<GameManager>().IncreaseScore();
    }
}
