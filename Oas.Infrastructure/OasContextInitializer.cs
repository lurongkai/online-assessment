using System.Data.Entity;

namespace Oas.Infrastructure
{
    public class OasContextInitializer : DropCreateDatabaseIfModelChanges<OasContext>
    {
        protected override void Seed(OasContext context) {
            // context.SaveChanges();
        }
    }
}