using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banana
{
    /**
     * 适配器模式
     * **/

    public enum MediaType
    {
        MP3 = 1,
        MP4 = 2,
        AVI = 3,
        RMVB = 4,
        WMV = 5,
        MKV = 6
    }
    public interface IMediaPlayer
    {
        void Play(MediaType mediaType, string fileName);
    }
    public interface IAdvanceMediaPlayer
    {
        void Play(string fileName);
    }

    public class Mp4Player : IAdvanceMediaPlayer
    {
        public void Play(string fileName)
        {
            Console.WriteLine("播放路径 " + fileName + " 下的mp4文件");
        }
    }

    public class AviPlayer : IAdvanceMediaPlayer
    {
        public void Play(string fileName)
        {
            Console.WriteLine("播放路径 " + fileName + " 下的avi文件");
        }
    }

    public class MediaAdapter : IMediaPlayer
    {
        IAdvanceMediaPlayer advanceMediaPlayer;
        public MediaAdapter(MediaType mediaType)
        {
            switch (mediaType)
            {
                case MediaType.MP3:
                    break;
                case MediaType.MP4:
                    advanceMediaPlayer = new Mp4Player();
                    break;
                case MediaType.AVI:
                    advanceMediaPlayer = new AviPlayer();
                    break;
                case MediaType.RMVB:
                    break;
                case MediaType.WMV:
                    break;
                case MediaType.MKV:
                    break;
                default:
                    break;
            }
        }

        public void Play(MediaType mediaType, string fileName)
        {
            if (advanceMediaPlayer != null)
            {
                advanceMediaPlayer.Play(fileName);
            }
        }
    }

    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void Play(MediaType mediaType, string fileName)
        {
            mediaAdapter = null;
            switch (mediaType)
            {
                case MediaType.MP3:
                    Console.WriteLine("播放路径 " + fileName + " 下的mp3文件");
                    break;
                case MediaType.MP4:
                case MediaType.AVI:
                    mediaAdapter = new MediaAdapter(mediaType);
                    break;
                default:
                    Console.WriteLine("暂不支持该文件格式");
                    break;
            }
            if (mediaAdapter != null)
            {
                mediaAdapter.Play(mediaType, fileName);
            }
        }
    }
}
