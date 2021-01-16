using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace Ianf.Gametracker.Services.Domain
{
    public struct Name : IEquatable<Name>
    {
        public string Value { get; }

        private Name(string name) => Value = name;

        public static Option<Name> CreateName(string name) =>
            IsValid(name)
                ? Some(new Name(name))
                : None;

        private static bool IsValid(string name) => !String.IsNullOrEmpty(name);

        public bool Equals(Name other) => Value == other.Value;
    }
}