using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManeger : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Transform _canvasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);
        Debug.Log("dddd");
        //ModeUI 프리팹 리소스를 로드해서 instantiate 한다
        GameObject resGo = Resources.Load<GameObject>("Prefab/ModeUI");
        Debug.Log("resGo" + resGo);

        GameObject sceneGO = Instantiate(resGo,_canvasTrans, false);
        sceneGO.GetComponent<ModeUI>();
        ModeUI uiComp = sceneGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);

    }

    private void OnClickTimeAttackMode()
    {
        Debug.Log("a");
        //SceneManager.LoadScene(lobiescene);
        StartCoroutine(LoadSceneAsync("gamescene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        //게임신이 다 로드 된 이후에 다음 코드읽기
        yield return SceneManager.LoadSceneAsync(sceneName);
        //플레이어 생성
        GameObject resGo = Resources.Load<GameObject>("Prefab/PlayerSprite");
        Instantiate(resGo);
    }
    private void OnClickStageMode()
    {
        Debug.Log("b");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
