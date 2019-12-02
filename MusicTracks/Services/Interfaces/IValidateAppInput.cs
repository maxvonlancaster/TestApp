using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Services.Interfaces
{
    public interface IValidateAppInput
    {
        void AspValidation();
        void CopyConstructor();
        void MatchMultipleSpaces();
        void PerfectValidation();
        void SimpleRegularExpression();
        void UsingConvert();
        void UsingTryParse();
        void ValidateMusicTrack();
        void ValidateTrackLength();
    }
}
