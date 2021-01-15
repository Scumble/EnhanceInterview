namespace EnhanceInterview.BLL.Interfaces.Authorization
{
	public interface IPasswordEncoder
	{
		string EncodePassword(string password);
	}
}