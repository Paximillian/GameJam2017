using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private TextToSpeechManager m_Tts;

    // Use this for initialization
    void Start()
    {
        m_Tts.SpeakText("Please scan your area and find a table");
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> tablePlanes = SurfaceMeshesToPlanes.Instance.GetActivePlanes(PlaneTypes.Table);
    }
}
