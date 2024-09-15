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