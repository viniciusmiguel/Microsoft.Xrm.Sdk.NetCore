// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Fault contract for IOrganizationService service contract.
  /// Use the OrganizationServiceFault contract to handle CRM specific errors in SDK client.
  /// </summary>
  [DataContract(Name = "OrganizationServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public class OrganizationServiceFault : BaseServiceFault
  {
    private string _traceText;
    private OrganizationServiceFault _innerFault;

    public override string ToString()
    {
      var stringBuilder1 = new StringBuilder();
      for (var organizationServiceFault = this; organizationServiceFault != null; organizationServiceFault = organizationServiceFault.InnerFault)
      {
        stringBuilder1.AppendLine("Exception details: ");
        stringBuilder1.AppendLine("ErrorCode: 0x" + organizationServiceFault.ErrorCode.ToString("X"));
        var str1 = "Message: " + organizationServiceFault.Message;
        stringBuilder1.AppendLine(str1);
        if (organizationServiceFault.ErrorDetails != null && organizationServiceFault.ErrorDetails.ContainsKey("CallStack"))
        {
          stringBuilder1.AppendLine("StackTrace: ");
          stringBuilder1.AppendLine(organizationServiceFault.ErrorDetails["CallStack"] as string);
        }
        var stringBuilder2 = stringBuilder1;
        var dateTime = organizationServiceFault.Timestamp;
        dateTime = dateTime.ToUniversalTime();
        var str2 = "TimeStamp: " + dateTime.ToString("o");
        stringBuilder2.AppendLine(str2);
        if (!string.IsNullOrWhiteSpace(organizationServiceFault.OriginalException))
          stringBuilder1.AppendLine("OriginalException: " + organizationServiceFault.OriginalException);
        if (!string.IsNullOrWhiteSpace(organizationServiceFault.ExceptionSource))
          stringBuilder1.AppendLine("ExceptionSource: " + organizationServiceFault.ExceptionSource);
        stringBuilder1.AppendLine("--");
      }
      return stringBuilder1.ToString();
    }

    /// <summary>
    /// Gets or sets diagnostic information added by custom plugins registered for the organization.
    /// </summary>
    [DataMember]
    public string TraceText
    {
      get => _traceText;
      set => _traceText = value;
    }

    /// <summary>
    /// Gets or sets get the inner exception information that caused the fault
    /// </summary>
    [DataMember]
    public OrganizationServiceFault InnerFault
    {
      get => _innerFault;
      set => _innerFault = value;
    }

    /// <summary>
    /// Gets or sets original Exception that triggered this FaultException.
    /// </summary>
    [DataMember]
    internal string OriginalException { get; set; }

    /// <summary>
    /// Gets or sets exception source, to map where original exception happened. This can be used
    /// to track where a chain of remote exception start failing.
    /// </summary>
    [DataMember]
    internal string ExceptionSource { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether indicates that the exception is safe to retry
    /// </summary>
    [DataMember]
    internal bool ExceptionRetriable { get; set; }

    [IgnoreDataMember]
    internal override BaseServiceFault InnerServiceFault
    {
      get => _innerFault;
      set => _innerFault = (OrganizationServiceFault) value;
    }
  }
}
