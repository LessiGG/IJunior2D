using UnityEngine;
using UnityEngine.UI;

public class CoinsViewer : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    public Text CoinsText => _coinsText;
}