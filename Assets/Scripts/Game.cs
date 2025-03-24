using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelGame;
    [SerializeField] private Button _buttonWin;

    [Header("Settings animation window")] 
    [SerializeField] private float _speedFadePanel;
    [SerializeField] private float _speedScalePanel;
    [SerializeField] private GameObject _windowWin;
    [SerializeField] private float _speedFadeWindow;
    [SerializeField] private float _speedScaleWindow;
    
    private int _level;
    private int _money = 10000;
    private int _time = 1;
    private int _coins = 20;
    private int _deposit = 1;

    private CanvasGroup _canvasGroupPanelWin;
    private CanvasGroup _canvasGroupWindowWin;
    
    private const string KeyLevel = "Level";

    private void Start()
    {
        Application.targetFrameRate = 60;
        Load();
        
        _buttonWin.onClick.AddListener(OnWin);
        _canvasGroupPanelWin = _panelWin.GetComponent<CanvasGroup>();
        _canvasGroupWindowWin = _windowWin.GetComponent<CanvasGroup>();
    }

    private void OnWin()
    {
        _panelWin.gameObject.SetActive(true);
        AnimationWindow();
    }

    public int GetLevel()
    {
        return _level;
    }

    public int GetMoney()
    {
        return _money;
    }
    
    public int GetTime()
    {
        return _time;
    }
    
    public int GetCoins()
    {
        return _coins;
    }
    
    public int GetDeposit()
    {
        return _deposit;
    }

    public void LevelUp()
    {
        _level++;
        Save(KeyLevel, _level);
    }

    private void AnimationWindow()
    {
        _canvasGroupPanelWin.DOFade(0f,0);
        _panelWin.transform.DOScale(Vector3.zero, 0);
        _canvasGroupPanelWin.DOFade(1f,_speedFadePanel);
        _panelWin.transform.DOScale(Vector3.one, _speedScalePanel);
        
        _canvasGroupWindowWin.DOFade(0.3f,0);
        _windowWin.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0);
        _canvasGroupWindowWin.DOFade(1f,_speedFadeWindow);
        _windowWin.transform.DOScale(Vector3.one, _speedScaleWindow);
    }

    private void Load()
    {
        _level = PlayerPrefs.GetInt(KeyLevel, 1);
    }

    private void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
