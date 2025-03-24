using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class WindowWin : MonoBehaviour
    {
        [SerializeField] private Button _buttonAds;
        [SerializeField] private Button _buttonClaim;
    
        [SerializeField] private TMP_Text _textLevel;
        [Header("Reward")]
        [SerializeField] private TMP_Text _textRewardMoney;
        [SerializeField] private TMP_Text _textRewardTime;
        [SerializeField] private TMP_Text _textRewardCoins;
        [SerializeField] private TMP_Text _textRewardDeposit;
        [Header("Reward x2")]
        [SerializeField] private TMP_Text _textRewardMoneyX2;
        [SerializeField] private TMP_Text _textRewardTimeX2;
        [SerializeField] private TMP_Text _textRewardCoinsX2;
        [SerializeField] private TMP_Text _textRewardDepositX2;

        [SerializeField] private Game _gameManager;


        private void Start()
        {
            _buttonAds.onClick.AddListener(OnButtonAdds);
            _buttonClaim.onClick.AddListener(OnButtonClaim);
        
            UpdateText();
        }

        private void OnEnable()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _textLevel.text = $"- LEVEL {_gameManager.GetLevel()} -";

            _textRewardMoney.text = $"+{_gameManager.GetMoney()}";
            _textRewardTime.text = $"x{_gameManager.GetTime()}";
            _textRewardCoins.text = $"x{_gameManager.GetCoins()}";
            _textRewardDeposit.text = $"x{_gameManager.GetDeposit()}";
        
            _textRewardMoneyX2.text = $"+{_gameManager.GetMoney()}";
            _textRewardTimeX2.text = $"x{_gameManager.GetTime()}";
            _textRewardCoinsX2.text = $"x{_gameManager.GetCoins()}";
            _textRewardDepositX2.text = $"x{_gameManager.GetDeposit()}";
        }
    
        private void OnButtonAdds()
        {
            AddReward(true);
        }
    
        private void OnButtonClaim()
        {
            AddReward(false);
        }

        private void AddReward(bool onAds)
        {
            gameObject.SetActive(false);
            _gameManager.LevelUp();
        }
    }
}
