// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IKeyVaultClient
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  /// <summary>KeyVault Wrapper to KeyVault API</summary>
  public interface IKeyVaultClient
  {
    /// <summary>
    /// Plugins can change the Preferred auth method used by KeyVault.
    /// 
    /// By default KeyVaultProvider tries to use ClientCredential.
    /// </summary>
    AuthenticationType PreferredAuthType { get; set; }

    /// <summary>Gets a secret.</summary>
    /// <param name="vaultAddress">The URL for the vault containing the secrets.</param>
    /// <param name="secretName">The name of the secret in the given vault.</param>
    /// <returns>The secret</returns>
    string GetSecret(string vaultAddress, string secretName);

    /// <summary>Gets a secret with the default vault.</summary>
    /// <param name="secretName">The name of the secret in the default vault.</param>
    /// <returns>The secret</returns>
    string GetSecret(string secretName);

    /// <summary>Sets a secret in the specified vault.</summary>
    /// <param name="vaultAddress">The URL for the vault containing the secrets.</param>
    /// <param name="secretName">The name of the secret in the given vault.</param>
    /// <param name="value">The value of the secret.</param>
    void SetSecret(string vaultAddress, string secretName, string value);

    /// <summary>Sets a secret in the default vault.</summary>
    /// <param name="secretName">The name of the secret in the default vault.</param>
    /// <param name="value">The value of the secret.</param>
    void SetSecret(string secretName, string value);

    /// <summary>Deletes a secret.</summary>
    /// <param name="vaultAddress">The URL for the vault containing the secrets.</param>
    /// <param name="secretName">The name of the secret in the given vault.</param>
    void DeleteSecret(string vaultAddress, string secretName);

    /// <summary>Deletes a secret with the default vault.</summary>
    /// <param name="secretName">The name of the secret in the default vault.</param>
    void DeleteSecret(string secretName);

    /// <summary>
    /// Encrypts a single block of data. The amount of data that may be encrypted
    /// is determined by the target key type and the encryption algorithm.
    /// </summary>
    /// <param name="keyIdentifier">Full URL for the key.</param>
    /// <param name="algorithm">
    /// The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.
    /// For convenience the possible values are Wrapped under KeyVaultAlgorithm.
    /// </param>
    /// <param name="rawData">The raw data</param>
    /// <returns>Encrypted data</returns>
    byte[] Encrypt(string keyIdentifier, string algorithm, byte[] rawData);

    /// <summary>
    /// Encrypts a single block of data. The amount of data that may be encrypted
    /// is determined by the target key type and the encryption algorithm.
    /// </summary>
    /// <param name="keyName">The name of the key.</param>
    /// <param name="keyVersion">The version of the key (optional, use empty string for no version).</param>
    /// <param name="algorithm">
    /// The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.
    /// For convenience the possible values are Wrapped under KeyVaultAlgorithm.
    /// </param>
    /// <param name="rawData">The raw data</param>
    /// <returns>Encrypted data</returns>
    byte[] Encrypt(string keyName, string keyVersion, string algorithm, byte[] rawData);

    /// <summary>Decrypts a single block of encrypted data</summary>
    /// <param name="keyIdentifier">Full URL for the key.</param>
    /// <param name="algorithm">
    /// The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.
    /// For convenience the possible values are Wrapped under KeyVaultAlgorithm.
    /// </param>
    /// <param name="encryptedData">Encrypted data</param>
    /// <returns>Decrypted raw data</returns>
    byte[] Decrypt(string keyIdentifier, string algorithm, byte[] encryptedData);

    /// <summary>Decrypts a single block of encrypted data</summary>
    /// <param name="keyName">The name of the key.</param>
    /// <param name="keyVersion">The version of the key (optional, use empty string for no version).</param>
    /// <param name="algorithm">
    /// The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.
    /// For convenience the possible values are Wrapped under KeyVaultAlgorithm.
    /// </param>
    /// <param name="encryptedData">Encrypted data</param>
    /// <returns>Decrypted raw data</returns>
    byte[] Decrypt(string keyName, string keyVersion, string algorithm, byte[] encryptedData);
  }
}
