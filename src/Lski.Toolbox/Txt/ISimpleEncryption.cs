﻿using System.Security.Cryptography;

namespace Lski.Toolbox.Txt {

	/// <summary>
	/// Utility class for encrypting/decrypting a string value using a password and a salt passed in. Where the algorithm used is declared as a generic type.
	/// </summary>
	public interface ISimpleEncryption {

		/// <summary>
		/// Decrypts a string that was encrypted using the same password, salt and <see cref="SymmetricAlgorithm"/> that created it
		/// </summary>
		/// <param name="text">The text that you want to decrypt</param>
		/// <param name="password">The password that is used with the salt to encrypt/decrypt the text</param>
		/// <typeparam name="T">The <see cref="SymmetricAlgorithm"/> to use to decrypt the value</typeparam>
		string Decrypt<T>(string text, string password) where T : SymmetricAlgorithm, new();

		/// <summary>
		/// Encrypts a string that can also be decrypted using the same password and a salt and <see cref="SymmetricAlgorithm"/>
		/// </summary>
		/// <param name="value">The text that you want to encypt</param>
		/// <param name="password">The password that is used with the salt to encrypt/decrypt the text</param>
		/// <typeparam name="T">The <see cref="SymmetricAlgorithm"/> to use to encrypt the value</typeparam>
		string Encrypt<T>(string value, string password) where T : SymmetricAlgorithm, new();
	}
}