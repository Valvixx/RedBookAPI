using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(0)]
public class M0000_InitialMigration: Migration
{
    public override void Up()
    {
        Create.Table("book_elements")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("type").AsString().NotNullable()
            .WithColumn("title").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("image").AsString().NotNullable();
        Create.Table("users")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("is_admin").AsBoolean().NotNullable()
            .WithColumn("email").AsString().NotNullable()
            .WithColumn("password").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("book_elements");
        Delete.Table("users");
    }
}