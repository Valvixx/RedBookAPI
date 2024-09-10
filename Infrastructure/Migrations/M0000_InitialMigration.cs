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
            .WithColumn("description").AsString().NotNullable();
        
        Create.Table("element_pictures")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("element_id").AsString().NotNullable().ForeignKey()
            .WithColumn("link").AsString().NotNullable();
        Create.ForeignKey().FromTable("element_pictures").ForeignColumn("element_id").ToTable("book_elements").PrimaryColumn("id");
        
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