using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerModels;
    int indexModel = 0;
    // Start is called before the first frame update
    void Start()
    {
        ModealSearch();
        GetComponent<SpriteRenderer>().sprite = playerModels[indexModel].GetComponent<SpriteRenderer>().sprite;
        GetComponent<Animator>().runtimeAnimatorController = playerModels[indexModel].GetComponent<Animator>().runtimeAnimatorController;
    }


    private void ModealSearch()
    {
        for (int i = 0; i < playerModels.Length; i++)
        {
            if (playerModels[i].name == PlayerPrefs.GetString("Player"))
            {
                indexModel = i;
                break;
            }
        }
    }
}
