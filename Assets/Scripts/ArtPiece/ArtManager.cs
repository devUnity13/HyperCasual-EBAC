using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        Type_01,
        Type_02,
        Beach,
        Snow
    }

    public List<ArtSetup> artsetups;

    public ArtSetup GetArtSetupByType(ArtType artype)
    {
        return artsetups.Find(i => i.artType == artype);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
