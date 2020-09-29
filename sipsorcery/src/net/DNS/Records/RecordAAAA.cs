// ============================================================================
// FileName: RecordAAAA.cs
//
// Description:
// 
//
// Author(s):
// Alphons van der Heijden
//
// History:
// 28 Mar 2008	Aaron Clauson   Added to sipswitch code base based on http://www.codeproject.com/KB/library/DNS.NET_Resolver.aspx.
// 14 Oct 2019  Aaron Clauson   Synchronised with latest version of source from at https://www.codeproject.com/Articles/23673/DNS-NET-Resolver-C.
//
// License:
// The Code Project Open License (CPOL) https://www.codeproject.com/info/cpol10.aspx
// ============================================================================

using System.Net;

#region Rfc info

/*
2.2 AAAA data format

   A 128 bit IPv6 address is encoded in the data portion of an AAAA
   resource record in network byte order (high-order byte first).
 */

#endregion

namespace Heijden.DNS
{
    public class RecordAAAA : Record
    {
        public IPAddress Address;

        public RecordAAAA(RecordReader rr)
        {
            IPAddress.TryParse(
                string.Format("{0:x}:{1:x}:{2:x}:{3:x}:{4:x}:{5:x}:{6:x}:{7:x}",
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16(),
                    rr.ReadUInt16()), out this.Address);
        }

        public RecordAAAA(IPAddress address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return Address.ToString();
        }
    }
}
