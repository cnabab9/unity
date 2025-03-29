using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    Button _timeAttackButton;
    [SerializeField]
    Button _stageModeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void AddTimeClickEvent(UnityAction clicCallback)
    {
        _timeAttackButton.onClick.AddListener(clicCallback);
    }

    public void AddStageClickEvent(UnityAction clicCallback)
    {
        _stageModeButton.onClick.AddListener(clicCallback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
