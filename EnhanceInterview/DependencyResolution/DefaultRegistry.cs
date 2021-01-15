using AutoMapper;
using EnhanceInterview.BLL.MapperConfig;
using Lamar;

namespace EnhanceInterview.DependencyResolution
{
	public class DefaultRegistry : ServiceRegistry
	{
		public DefaultRegistry()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperConfig());
			});

			var mapper = config.CreateMapper();
			For<MapperConfiguration>().Use(config);
			For<IMapper>().Use(mapper);

			Scan(
				s =>
			{
				s.Assembly("EnhanceInterview.DAL");
				s.Assembly("EnhanceInterview.BLL");
				s.TheCallingAssembly();
				s.WithDefaultConventions();
			});
		}
	}
}