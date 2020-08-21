using System.Data.Entity;

using Repository.Entities.Lookups;

namespace EF_DB
{
	internal class Initializer : DropCreateDatabaseIfModelChanges<Context>
	{
		protected override void Seed(Context context)
		{
			Database db = context.Database;

			db.ExecuteSqlCommand(@"ALTER TABLE Users ADD CONSTRAINT CHK_Users_FirstName CHECK (LEN(FirstName) > 0), CONSTRAINT CHK_Users_FamilyName CHECK (LEN(FamilyName) > 0), CONSTRAINT DF_CreatedAt DEFAULT GETDATE() FOR CreatedAt");
			db.ExecuteSqlCommand(@"ALTER TABLE Genders ADD CONSTRAINT CHK_Genders_Name CHECK (LEN(Name) > 0), CONSTRAINT CHK_Genders_Anrede CHECK (LEN(Anrede) > 0)");

			context.Genders.AddRange(new[] { new Gender(1, "Mann", "r Herr"), new Gender(2, "Frau", " Frau"), new Gender(3, "Divers", "s Diverses") });
		}
	}
}
