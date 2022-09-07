using UnityEngine;

[RequireComponent(typeof(CoinsViewer))]
public class Wallet : MonoBehaviour
{
    private int _coinsCount;
    private CoinsViewer _coinsViewer;

    private void Start()
    {
        _coinsViewer = GetComponent<CoinsViewer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coinsCount++;
            _coinsViewer.CoinsText.text = _coinsCount.ToString();
            Destroy(collision.gameObject);
        }
    }   
}