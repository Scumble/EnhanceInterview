namespace EnhanceInterview.Hubs.Models
{
	public class RtcIceServer
	{
		public string Urls { get; set; } = "stun:stun1.l.google.com:19302";

		public string Username { get; set; }

		public string Credential { get; set; }
	}
}