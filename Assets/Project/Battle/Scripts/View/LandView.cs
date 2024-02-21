using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LandView : MonoBehaviour
{
    [SerializeField] List<LandSpriteView> _landSpriteViewList;

    [NonSerialized] public LandEntity LandEntity = new LandEntity();
}
