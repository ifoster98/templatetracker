using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace Ianf.Gametracker.Services.Domain
{
    public struct PositiveInt : IEquatable<PositiveInt>
    {
        public int Value { get; }

        private PositiveInt(int positiveInt) => Value = positiveInt;

        public static Option<PositiveInt> CreatePositiveInt(int positiveInt) =>
            IsValid(positiveInt)
                ? Some(new PositiveInt(positiveInt))
                : None;

        private static bool IsValid(int positiveInt) => positiveInt > 0;

        public bool Equals(PositiveInt other) => Value == other.Value;
    }
}