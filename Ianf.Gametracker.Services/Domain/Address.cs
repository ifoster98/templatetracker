using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace Ianf.Gametracker.Services.Domain
{
    public struct Address : IEquatable<Address>
    {
        public string Value { get; }

        private Address(string address) => Value = address;

        public static Option<Address> CreateAddress(string address) =>
            IsValid(address)
                ? Some(new Address(address))
                : None;

        private static bool IsValid(string address) => !String.IsNullOrEmpty(address);

        public bool Equals(Address other) => Value == other.Value;
    }
}