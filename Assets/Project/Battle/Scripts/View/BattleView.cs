using Cysharp.Threading.Tasks;
using R3;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleView : MonoBehaviour
{
    [SerializeField] Button _debugButton;
    [SerializeField] PlayerView _playerViewPrefab;

    private LandView[] _landViews;

    private CancellationToken _token;

    private void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();

        _landViews = FindObjectsOfType<LandView>();

        var playerView = Instantiate(_playerViewPrefab);
        playerView.PlayerNumber = 0;

        var landView = _landViews.Where(n => n.IsGoal).FirstOrDefault();

        if (landView != null)
        {
            playerView.Position = landView.Position;
            playerView.CurrentLandView = landView;
            playerView.NextLandView = null;
        }

        _debugButton.OnClickAsObservable().Subscribe(async _ =>
        {
            int diceValue = UnityEngine.Random.Range(1, 7);

            await playerView.MoveAsync(diceValue, _token);

        }).AddTo(this);
    }

}
