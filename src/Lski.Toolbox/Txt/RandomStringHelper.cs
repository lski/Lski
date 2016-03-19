﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnumExtensions = Lski.Toolbox.Objects.EnumExtensions;

namespace Lski.Toolbox.Txt {

	/// <summary>
	/// Optional, but used to generate character selection lists for the RandomString class.
	/// </summary>
	[Obsolete("Use CharacterList instead, this class will be removed in the next major version")]
	public static class RandomStringHelper {

		/// <summary>
		/// Include uppercase letters
		/// </summary>
		/// <remarks></remarks>
		public const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		/// <summary>
		/// Include lowercase letters
		/// </summary>
		/// <remarks></remarks>
		public const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";

		/// <summary>
		/// Include numbers 0-9
		/// </summary>
		/// <remarks></remarks>
		public const string Numbers = "0123456789";

		/// <summary>
		/// Include underscores (best used in combination with other options)
		/// </summary>
		/// <remarks></remarks>
		public const string Underscores = "_";

		/// <summary>
		/// Include hyphens (best used in combination with other options)
		/// </summary>
		/// <remarks></remarks>
		public const string Hyphens = "-";

		/// <summary>
		/// Include both lower and upper case letters
		/// </summary>
		/// <remarks></remarks>
		public const string Letters = UppercaseLetters + LowercaseLetters;

		/// <summary>
		/// Include all upper and lower case letters and numbers
		/// </summary>
		/// <remarks></remarks>
		public const string AlphaNumerics = (Letters + Numbers);

		/// <summary>
		/// Include all options
		/// </summary>
		/// <remarks></remarks>
		public const string All = (AlphaNumerics + Underscores + Hyphens);

		/// <summary>
		/// States the types of characters that will be included in the Random String generated by CreateRandomString
		/// </summary>
		/// <remarks></remarks>
		[Flags]
		public enum CharacterOptions {

			/// <summary>
			/// Include uppercase letters
			/// </summary>
			/// <remarks></remarks>
			UppercaseLetters = 1,

			/// <summary>
			/// Include lowercase letters
			/// </summary>
			/// <remarks></remarks>
			LowercaseLetters = 2,

			/// <summary>
			/// Include numbers 0-9
			/// </summary>
			/// <remarks></remarks>
			Numbers = 4,

			/// <summary>
			/// Include underscores (best used in combination with other options)
			/// </summary>
			/// <remarks></remarks>
			Underscores = 8,

			/// <summary>
			/// Include hyphens (best used in combination with other options)
			/// </summary>
			/// <remarks></remarks>
			Hyphens = 16,

			/// <summary>
			/// Include both lower and upper case letters
			/// </summary>
			/// <remarks></remarks>
			Letters = (UppercaseLetters | LowercaseLetters),

			/// <summary>
			/// Include all upper and lower case letters and numbers
			/// </summary>
			/// <remarks></remarks>
			AlphaNumerics = (Letters | Numbers),

			/// <summary>
			/// Include all options
			/// </summary>
			/// <remarks></remarks>
			All = (AlphaNumerics | Underscores | Hyphens)
		}

		public static char[] CreateCharacterList(CharacterOptions characters = CharacterOptions.All, char[] exclude = null) {

			var charList = new List<byte>();
			byte[] charsToExclude;
			byte i;

			charsToExclude = exclude == null ? new byte[] { } : Encoding.ASCII.GetBytes(exclude);

			// Create a list of all the ascii characters that are allowed, at first ignoring the chars to exclude

			if (EnumExtensions.Has(characters, CharacterOptions.Numbers)) {

				for (i = 48; i <= 57; i++) {
					charList.Add(i);
				}
			}

			if (EnumExtensions.Has(characters, CharacterOptions.UppercaseLetters)) {

				for (i = 65; i <= 90; i++) {
					charList.Add(i);
				}
			}

			if (EnumExtensions.Has(characters, CharacterOptions.LowercaseLetters)) {

				for (i = 97; i <= 122; i++) {
					charList.Add(i);
				}
			}

			if (EnumExtensions.Has(characters, CharacterOptions.Underscores)) {

				if (!charsToExclude.Contains((byte)95))
					charList.Add(95);
			}

			if (EnumExtensions.Has(characters, CharacterOptions.Hyphens)) {

				if (!charsToExclude.Contains((byte)45))
					charList.Add(45);
			}

			// Now exclude any characters that the user wants to exclude
			foreach (var item in charsToExclude) {
				charList.Remove(item);
			}

			return charList.Select(Convert.ToChar).ToArray();
		}
	}
}