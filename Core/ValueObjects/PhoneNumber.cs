﻿using System;
using System.Text.RegularExpressions;

namespace Core.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Phone number cannot be null or empty", nameof(value));
            }

            if (!IsValidPhoneNumber(value))
            {
                throw new ArgumentException("Invalid phone number format", nameof(value));
            }

            Value = value;
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            var phoneRegex = @"^\+?[1-9]\d{1,14}$"; 
            return Regex.IsMatch(phoneNumber, phoneRegex);
        }

        public override string ToString() => Value;
    }
}