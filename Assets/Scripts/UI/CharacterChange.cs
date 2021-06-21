using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChange : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    [SerializeField]
    private Text characterName;
    [SerializeField]
    private Image curCharacter;
    [SerializeField]
    private Button buttonSelect;
    [SerializeField]
    private Button buttonBuy;
    [SerializeField]
    private GameObject errorPanel;
    [SerializeField]
    private int cost;
    private int curCharIndex = 0;
    private int characterIndex = 0;

    private void Start()
    {
        for (int i = 1; i < characters.Length; i++)
        {
            if (!PlayerPrefs.HasKey(characters[i].name))
                PlayerPrefs.SetString(characters[i].name, "lock");
        }

        for (characterIndex = 0; characterIndex < characters.Length; characterIndex++)
        {
            if (PlayerPrefs.GetString(characters[characterIndex].name) == "selected")
            {
                buttonSelect.interactable = false;
                curCharIndex = characterIndex;
                CurCharChange(characterIndex);
                break;
            }
        }
    }

    public void NextCharacter()
    {
        characterIndex++;
        if (characterIndex == characters.Length)
            characterIndex = 0;

        ButtonSwitch();

        CurCharChange(characterIndex);
    }

    public void PreviousCharacter()
    {
        characterIndex--;
        if (characterIndex < 0)
            characterIndex = characters.Length - 1;
        ButtonSwitch();
        CurCharChange(characterIndex);
    }

    public void Select()
    {
        PlayerPrefs.SetString(characters[curCharIndex].name, "unlock");
        curCharIndex = characterIndex;
        PlayerPrefs.SetString(characters[curCharIndex].name, "selected");
        PlayerPrefs.SetString("Player", characters[curCharIndex].name);
        buttonSelect.interactable = false;
    }

    public void Buy()
    {
        if (PlayerPrefs.GetInt("Fruits") - cost >= 0)
        {
            PlayerPrefs.SetInt("Fruits", PlayerPrefs.GetInt("Fruits") - cost);
            PlayerPrefs.SetString(characters[characterIndex].name, "unlock");
            buttonBuy.gameObject.SetActive(false);
            buttonSelect.interactable = true;
        }
        else
            errorPanel.gameObject.SetActive(true);
    }

    private void CurCharChange(int index)
    {
        characterName.text = characters[index].name;
        curCharacter.GetComponent<Image>().sprite = characters[index].GetComponent<SpriteRenderer>().sprite;  
    }

    private void ButtonSwitch()
    {
        if (PlayerPrefs.GetString(characters[characterIndex].name) == "selected")
        {
            buttonSelect.interactable = false;
            buttonBuy.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetString(characters[characterIndex].name) == "lock")
        {
            buttonSelect.interactable = false;
            buttonBuy.gameObject.SetActive(true);
            buttonBuy.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Buy for " + cost;
        }
        else
        {
            buttonSelect.interactable = true;
            buttonBuy.gameObject.SetActive(false);
        }
    }
}
