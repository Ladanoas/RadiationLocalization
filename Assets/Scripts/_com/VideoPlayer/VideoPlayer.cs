using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class VideoPlayer : AbstactSceneController<VideoPlayer>
{
	public enum VideoState { stoped, played, paused }

	public static event System.Action<VideoState> OnVideoStateChanged;
	public static bool IsFirstStart = false;
	[SerializeField] private GameObject _videoPlayer;
	[SerializeField] private RawImage _videoScreen;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private RawImage _dummy;
	[SerializeField] private VideoPlayerButton _replayButton;
	private MovieTexture _currentClip;
	private VideoState _currentState;
	private bool _isPlayed;
	private float _playerTimer;
	private System.Action _callback;

	private bool _isActive = false;
	public bool IsActive
	{
		get { return _isActive; }
		set
		{
			Stop();
			CancelInvoke("EndClip");
			_isActive = value;
			_videoPlayer.SetActive(value);
		}
	}

	private bool InitClip(VideoClip clip)
	{
		if(!IsActive || clip==null || clip.Video==null)
			return false;

		_currentClip = clip.Video;
		_videoScreen.texture = clip.Video;
		if(clip.Audio!=null)
		{
			_audioSource.clip = clip.Audio;
		}
		return true;
	}

	public void Play(VideoClip clip, System.Action callback = null)
	{
		if(InitClip(clip))
		{
			_callback = callback;
			Play();
		}
	}

	public void Play()
	{
		if(!IsActive || _currentClip==null)
			return;

		if(!_currentClip.isPlaying && _currentClip.isReadyToPlay)
		{
			_replayButton.Hide(0.1f);
			_dummy.SetAlpha(0.0f, 0.1f);

			_isPlayed = true;
			_currentClip.Play();
			_audioSource.Play();

			if(_currentState==VideoState.stoped)
			{
				_playerTimer = 0.0f;
			}
			Invoke("EndClip", _currentClip.duration - _playerTimer);
			
			ChangeVideoState(VideoState.played);
		}
	}

	public void Stop()
	{
		if(!IsActive || _currentClip==null)
			return;

		CancelInvoke("EndClip");
		_isPlayed = false;
		ChangeVideoState(VideoState.stoped);
		_currentClip.Stop();
		_audioSource.Stop();
	}

	public void Pause()
	{
		if(!IsActive || _currentClip==null)
			return;

		if(_currentClip.isPlaying)
		{
			_isPlayed = false;
			ChangeVideoState(VideoState.paused);
			_currentClip.Pause();
			_audioSource.Pause();
			CancelInvoke("EndClip");
		}
	}

	private void EndClip()
	{
		Stop();
		if(_callback!=null)
		{
			_callback();
		}
	}

	private void Update()
	{
		if(_isPlayed)
		{
			_playerTimer += Time.deltaTime;
		}
	}

	private void ChangeVideoState(VideoState state)
	{
		_currentState = state;
		if(OnVideoStateChanged!=null)
		{
			OnVideoStateChanged(state);
		}
	}

	public void DummyShow()
	{
		_dummy.SetAlpha(0.8f, 0.1f, () => _replayButton.Show(0.1f) );
	}
}
