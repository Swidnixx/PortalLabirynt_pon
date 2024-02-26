using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    UnityEngine.Camera myCamera;
    Transform player;

    public PortalTeleport tep { get; private set; }

    public Renderer renderSurface;

    private void Awake()
    {
        tep = GetComponentInChildren<PortalTeleport>();
    }
    private void Start()
    {
        myCamera = GetComponentInChildren<UnityEngine.Camera>();
        player = UnityEngine.Camera.main.transform;

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        otherPortal.renderSurface.material.SetTexture("_MainTex", rt);
    }
    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            otherPortal.transform.worldToLocalMatrix *
            player.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation( m.GetColumn(3), m.rotation);
    }
}
