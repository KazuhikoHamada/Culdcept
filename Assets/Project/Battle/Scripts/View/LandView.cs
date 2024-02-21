using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class LandView : MonoBehaviour
{
    [SerializeField] public LandEntity LandEntity = new LandEntity();
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] bool _isGoal;
    [SerializeField] LandView _nextLandView;
    [SerializeField] List<LandSpriteView> _landSpriteViewList;

    void OnValidate()
    {
        var sprite = _landSpriteViewList.Where(n => n.LandType == LandEntity.LandType).Select(n => n.Sprite).FirstOrDefault();

        if (sprite != null)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}
