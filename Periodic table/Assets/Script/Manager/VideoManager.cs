using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{


    private static VideoManager instance;
    public static VideoManager Instance
    {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<VideoManager>();
            }
            return instance;
        }
    }

    //�̵�� �÷��̾� ���� ���� 
    public MediaPlayer mediaPlayer;

    //�̵�� ���۷��� ������� ����
    public MediaReference mediaReference;



    private void Start()
    {
        OnSetting();
    }


    private void OnStart()
    {


    }

    private void OnSetting() {
        mediaPlayer.OpenMedia(mediaReference, false);
        mediaPlayer.Loop = true;
    }


    public void OnLoadVideo() {
      
        
    }

    /// <summary>
    /// ���� �̺�Ʈ ó�� ���� ���� 
    /// </summary>
    /// <param name="mc"></param>
    /// <param name="et"></param>
    /// <param name="er"></param>
    public void OnVideoEvent(MediaPlayer mc, MediaPlayerEvent.EventType et, ErrorCode er) {
        switch (et) {
            case MediaPlayerEvent.EventType.FirstFrameReady:
                mediaPlayer.Control.Seek(0);
                mediaPlayer.Control.Play();
                break;
        }
    }

    /// <summary>
    /// ���� ��� ��Ʈ��
    /// </summary>
    public void VideoPlay() {
        mediaPlayer.Control.Seek(0);
        mediaPlayer.Control.Play();
    }

    /// <summary>
    /// ���� ��� ���� 
    /// </summary>
    public void VideoStop() {
        mediaPlayer.Control.Stop();
    }



}
