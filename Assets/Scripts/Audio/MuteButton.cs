using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class MuteButton: MonoBehaviour
    {
        private Button _button;
        private Image _buttonImage;
        private bool _isMuted;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ToggleMute);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ToggleMute);
        }

        private void ToggleMute()
        {
            if (_isMuted)
            {
                AudioListener.volume = 1f;
                _isMuted = false;
                _buttonImage.color = _button.colors.normalColor;
            }
            else
            {
                AudioListener.volume = 0f;
                _isMuted = true;
                _buttonImage.color = _button.colors.pressedColor;
            }
        }
    }
}