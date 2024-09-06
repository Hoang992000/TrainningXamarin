using Android.Content;
using Android.Media;

namespace NhatMinhQCI.Utilities
{
    public class SoundHelper
    {
        private readonly AudioAttributes audioAttributes;
        private readonly SoundPool soundPool;

        int soundPoolId;
        public SoundHelper(Context context)
        {
            audioAttributes = new AudioAttributes.Builder().SetUsage(AudioUsageKind.Media).SetContentType(AudioContentType.Music).Build();
            soundPool = new SoundPool.Builder().SetMaxStreams(10).SetAudioAttributes(audioAttributes).Build();
            soundPool.SetRate(soundPoolId, 0.25f);
            //soundPoolId = soundPool.Load(context, Resource.Drawable.beep, 1);

        }


        public void play()
        {
            soundPool.Play(soundPoolId, 1, 1, 0, 0, 1);
        }

        public void release()
        {
            soundPool.Release();
        }
    }
}