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

    //미디어 플레이어 정의 구간 
    public MediaPlayer mediaPlayer;

    //미디어 레퍼런스 경로정의 구간
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
    /// 영상 이벤트 처리 정의 국간 
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
    /// 비디오 재생 컨트롤
    /// </summary>
    public void VideoPlay() {
        mediaPlayer.Control.Seek(0);
        mediaPlayer.Control.Play();
    }

    /// <summary>
    /// 비디오 재생 정지 
    /// </summary>
    public void VideoStop() {
        mediaPlayer.Control.Stop();
    }



}
