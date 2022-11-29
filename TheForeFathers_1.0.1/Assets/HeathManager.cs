using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathManager : MonoBehaviour
{
    private GameObject heartTemplate;
    [SerializeField] private int maxHealth;
    private int health;
    private List<GameObject> hearts;

    // Start is called before the first frame update
    void Awake()
    {
        hearts = new List<GameObject>();
        health = maxHealth;
        heartTemplate = transform.GetChild(0).gameObject;

        
        for(int i = 0; i < maxHealth; i++)
        {
            Vector3 spawnCoords = new Vector3(-430 + (i * 100), 344, 0);
            GameObject newHeart = Instantiate(heartTemplate, transform);
            newHeart.GetComponent<RectTransform>().anchoredPosition = spawnCoords;
            hearts.Add(newHeart);
        }

        heartTemplate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            LoseHeart();
        }
    }

    public void LoseHeart()
    {
        health--;
        if (health < 1)
        {
            Debug.Log("Game End");
        }
        else
        {
            DisableHeart(hearts[health]);
        }

    }

    private void DisableHeart(GameObject heart)
    {
        heart.transform.GetChild(0).gameObject.SetActive(false);
    }
}
