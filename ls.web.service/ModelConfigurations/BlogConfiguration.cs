
namespace ls.web.service.ModelConfigurations
{
    public partial class BlogConfiguration
    {
        partial void BlogConfigurationAppend()
        {
            HasMany(w => w.Comments);
        }
    }
}
