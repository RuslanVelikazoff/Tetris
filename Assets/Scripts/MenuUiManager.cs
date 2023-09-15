using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiManager : MonoBehaviour
{
    public Button easyLevelButton;
    public Button midleLevelButton;
    public Button hardLevelButton;

    public Button musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private void Start()
    {
        SetMusicSprite();
        SetSoundSprite();

        ButtonFunc();
    }

    private void ButtonFunc()
    {
        if (easyLevelButton != null)
        {
            easyLevelButton.onClick.RemoveAllListeners();
            easyLevelButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetFloat("Difficulty", 1f);
                SceneManager.LoadScene(1);
            });
        }

        if (midleLevelButton != null)
        {
            midleLevelButton.onClick.RemoveAllListeners();
            midleLevelButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetFloat("Difficulty", .6f);
                SceneManager.LoadScene(1);
            });
        }

        if (hardLevelButton != null)
        {
            hardLevelButton.onClick.RemoveAllListeners();
            hardLevelButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetFloat("Difficulty", .3f);
                SceneManager.LoadScene(1);
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 0)
                {
                    AudioManager.instance.OnMusic();
                    SetMusicSprite();
                }
                else
                {
                    AudioManager.instance.OffMusic();
                    SetMusicSprite();
                }
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 0)
                {
                    AudioManager.instance.OnSound();
                    SetSoundSprite();
                }
                else
                {
                    AudioManager.instance.OffSound();
                    SetSoundSprite();
                }
            });
        }
    }

    private void SetMusicSprite()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    private void SetSoundSprite()
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
    }
}
