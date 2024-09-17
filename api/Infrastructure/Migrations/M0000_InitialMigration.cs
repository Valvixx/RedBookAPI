using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(0)]
public class M0000_InitialMigration: Migration
{
    public override void Up()
    {
        Create.Table("book_elements")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("type").AsInt16().NotNullable()
            .WithColumn("title").AsString().NotNullable().Unique()
            .WithColumn("description").AsString().NotNullable();
        
        Create.Table("element_images")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("element_id").AsInt64().NotNullable().ForeignKey()
            .WithColumn("reference").AsString().NotNullable();
        Create.ForeignKey().FromTable("element_images").ForeignColumn("element_id").ToTable("book_elements").PrimaryColumn("id");
        
        Create.Table("users")
            .WithColumn("user_id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("display_name").AsString(60).NotNullable()
            .WithColumn("user_name").AsString(30).NotNullable()
            .WithColumn("email").AsString(50).NotNullable()
            .WithColumn("password").AsString(20).NotNullable()
            .WithColumn("created_date").AsDateTime().NotNullable();

        Insert.IntoTable("users")
            .Row(new
            {
                user_id = 0,
                display_name = "Admin",
                user_name = "admin",
                email = "admin@admin.com",
                password = "AdMiN",
                created_date = new DateTime()
            });
    }

    public override void Down()
    {
        Delete.Table("book_elements");
        Delete.Table("users");
    }
}