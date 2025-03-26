using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace ArcText
{
    [VideoEffect("아치 배치", ["배치"], ["arch","a-tihaiti","ArTex", "아치", "배치", "아치배치", "achibaechi"], isAviUtlSupported:false)]
    internal class ArcTextEffect: VideoEffectBase
    {
        public override string Label => "아치 배치";

        [Display(GroupName = "배치", Name = "높이", Description = "높이")]
        [AnimationSlider("F1", "px", -100, 100)]
        public Animation Height { get; } = new Animation(-100, -99999, 99999);

        [Display(GroupName = "배치", Name = "중심 위치", Description = "X 좌표의 중심 위치")]
        [AnimationSlider("F1", "%", -100, 100)]
        public Animation CenterXPoint { get; } = new Animation(0, -100, 100);

        [Display(GroupName = "배치", Name = "각도", Description = "각도")]
        [AnimationSlider("F1", "°", -90, 90)]
        public Animation Angle { get; } = new Animation(0, -3600, 3600);

        [Display(GroupName = "배치", Name = "간격", Description = "간격")]
        [AnimationSlider("F1", "px", -100, 100)]
        public Animation Interval { get; } = new Animation(0, -99999, 99999);


        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return[];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new ArcTextEffectProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [Height, Interval, Angle, CenterXPoint];
    }
}